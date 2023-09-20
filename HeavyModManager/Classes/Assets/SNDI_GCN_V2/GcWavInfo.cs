namespace HeavyModManager.Classes.Assets;

public class GcWavInfo
{
    public FSB3_SampleHeaderBasic BasicSampleHeader;
    public List<FMOD_GcADPCMInfo> GcAdpcmInfos { get; set; }

    public byte[] Data { get; set; }

    public uint _assetID;
    public byte uFlags;
    public byte uAudioSampleIndex;
    public byte uFSBIndex;
    public byte uSoundInfoIndex;

    public void SetEntryData(uint assetID, byte uFlags, byte uAudioSampleIndex, byte uFSBIndex, byte uSoundInfoIndex)
    {
        _assetID = assetID;
        this.uFlags = uFlags;
        this.uAudioSampleIndex = uAudioSampleIndex;
        this.uFSBIndex = uFSBIndex;
        this.uSoundInfoIndex = uSoundInfoIndex;
    }

    public void Serialize(EndianBinaryWriter writer)
    {
        writer.Write(_assetID);
        writer.Write(uFlags);
        writer.Write(uAudioSampleIndex);
        writer.Write(uFSBIndex);
        writer.Write(uSoundInfoIndex);
    }
}
