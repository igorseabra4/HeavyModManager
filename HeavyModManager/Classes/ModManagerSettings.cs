using HeavyModManager.Enum;
using HeavyModManager.Forms.Other;
using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

/// <summary>
/// Holds the settings for the mod manager application.
/// </summary>
public class ModManagerSettings
{
    /// <summary>
    /// The version of the settings file.
    /// </summary>
    [JsonInclude]
    public int Version { get; set; }

    /// <summary>
    /// The currently selected game.
    /// </summary>
    [JsonInclude]
    public Game CurrentGame { get; set; }

    /// <summary>
    /// The path to the Dolphin executable.
    /// </summary>
    [JsonInclude]
    public string DolphinPath { get; set; }

    /// <summary>
    /// Whether the application checks for updates on startup.
    /// </summary>
    [JsonInclude]
    public bool CheckForUpdatesOnStartup { get; set; }

    /// <summary>
    /// Whether the application is on Developer Mode.
    /// </summary>
    [JsonInclude]
    public bool DeveloperMode { get; set; }

    [JsonInclude]
    public HeavyModManagerIcon Icon { get; set; }

    [JsonInclude]
    public List<int> ColumnIndices { get; set; }

    [JsonInclude]
    public List<int> ColumnSizes { get; set; }

    [JsonInclude]
    public int MainFormWidth { get; set; }

    [JsonInclude]
    public int MainFormHeight { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ModManagerSettings"/> class.
    /// </summary>
    [JsonConstructor]
    public ModManagerSettings()
    {
        Version = 2;
        CurrentGame = Game.Null;
        DolphinPath = "";
        CheckForUpdatesOnStartup = true;
        DeveloperMode = false;
        Icon = HeavyModManagerIcon.Rainbow;
        ColumnIndices = new List<int>();
        ColumnSizes = new List<int>();
        MainFormWidth = 738;
        MainFormHeight = 474;
    }
}