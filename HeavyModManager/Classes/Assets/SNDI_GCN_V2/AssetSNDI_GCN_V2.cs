using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class AssetSNDI_GCN_V2
{
    private uint _assetId; // hacky solution to weird issue

    public int pFMusicMod { get; set; }
    public int pFSBFileArray { get; set; }
    public int pWavInfoArray { get; set; }
    public int pCutsceneAudioHeaders { get; set; }

    public List<FSB3_File> Entries { get; set; }

    public List<EntrySoundInfo_GCN_V1> Entries_Sound_CIN { get; set; }

    public AssetSNDI_GCN_V2(Section_AHDR AHDR)
    {
        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), Endianness.Big);

        _assetId = reader.ReadUInt32();
        var totalSize = reader.ReadUInt32();
        pFMusicMod = reader.ReadInt32();
        pFSBFileArray = reader.ReadInt32();
        pWavInfoArray = reader.ReadInt32();
        pCutsceneAudioHeaders = reader.ReadInt32();
        ushort nWavFiles = reader.ReadUInt16();
        ushort nSounds = reader.ReadUInt16();
        ushort nStreams = reader.ReadUInt16();
        byte nFSBFiles = reader.ReadByte();
        byte nCutsceneAudioHeaders = reader.ReadByte();

        reader.BaseStream.Position = totalSize + 0x20;

        var offsets = new uint[nFSBFiles];
        for (int i = 0; i < nFSBFiles; i++)
            offsets[i] = reader.ReadUInt32() + 0x20;

        Entries = new List<FSB3_File>();
        for (int i = 0; i < offsets.Length; i++)
            using (var fsbReader = new EndianBinaryReader(new MemoryStream(AHDR.data), Endianness.Little))
            {
                fsbReader.BaseStream.Position = offsets[i];
                var fsb3file = new FSB3_File(fsbReader);
                fsbReader.BaseStream.Position = i + 1 < offsets.Length ? offsets[i + 1] - 0x08 : totalSize + 0x18;
                fsb3file.UnknownEndValue1 = fsbReader.ReadInt32();
                fsb3file.UnknownEndValue2 = fsbReader.ReadInt32();
                Entries.Add(fsb3file);
            }

        for (int i = 0; i < nWavFiles; i++)
        {
            var assetID = reader.ReadUInt32();
            var uFlags = reader.ReadByte();
            var uAudioSampleIndex = reader.ReadByte();
            var uFSBIndex = reader.ReadByte();
            var uSoundInfoIndex = reader.ReadByte();
            Entries[uFSBIndex].SoundEntries[uAudioSampleIndex].SetEntryData(assetID, uFlags, uAudioSampleIndex, uFSBIndex, uSoundInfoIndex);
        }

        Entries_Sound_CIN = new List<EntrySoundInfo_GCN_V1>();
        for (int i = 0; i < nCutsceneAudioHeaders; i++)
            Entries_Sound_CIN.Add(new EntrySoundInfo_GCN_V1(reader));
    }

    public byte[] Serialize()
    {
        using var writer = new EndianBinaryWriter(Endianness.Big);

        writer.BaseStream.Position = 0x20;
        for (int i = 0; i < Entries.Count; i++)
        {
            Entries[i].offset = (int)(writer.BaseStream.Position - 0x20);
            Entries[i].Serialize(writer);

            while (writer.BaseStream.Position % 0x20 != 0)
                writer.BaseStream.Position++;

            if (Entries[i].UnknownEndValue1 != 0 || Entries[i].UnknownEndValue2 != 0)
            {
                writer.BaseStream.Position -= 8;
                var ukbs = BitConverter.GetBytes(Entries[i].UnknownEndValue1);
                writer.Write(ukbs[0]);
                writer.Write(ukbs[1]);
                writer.Write(ukbs[2]);
                writer.Write(ukbs[3]);

                ukbs = BitConverter.GetBytes(Entries[i].UnknownEndValue2);
                writer.Write(ukbs[0]);
                writer.Write(ukbs[1]);
                writer.Write(ukbs[2]);
                writer.Write(ukbs[3]);
            }
        }

        int footerOffset = (int)(writer.BaseStream.Position - 0x20);
        List<GcWavInfo> gcWavInfos = new List<GcWavInfo>();

        for (int i = 0; i < Entries.Count; i++)
        {
            writer.Write(Entries[i].offset);
            for (int j = 0; j < Entries[i].Header.NumSamples; j++)
            {
                Entries[i].SoundEntries[j].uAudioSampleIndex = (byte)j;
                Entries[i].SoundEntries[j].uFSBIndex = (byte)i;
                gcWavInfos.Add(Entries[i].SoundEntries[j]);
            }
        }

        gcWavInfos = gcWavInfos.OrderBy(f => f._assetID).ToList();
        foreach (GcWavInfo entry in gcWavInfos)
            entry.Serialize(writer);

        foreach (var entry in Entries_Sound_CIN)
            entry.Serialize(writer);

        ushort nWavFiles = (ushort)Entries.Sum(e => e.SoundEntries.Count);
        ushort nSounds = (ushort)Entries.Sum(e => e.SoundEntries.Sum(se => (se.uFlags & 2) == 0 ? 1 : 0));
        ushort nStreams = (ushort)(nWavFiles - nSounds);

        writer.BaseStream.Position = 0;
        writer.Write(_assetId);
        writer.Write(footerOffset);
        writer.Write(pFMusicMod);
        writer.Write(pFSBFileArray);
        writer.Write(pWavInfoArray);
        writer.Write(pCutsceneAudioHeaders);
        writer.Write(nWavFiles);
        writer.Write(nSounds);
        writer.Write(nStreams);
        writer.Write((byte)Entries.Count);
        writer.Write((byte)Entries_Sound_CIN.Count);

        return writer.ToArray();
    }

    public void Merge(AssetSNDI_GCN_V2 assetSNDI)
    {
        List<FSB3_File> newEntries = new List<FSB3_File>();

        FSB3_File first = Entries[0];
        first.Merge(assetSNDI.Entries[0].SoundEntries);

        newEntries.Add(first);

        for (int i = 1; i < Entries.Count; i++)
        {
            bool found = false;
            foreach (var entry in assetSNDI.Entries)
                foreach (var entry2 in entry.SoundEntries)
                    if (Entries[i].SoundEntries.Any(entry3 => entry3._assetID == entry2._assetID))
                        found = true;

            if (!found)
                newEntries.Add(Entries[i]);
        }

        for (int i = 1; i < assetSNDI.Entries.Count; i++)
            newEntries.Add(assetSNDI.Entries[i]);

        Entries = newEntries;
    }
}