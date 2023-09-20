using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class EntrySoundInfo_XBOX
{
    public ushort wFormatTag { get; set; }
    public ushort nChannels { get; set; }
    public uint nSamplesPerSec { get; set; }
    public uint nAvgBytesPerSec { get; set; }
    public ushort nBlockAlign { get; set; }
    public ushort wBitsPerSample { get; set; }
    public ushort cbSize { get; set; }
    public ushort NibblesPerBlock { get; set; }
    public uint dataSize { get; set; }
    public uint soundAssetId { get; set; }
    public uint flag_loop { get; set; }

    public EntrySoundInfo_XBOX(EndianBinaryReader reader)
    {
        wFormatTag = reader.ReadUInt16();
        nChannels = reader.ReadUInt16();
        nSamplesPerSec = reader.ReadUInt32();
        nAvgBytesPerSec = reader.ReadUInt32();
        nBlockAlign = reader.ReadUInt16();
        wBitsPerSample = reader.ReadUInt16();
        cbSize = reader.ReadUInt16();
        NibblesPerBlock = reader.ReadUInt16();
        dataSize = reader.ReadUInt32();
        soundAssetId = reader.ReadUInt32();
        flag_loop = reader.ReadUInt32();

        reader.BaseStream.Position += 12;
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write(wFormatTag);
        writer.Write(nChannels);
        writer.Write(nSamplesPerSec);
        writer.Write(nAvgBytesPerSec);
        writer.Write(nBlockAlign);
        writer.Write(wBitsPerSample);
        writer.Write(cbSize);
        writer.Write(NibblesPerBlock);
        writer.Write(dataSize);
        writer.Write(soundAssetId);
        writer.Write(flag_loop);
        writer.Write(new byte[12]);
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is EntrySoundInfo_XBOX entry)
            return soundAssetId.Equals(entry.soundAssetId);
        return false;
    }

    public override int GetHashCode()
    {
        return soundAssetId.GetHashCode();
    }
}

public class AssetSNDI_XBOX
{
    public List<EntrySoundInfo_XBOX> Entries_SND { get; set; }
    public List<EntrySoundInfo_XBOX> Entries_SNDS { get; set; }
    public List<EntrySoundInfo_XBOX> Entries_Sound_CIN { get; set; }

    public AssetSNDI_XBOX(Section_AHDR AHDR)
    {
        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), Endianness.Little);

        int entriesSndAmount = reader.ReadInt32();
        int entriesSndsAmount = reader.ReadInt32();
        int entriesCinAmount = reader.ReadInt32();

        Entries_SND = new List<EntrySoundInfo_XBOX>();
        for (int i = 0; i < entriesSndAmount; i++)
            Entries_SND.Add(new EntrySoundInfo_XBOX(reader));

        Entries_SNDS = new List<EntrySoundInfo_XBOX>();
        for (int i = 0; i < entriesSndsAmount; i++)
            Entries_SNDS.Add(new EntrySoundInfo_XBOX(reader));

        Entries_Sound_CIN = new List<EntrySoundInfo_XBOX>();
        for (int i = 0; i < entriesCinAmount; i++)
            Entries_Sound_CIN.Add(new EntrySoundInfo_XBOX(reader));
    }

    public byte[] Serialize()
    {
        using var writer = new EndianBinaryWriter(Endianness.Little);

        writer.Write(Entries_SND.Count);
        writer.Write(Entries_SNDS.Count);
        writer.Write(Entries_Sound_CIN.Count);

        foreach (var e in Entries_SND)
            e.Serialize(writer);
        foreach (var e in Entries_SNDS)
            e.Serialize(writer);
        foreach (var e in Entries_Sound_CIN)
            e.Serialize(writer);

        return writer.ToArray();
    }

    public void Merge(AssetSNDI_XBOX asset)
    {
        foreach (var entry in asset.Entries_SND)
        {
            Entries_SND.RemoveAll(e => e.soundAssetId == entry.soundAssetId);
            Entries_SND.Add(entry);
        }

        foreach (var entry in asset.Entries_SNDS)
        {
            Entries_SNDS.RemoveAll(e => e.soundAssetId == entry.soundAssetId);
            Entries_SNDS.Add(entry);
        }

        foreach (var entry in asset.Entries_Sound_CIN)
        {
            Entries_Sound_CIN.RemoveAll(e => e.soundAssetId == entry.soundAssetId);
            Entries_Sound_CIN.Add(entry);
        }
    }
}