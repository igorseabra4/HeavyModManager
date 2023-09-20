namespace HeavyModManager.Classes.Assets;

public class FSB3_File
{
    public FSB3_Header Header { get; set; }
    public FSB3_SampleHeader SampleHeader { get; set; }
    public List<GcWavInfo> SoundEntries { get; set; }

    public FSB3_File(BinaryReader reader)
    {
        if (reader.ReadChar() != 'F' ||
            reader.ReadChar() != 'S' ||
            reader.ReadChar() != 'B' ||
            reader.ReadChar() != '3')
            throw new Exception("Error reading FSB3 file");

        Header = new FSB3_Header(reader);

        SampleHeader = new FSB3_SampleHeader(reader);

        SoundEntries = new List<GcWavInfo>();
        for (int i = 0; i < Header.NumSamples; i++)
        {
            var newSound = new GcWavInfo();

            newSound.BasicSampleHeader = i == 0 ?
            new FSB3_SampleHeaderBasic(SampleHeader.LengthSamples, SampleHeader.LengthCompressedBytes) :
               new FSB3_SampleHeaderBasic(reader);

            newSound.GcAdpcmInfos = new List<FMOD_GcADPCMInfo>();
            for (int j = 0; j < SampleHeader.NumChannels; j++)
                newSound.GcAdpcmInfos.Add(new FMOD_GcADPCMInfo(reader));

            SoundEntries.Add(newSound);
        }

        for (int i = 0; i < SoundEntries.Count; i++)
            SoundEntries[i].Data = reader.ReadBytes(SoundEntries[i].BasicSampleHeader.LengthCompressedBytes);
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        using var fsbWriter = new EndianBinaryWriter(Endianness.Little);

        fsbWriter.Write((byte)'F');
        fsbWriter.Write((byte)'S');
        fsbWriter.Write((byte)'B');
        fsbWriter.Write((byte)'3');

        SampleHeader.LengthSamples = SoundEntries.Count > 0 ? SoundEntries[0].BasicSampleHeader.LengthSamples : 0;
        SampleHeader.LengthCompressedBytes = SoundEntries.Count > 0 ? SoundEntries[0].BasicSampleHeader.LengthCompressedBytes : 0;

        Header.NumSamples = SoundEntries.Count;
        Header.TotalDataSize = 0;
        foreach (var se in SoundEntries)
            Header.TotalDataSize += se.BasicSampleHeader.LengthCompressedBytes;

        Header.Serialize(fsbWriter);

        int totalHeadersSize = (int)fsbWriter.BaseStream.Position;

        SampleHeader.Serialize(fsbWriter);

        for (int i = 0; i < SoundEntries.Count; i++)
        {
            if (i != 0)
                SoundEntries[i].BasicSampleHeader.Serialize(fsbWriter);

            for (int j = 0; j < SoundEntries[i].GcAdpcmInfos.Count; j++)
                SoundEntries[i].GcAdpcmInfos[j].Serialize(fsbWriter);
        }

        totalHeadersSize = (int)fsbWriter.BaseStream.Position - totalHeadersSize;
        Header.TotalHeadersSize = totalHeadersSize;

        for (int i = 0; i < SoundEntries.Count; i++)
            fsbWriter.Write(SoundEntries[i].Data);

        fsbWriter.BaseStream.Position = 4;
        Header.Serialize(fsbWriter);

        writer.Write(fsbWriter.ToArray());
    }

    public int offset { get; set; }
    public int UnknownEndValue1 { get; set; }
    public int UnknownEndValue2 { get; set; }

    public void Merge(List<GcWavInfo> soundEntries)
    {
        foreach (var entry in soundEntries)
        {
            SoundEntries.RemoveAll(e => e._assetID == entry._assetID);
            SoundEntries.Add(entry);
        }
    }
}
