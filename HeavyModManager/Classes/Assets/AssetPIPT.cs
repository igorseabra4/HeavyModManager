using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class PipeInfo
{
    public uint Model { get; set; }
    public uint SubObjectBits { get; set; }
    public uint PipeFlags { get; set; }

    public uint Unknown { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is PipeInfo entry)
            return Model.Equals(entry.Model) && SubObjectBits.Equals(entry.SubObjectBits);
        return false;
    }

    public override int GetHashCode()
    {
        return Model.GetHashCode();
    }

    public PipeInfo(EndianBinaryReader reader, Game game)
    {
        Model = reader.ReadUInt32();
        SubObjectBits = reader.ReadUInt32();
        PipeFlags = reader.ReadUInt32();
        if (game == Game.Incredibles)
            Unknown = reader.ReadUInt32();
    }

    public void Serialize(EndianBinaryWriter writer, Game game)
    {
        writer.Write(Model);
        writer.Write(SubObjectBits);
        writer.Write(PipeFlags);

        if (game == Game.Incredibles)
            writer.Write(Unknown);
    }
}

public class AssetPIPT
{
    private List<PipeInfo> Entries;

    public AssetPIPT(Section_AHDR AHDR, Game game, Endianness endianness)
    {
        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), endianness);
        var count = reader.ReadInt32();
        Entries = new List<PipeInfo>();
        for (int i = 0; i < count; i++)
            Entries.Add(new PipeInfo(reader, game));
    }

    public byte[] Serialize(Game game, Endianness endianness)
    {
        using var writer = new EndianBinaryWriter(endianness);
        writer.Write(Entries.Count);
        foreach (var l in Entries)
            l.Serialize(writer, game);
        return writer.ToArray();
    }

    public void Merge(AssetPIPT asset)
    {
        foreach (var entry in asset.Entries)
        {
            Entries.RemoveAll(e => e.Model == entry.Model && e.SubObjectBits == entry.SubObjectBits);
            Entries.Add(entry);
        }
    }
}
