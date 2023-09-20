using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class EntrySoundInfo_GCN_V1
{
    public byte[] SoundHeader { get; set; }
    public uint soundAssetId { get; set; }

    public EntrySoundInfo_GCN_V1(EndianBinaryReader reader)
    {
        SoundHeader = reader.ReadBytes(0x60);
        soundAssetId = reader.ReadUInt32();
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write(SoundHeader);
        writer.Write(soundAssetId);
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

public class AssetSNDI_GCN_V1
{
    public List<EntrySoundInfo_GCN_V1> Entries_SND { get; set; }
    public List<EntrySoundInfo_GCN_V1> Entries_SNDS { get; set; }
    public List<EntrySoundInfo_GCN_V1> Entries_Sound_CIN { get; set; }

    public AssetSNDI_GCN_V1(Section_AHDR AHDR, Game game)
    {
        Entries_SND = new List<EntrySoundInfo_GCN_V1>();
        Entries_SNDS = new List<EntrySoundInfo_GCN_V1>();
        Entries_Sound_CIN = new List<EntrySoundInfo_GCN_V1>();

        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), Endianness.Big);

        int entriesSndAmount = reader.ReadInt32();
        reader.ReadInt32();
        int entriesSndsAmount = reader.ReadInt32();
        int entriesCinAmount = game == Game.BFBB ? reader.ReadInt32() : 0;

        for (int i = 0; i < entriesSndAmount; i++)
            Entries_SND.Add(new EntrySoundInfo_GCN_V1(reader));

        for (int i = 0; i < entriesSndsAmount; i++)
            Entries_SNDS.Add(new EntrySoundInfo_GCN_V1(reader));

        if (game == Game.BFBB)
            for (int i = 0; i < entriesCinAmount; i++)
                Entries_Sound_CIN.Add(new EntrySoundInfo_GCN_V1(reader));
    }

    public byte[] Serialize(Game game)
    {
        using var writer = new EndianBinaryWriter(Endianness.Big);

        writer.Write(Entries_SND.Count);
        writer.Write(0xCDCDCDCD);
        writer.Write(Entries_SNDS.Count);
        if (game == Game.BFBB)
            writer.Write(Entries_Sound_CIN.Count);

        foreach (var e in Entries_SND)
            e.Serialize(writer);
        foreach (var e in Entries_SNDS)
            e.Serialize(writer);
        foreach (var e in Entries_Sound_CIN)
            e.Serialize(writer);

        return writer.ToArray();
    }

    public void Merge(AssetSNDI_GCN_V1 asset)
    {
        foreach (var entry in asset.Entries_SND)
        {
            Entries_SND.Remove(entry);
            Entries_SND.Add(entry);
        }

        foreach (var entry in asset.Entries_SNDS)
        {
            Entries_SNDS.Remove(entry);
            Entries_SNDS.Add(entry);
        }

        foreach (var entry in asset.Entries_Sound_CIN)
        {
            Entries_Sound_CIN.Remove(entry);
            Entries_Sound_CIN.Add(entry);
        }
    }
}