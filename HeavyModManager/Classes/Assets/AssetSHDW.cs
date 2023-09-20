using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class EntrySHDW
{
    public uint Model { get; set; }
    public uint ShadowModel { get; set; }
    public uint Unknown { get; set; }

    public EntrySHDW(EndianBinaryReader reader)
    {
        Model = reader.ReadUInt32();
        ShadowModel = reader.ReadUInt32();
        Unknown = reader.ReadUInt32();
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write(Model);
        writer.Write(ShadowModel);
        writer.Write(Unknown);
    }

    public override int GetHashCode()
    {
        return Model.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is EntrySHDW entrySHDW)
            return Model.Equals(entrySHDW.Model);
        return false;
    }
}

public class AssetSHDW
{
    private List<EntrySHDW> Entries;

    public AssetSHDW(Section_AHDR AHDR, Endianness endianness)
    {
        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), endianness);
        var count = reader.ReadInt32();
        Entries = new List<EntrySHDW>();
        for (int i = 0; i < count; i++)
            Entries.Add(new EntrySHDW(reader));
    }

    public byte[] Serialize(Endianness endianness)
    {
        using var writer = new EndianBinaryWriter(endianness);
        writer.Write(Entries.Count);
        foreach (var l in Entries)
            l.Serialize(writer);
        return writer.ToArray();
    }

    public void Merge(AssetSHDW asset)
    {
        foreach (var entry in asset.Entries)
        {
            Entries.RemoveAll(e => e.Model == entry.Model);
            Entries.Add(entry);
        }
    }
}
