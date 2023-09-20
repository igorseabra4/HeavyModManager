namespace HeavyModManager.Classes.Assets;

public class FSB3_SampleHeaderBasic
{
    public int LengthSamples { get; set; }
    public int LengthCompressedBytes { get; set; }

    public FSB3_SampleHeaderBasic(BinaryReader reader)
    {
        LengthSamples = reader.ReadInt32();
        LengthCompressedBytes = reader.ReadInt32();
    }

    public FSB3_SampleHeaderBasic(int lengthSamples, int lengthCompressedBytes)
    {
        LengthSamples = lengthSamples;
        LengthCompressedBytes = lengthCompressedBytes;
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write(LengthSamples);
        writer.Write(LengthCompressedBytes);
    }
}
