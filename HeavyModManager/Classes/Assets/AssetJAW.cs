using HipHopFile;

namespace HeavyModManager.Classes.Assets;

public class EntryJAW
{
    public uint Sound { get; set; }
    public byte[] JawData { get; set; }

    public EntryJAW(uint soundAssetID, byte[] jawData)
    {
        Sound = soundAssetID;
        JawData = jawData;
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is EntryJAW entryJAW)
            return Sound.Equals(entryJAW.Sound);
        return false;
    }

    public override int GetHashCode()
    {
        return Sound.GetHashCode();
    }
}

public class AssetJAW
{
    public List<EntryJAW> Entries { get; set; }

    public AssetJAW(Section_AHDR AHDR, Endianness endianness)
    {
        using var reader = new EndianBinaryReader(new MemoryStream(AHDR.data), endianness);
        var count = reader.ReadInt32();
        Entries = new List<EntryJAW>();

        int startOfJawData = 4 + 12 * count;

        for (int i = 0; i < count; i++)
        {
            uint soundAssetID = reader.ReadUInt32();
            int offset = reader.ReadInt32();
            reader.ReadInt32();

            int length = BitConverter.ToInt32(AHDR.data, startOfJawData + offset);
            byte[] jawData = AHDR.data.Skip(startOfJawData + offset + 4).Take(length).ToArray();

            Entries.Add(new EntryJAW(soundAssetID, jawData));
        }
    }

    public byte[] Serialize(Endianness endianness)
    {
        using var writer = new EndianBinaryWriter(endianness);

        List<byte> newJawData = new List<byte>();

        writer.Write(Entries.Count);

        foreach (var i in Entries)
        {
            writer.Write(i.Sound);
            writer.Write(newJawData.Count);
            writer.Write(i.JawData.Length + 4);

            newJawData.AddRange(BitConverter.GetBytes(i.JawData.Length));
            newJawData.AddRange(i.JawData);

            while (newJawData.Count % 4 != 0)
                newJawData.Add(0);
        }

        writer.Write(newJawData.ToArray());

        return writer.ToArray();
    }

    public void Merge(AssetJAW asset)
    {
        foreach (var entry in asset.Entries)
        {
            Entries.RemoveAll(e => e.Sound == entry.Sound);
            Entries.Add(entry);
        }
    }
}