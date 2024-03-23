using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

public class ModManagerVersion
{
    [JsonInclude]
    public string Version;

    [JsonInclude]
    public string Description;

    [JsonConstructor]
    public ModManagerVersion()
    {
        Version = "";
        Description = "";
    }

    public ModManagerVersion(string version, string description)
    {
        Version = version;
        Description = description;
    }

    public static ModManagerVersion GetCurrent() => new("v2024.03.23", "");
}