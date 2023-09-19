using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class EntryCOLL
{
    public uint Model { get; set; }
    public uint CollisionModel { get; set; }
    public uint CameraCollisionModel { get; set; }

    public EntryCOLL(EndianBinaryReader reader)
    {
        Model = reader.ReadUInt32();
        CollisionModel = reader.ReadUInt32();
        CameraCollisionModel = reader.ReadUInt32();
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write(Model);
        writer.Write(CollisionModel);
        writer.Write(CameraCollisionModel);
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is EntryCOLL entryCOLL)
            return Model.Equals(entryCOLL.Model);
        return false;
    }

    public override int GetHashCode()
    {
        return Model.GetHashCode();
    }
}

public class AssetCOLL
{
    public List<EntryCOLL> Entries { get; set; }

    public AssetCOLL(Section_AHDR AHDR, Endianness endianness)
    {
        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), endianness);
        var count = reader.ReadInt32();
        Entries = new List<EntryCOLL>();
        for (int i = 0; i < count; i++)
            Entries.Add(new EntryCOLL(reader));
    }

    public byte[] Serialize(Endianness endianness)
    {
        using var writer = new EndianBinaryWriter(endianness);
        writer.Write(Entries.Count);
        foreach (var entry in Entries)
            entry.Serialize(writer);
        return writer.ToArray();
    }

    public void Merge(AssetCOLL asset)
    {
        foreach (var entry in asset.Entries)
        {
            Entries.Remove(entry);
            Entries.Add(entry);
        }
    }
}
