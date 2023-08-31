using HeavyModManager.Enum;
using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

public class ModManagerSettings
{
    [JsonInclude]
    public int version;
    [JsonInclude]
    public Game currentGame;
    [JsonInclude]
    public string dolphinPath;

    [JsonConstructor]
    public ModManagerSettings()
    {
        version = 1;
        currentGame = Game.Null;
        dolphinPath = "";
    }
}