using HeavyModManager.Enum;
using HeavyModManager.Forms.Other;
using System.Text.Json.Serialization;
using System.Windows.Forms.Design;

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
    /// The currently selected platform.
    /// </summary>
    [JsonInclude]
    public GamePlatform CurrentPlatform { get; set; }

    /// <summary>
    /// The path to the Dolphin executable.
    /// </summary>
    [JsonInclude]
    public string DolphinPath { get; set; }

    [JsonInclude]
    public string XemuPath { get; set; }

    [JsonInclude]
    public string PCSX2Path { get; set; }

    [JsonInclude]
    public string DolphinFolderPath { get; set; }

    [JsonInclude]
    public string DolphinCommandLineArgs { get; set; }

    [JsonInclude]
    public string XemuCommandLineArgs { get; set; }

    [JsonInclude]
    public string PCSX2CommandLineArgs { get; set; }

    [JsonInclude]
    public string ImgBurnPath { get; set; }

    [JsonInclude]
    public bool OpenIsoAfterExport { get; set; }

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

    [JsonInclude]
    public string Language { get; set; }

    [JsonInclude]
    public SystemColorMode Theme { get; set; }

    public static string DefaultImgBurnPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "ImgBurn", "ImgBurn.exe");


    /// <summary>
    /// Initializes a new instance of the <see cref="ModManagerSettings"/> class.
    /// </summary>
    [JsonConstructor]
    public ModManagerSettings()
    {
        Version = 3;
        CurrentGame = Game.BFBB;
        CurrentPlatform = GamePlatform.GameCube;

        DolphinPath = "";
        DolphinFolderPath = "";
        XemuPath = "";
        PCSX2Path = "";
        ImgBurnPath = DefaultImgBurnPath;

        DolphinCommandLineArgs = "";
        XemuCommandLineArgs = "";
        PCSX2CommandLineArgs = "";

        OpenIsoAfterExport = true;
        CheckForUpdatesOnStartup = true;
        DeveloperMode = false;
        Icon = HeavyModManagerIcon.Rainbow;
        ColumnIndices = new List<int>();
        ColumnSizes = new List<int>();
        MainFormWidth = 1024;
        MainFormHeight = 576;
        Theme = SystemColorMode.System;
    }
}