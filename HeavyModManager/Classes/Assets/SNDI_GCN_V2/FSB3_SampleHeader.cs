namespace HeavyModManager.Classes.Assets;

public class FSB3_SampleHeader
{
    public string Name { get; set; }
    public int LengthSamples { get; set; }
    public int LengthCompressedBytes { get; set; }
    public uint LoopStart { get; set; }
    public uint LoopEnd { get; set; }
    public uint SampleHeaderMode { get; set; }
    public int Frequency { get; set; }
    public ushort Volume { get; set; }
    public short Pan { get; set; }
    public ushort Priority { get; set; }
    public ushort NumChannels { get; set; }
    public uint MinDistance { get; set; }
    public uint MaxDistance { get; set; }
    public int VariableFrequency { get; set; }
    public ushort VariableVolume { get; set; }
    public short VariablePan { get; set; }

    public FSB3_SampleHeader(BinaryReader reader)
    {
        reader.ReadUInt16();
        Name = new string(reader.ReadChars(30));
        LengthSamples = reader.ReadInt32();
        LengthCompressedBytes = reader.ReadInt32();
        LoopStart = reader.ReadUInt32();
        LoopEnd = reader.ReadUInt32();
        SampleHeaderMode = reader.ReadUInt32();
        Frequency = reader.ReadInt32();
        Volume = reader.ReadUInt16();
        Pan = reader.ReadInt16();
        Priority = reader.ReadUInt16();
        NumChannels = reader.ReadUInt16();
        MinDistance = reader.ReadUInt32();
        MaxDistance = reader.ReadUInt32();
        VariableFrequency = reader.ReadInt32();
        VariableVolume = reader.ReadUInt16();
        VariablePan = reader.ReadInt16();
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write((ushort)(0x50 + NumChannels * 0x2E));
        writer.WritePaddedString(Name, 30);
        writer.Write(LengthSamples);
        writer.Write(LengthCompressedBytes);
        writer.Write(LoopStart);
        writer.Write(LoopEnd);
        writer.Write(SampleHeaderMode);
        writer.Write(Frequency);
        writer.Write(Volume);
        writer.Write(Pan);
        writer.Write(Priority);
        writer.Write(NumChannels);
        writer.Write(MinDistance);
        writer.Write(MaxDistance);
        writer.Write(VariableFrequency);
        writer.Write(VariableVolume);
        writer.Write(VariablePan);
    }
}
