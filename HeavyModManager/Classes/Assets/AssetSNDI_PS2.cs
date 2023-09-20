using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class EntrySoundInfo_PS2
{
    public byte[] SoundHeader { get; set; }

    public EntrySoundInfo_PS2(EndianBinaryReader reader)
    {
        SoundHeader = reader.ReadBytes(0x30);
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write(SoundHeader);
    }

    public uint soundAssetId
    {
        get => BitConverter.ToUInt32(SoundHeader, 0x8);
        set
        {
            byte[] byteArray = BitConverter.GetBytes(value);
            SoundHeader[0x8] = byteArray[0];
            SoundHeader[0x9] = byteArray[1];
            SoundHeader[0xA] = byteArray[2];
            SoundHeader[0xB] = byteArray[3];
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is EntrySoundInfo_PS2 entry)
            return soundAssetId.Equals(entry.soundAssetId);
        return false;
    }

    public override int GetHashCode()
    {
        return soundAssetId.GetHashCode();
    }
}

public enum EVersionIncrediblesROTUOthers
{
    ScoobyBfbbMovie,
    IncrediblesRotu
}

public class AssetSNDI_PS2
{
    public List<EntrySoundInfo_PS2> Entries_SND { get; set; }
    public List<EntrySoundInfo_PS2> Entries_SNDS { get; set; }

    public EVersionIncrediblesROTUOthers AssetVersion { get; set; } = EVersionIncrediblesROTUOthers.ScoobyBfbbMovie;

    public AssetSNDI_PS2(Section_AHDR AHDR)
    {
        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), Endianness.Little);

        var maybeAssetId = reader.ReadUInt32();
        if (maybeAssetId == AHDR.assetID)
        {
            AssetVersion = EVersionIncrediblesROTUOthers.IncrediblesRotu;
        }
        else
        {
            AssetVersion = EVersionIncrediblesROTUOthers.ScoobyBfbbMovie;
            reader.BaseStream.Position = 0;
        }

        int entriesSndAmount = reader.ReadInt32();
        int entriesSndsAmount = reader.ReadInt32();

        Entries_SND = new List<EntrySoundInfo_PS2>();
        for (int i = 0; i < entriesSndAmount; i++)
            Entries_SND.Add(new EntrySoundInfo_PS2(reader));

        Entries_SNDS = new List<EntrySoundInfo_PS2>();
        for (int i = 0; i < entriesSndsAmount; i++)
            Entries_SNDS.Add(new EntrySoundInfo_PS2(reader));
    }

    public byte[] Serialize(uint assetID)
    {
        using var writer = new EndianBinaryWriter(Endianness.Little);

        if (AssetVersion == EVersionIncrediblesROTUOthers.IncrediblesRotu)
            writer.Write(assetID);

        writer.Write(Entries_SND.Count);
        writer.Write(Entries_SNDS.Count);

        foreach (var e in Entries_SND)
            e.Serialize(writer);
        foreach (var e in Entries_SNDS)
            e.Serialize(writer);

        return writer.ToArray();
    }

    public void Merge(AssetSNDI_PS2 asset)
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
    }
}