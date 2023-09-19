using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class EntryLODT
{
    public uint BaseModel { get; set; }
    public uint MaxDistance { get; set; }
    public uint LOD1_Model { get; set; }
    public uint LOD1_MinDistance { get; set; }
    public uint LOD2_Model { get; set; }
    public uint LOD2_MinDistance { get; set; }
    public uint LOD3_Model { get; set; }
    public uint LOD3_MinDistance { get; set; }

    // Movie/Incredibles only
    public uint Unknown { get; set; }

    public EntryLODT(EndianBinaryReader reader, Game game)
    {
        BaseModel = reader.ReadUInt32();
        MaxDistance = reader.ReadUInt32();
        LOD1_Model = reader.ReadUInt32();
        LOD2_Model = reader.ReadUInt32();
        LOD3_Model = reader.ReadUInt32();
        LOD1_MinDistance = reader.ReadUInt32();
        LOD2_MinDistance = reader.ReadUInt32();
        LOD3_MinDistance = reader.ReadUInt32();

        if (game == Game.Incredibles)
            Unknown = reader.ReadUInt32();
    }

    public void Serialize(EndianBinaryWriter writer, Game game)
    {
        writer.Write(BaseModel);
        writer.Write(MaxDistance);
        writer.Write(LOD1_Model);
        writer.Write(LOD2_Model);
        writer.Write(LOD3_Model);
        writer.Write(LOD1_MinDistance);
        writer.Write(LOD2_MinDistance);
        writer.Write(LOD3_MinDistance);

        if (game == Game.Incredibles)
            writer.Write(Unknown);
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is EntryLODT entry)
            return BaseModel.Equals(entry.BaseModel);
        return false;
    }

    public override int GetHashCode()
    {
        return BaseModel.GetHashCode();
    }
}

public class AssetLODT
{
    private List<EntryLODT> Entries;

    public AssetLODT(Section_AHDR AHDR, Game game, Endianness endianness)
    {
        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), endianness);
        {
            var count = reader.ReadInt32();
            Entries = new List<EntryLODT>();
            for (int i = 0; i < count; i++)
                Entries.Add(new EntryLODT(reader, game));
        }
    }

    public byte[] Serialize(Game game, Endianness endianness)
    {
        using var writer = new EndianBinaryWriter(endianness);
        writer.Write(Entries.Count);
        foreach (var entry in Entries)
            entry.Serialize(writer, game);
        return writer.ToArray();
    }

    public void Merge(AssetLODT asset)
    {
        foreach (var entry in asset.Entries)
        {
            Entries.Remove(entry);
            Entries.Add(entry);
        }
    }
}
