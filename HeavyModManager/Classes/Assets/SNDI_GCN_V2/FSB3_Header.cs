namespace HeavyModManager.Classes.Assets;

public class FSB3_Header
{
    public int NumSamples { get; set; }

    public int TotalHeadersSize { get; set; }

    public int TotalDataSize { get; set; }

    public int Version { get; set; }

    public uint Mode { get; set; }

    public FSB3_Header()
    {
        NumSamples = 0;
        TotalHeadersSize = 0;
        TotalDataSize = 0;
        Version = 196609;
        Mode = 2;
    }

    public FSB3_Header(BinaryReader reader)
    {
        NumSamples = reader.ReadInt32();
        TotalHeadersSize = reader.ReadInt32();
        TotalDataSize = reader.ReadInt32();
        Version = reader.ReadInt32();
        Mode = reader.ReadUInt32();
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write(NumSamples);
        writer.Write(TotalHeadersSize);
        writer.Write(TotalDataSize);
        writer.Write(Version);
        writer.Write(Mode);
    }
}
