using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

public class ModManagerVersion
{
    [JsonInclude]
    public string Version;

    [JsonInclude]
    public string Description;

    [JsonInclude]
    public string FileName;

    [JsonConstructor]
    public ModManagerVersion()
    {
        Version = "";
        Description = "";
        FileName = "";
    }

    public ModManagerVersion(string version, string description, string fileName)
    {
        Version = version;
        Description = description;
        FileName = fileName;
    }

    public static ModManagerVersion GetCurrent() => new("v2026.02.24", "", "HeavyModManager_v2026.02.24.zip");
}