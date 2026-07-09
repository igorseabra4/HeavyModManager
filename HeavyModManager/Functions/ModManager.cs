using GCNTools;
using HeavyModManager.Classes;
using HeavyModManager.Enum;
using HeavyModManager.Forms;
using HeavyModManager.Forms.Other;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Net;
using System.Text.Json;
using SharpCompress.Common;
using SharpCompress.Readers;
using SevenZipLib;

namespace HeavyModManager.Functions;

/// <summary>
/// Contains functions related to managing mods.
/// </summary>
public static class ModManager
{
    /// <summary>
    /// Returns the short name of a Heavy Iron game.
    /// </summary>
    /// <param name="game">The Heavy Iron game</param>
    /// <returns>The short name</returns>
    /// <exception cref="ArgumentException">If the game specified is not a valid Heavy Iron game</exception>
    public static string GameToString(Game game)
    {
        return game switch
        {
            Game.Scooby => "scooby",
            Game.BFBB => "bfbb",
            Game.Movie => "movie",
            Game.Incredibles => "incredibles",
            Game.Underminer => "rotu",
            Game.RatProto => "ratproto",
            Game.Ratatouille => "ratatouille",
            Game.WallE => "walle",
            Game.Up => "up",
            Game.TruthOrSquare => "tos",
            Game.UFC => "ufc",
            Game.FamilyGuy => "familyguy",
            Game.HollywoodWorkout => "hollywoodworkout",
            _ => throw new ArgumentException("Invalid game.", nameof(game)),
        };
    }

    public static string PlatformToExecutable(GamePlatform platform)
    {
        return platform switch
        {
            GamePlatform.GameCube => "main.dol",
            // PS2 ELF has varying names depending on game and version (region dependent)
            GamePlatform.PlayStation2 => "*.elf;*.??",
            GamePlatform.Xbox => "DEFAULT.XBE",
            _ => "",
        };
    }

    public static string PlatformToShortString(GamePlatform platform)
    {
        return platform switch
        {
            GamePlatform.GameCube => "gc",
            GamePlatform.PlayStation2 => "ps2",
            GamePlatform.Xbox => "xbox",
            _ => "",
        };
    }

    public static List<GamePlatform> SupportedPlatformsForGame(Game game)
    {
        switch (game)
        {
            case Game.Scooby:
                return new List<GamePlatform> { GamePlatform.GameCube, GamePlatform.PlayStation2, GamePlatform.Xbox };
            case Game.BFBB:
                return new List<GamePlatform> { GamePlatform.GameCube, GamePlatform.PlayStation2, GamePlatform.Xbox };
            case Game.Movie:
                return new List<GamePlatform> { GamePlatform.GameCube, GamePlatform.PlayStation2, GamePlatform.Xbox };
            case Game.Incredibles:
                return new List<GamePlatform> { GamePlatform.GameCube, GamePlatform.PlayStation2, GamePlatform.Xbox };
            case Game.Underminer:
                return new List<GamePlatform> { GamePlatform.GameCube, GamePlatform.PlayStation2, GamePlatform.Xbox };
            case Game.RatProto:
                return new List<GamePlatform> { GamePlatform.GameCube };
        }
        return new List<GamePlatform>();
    }

    /// <summary>
    /// Returns the long name of a Heavy Iron game.
    /// </summary>
    /// <param name="game">The Heavy Iron game</param>
    /// <returns>The long name</returns>
    /// <exception cref="ArgumentException">If the game specified is not a valid Heavy Iron game</exception>
    public static string GameToStringFull(Game game)
    {
        return game switch
        {
            Game.Scooby => GlobalResources.scoobyName ?? "Scooby-Doo! Night of 100 Frights",
            Game.BFBB => GlobalResources.bfbbName ?? "SpongeBob SquarePants: Battle for Bikini Bottom",
            Game.Movie => GlobalResources.tssmName ?? "The SpongeBob SquarePants Movie",
            Game.Incredibles => GlobalResources.incrediblesName ?? "The Incredibles",
            Game.Underminer => GlobalResources.rotuName ?? "The Incredibles: Rise of the Underminer",
            Game.RatProto => GlobalResources.ratProtoName ?? "Ratatouille (January 18th, 2006 Prototype)",
            Game.Ratatouille => GlobalResources.ratName ?? "Ratatouille",
            Game.WallE => GlobalResources.wallEName ?? "WALL-E",
            Game.Up => GlobalResources.upName ?? "Up",
            Game.TruthOrSquare => GlobalResources.tosName ?? "SpongeBob's Truth or Square",
            Game.UFC => GlobalResources.ufcName ?? "UFC Personal Trainer",
            Game.FamilyGuy => GlobalResources.bttmName ?? "Family Guy: Back to the Multiverse",
            Game.HollywoodWorkout => GlobalResources.hollywoodWorkoutName ?? "Harley Pasternak's Hollywood Workout",
            _ => throw new ArgumentException("Invalid game.", nameof(game)),
        };
    }

    public static string PlatformToStringFull(GamePlatform platform)
    {
        return platform switch
        {
            GamePlatform.GameCube => "GameCube",
            GamePlatform.PlayStation2 => "PlayStation 2",
            GamePlatform.Xbox => "Xbox",
            _ => "Unknown",
        };
    }

    public static string GameToGameID(Game game)
    {
        return game switch
        {
            // Note: Only the NTSC-U IDs are returned here
            // TODO: Add PAL IDs, 2-in-1 IDs etc
            Game.Scooby => "GIHE78",
            Game.BFBB => "GQPE78",
            Game.Movie => "GGVE78",
            Game.Incredibles => "GICE78",
            Game.Underminer => "GIQE78",
            Game.RatProto => "RELSAB",
            Game.WallE => "RWAU78",
            Game.Up => "RUQP78",
            Game.TruthOrSquare => "R8IE78",
            Game.UFC => "SU4P78",
            Game.HollywoodWorkout => "SAQE5G",
            _ => "Unknown",
        };
    }

    public static string GameIniFileName(Game game) => game switch
    {
        Game.Scooby => "sd2.ini",
        Game.BFBB => "sb.ini",
        Game.Movie => "SB04.ini",
        Game.Incredibles => "in.ini",
        Game.Underminer => "IN2.INI",
        Game.RatProto => "rats.ini",
        _ => "",
    };

    /// <summary>
    /// The complete list of Heavy Iron games since 2002.
    /// </summary>
    public static List<Game> Games => new() {
        Game.Scooby,
        Game.BFBB,
        Game.Movie,
        Game.Incredibles,
        Game.Underminer,
        Game.RatProto,
        Game.Ratatouille,
        Game.WallE,
        Game.Up,
        Game.TruthOrSquare,
        Game.UFC,
        Game.FamilyGuy,
        Game.HollywoodWorkout
    };

    /// <summary>
    /// The list of Heavy Iron games that use the Evil Engine.
    /// </summary>
    public static List<Game> EvilEngineGames => new() {
        Game.Scooby,
        Game.BFBB,
        Game.Movie,
        Game.Incredibles,
        Game.Underminer,
        Game.RatProto,
    };

    /// <summary>
    /// The list of Heavy Iron games that use the Good Engine.
    /// </summary>
    public static List<Game> GoodEngineGames => new() {
        Game.Ratatouille,
        Game.WallE,
        Game.Up,
        Game.TruthOrSquare,
        Game.UFC,
        Game.FamilyGuy,
        Game.HollywoodWorkout
    };

    public static string ModManagerSettingsPath => Path.Combine(Application.StartupPath, "settings.json");

    public static string ModsFolderPath => Path.Combine(Application.StartupPath, "Mods");
    public static string GetModPath(string modId) => Path.Combine(ModsFolderPath, modId);
    public static string GetModJsonPath(string modId) => Path.Combine(GetModPath(modId), "mod.json");
    public static string GetModFilesPath(string modId) => Path.Combine(GetModPath(modId), "files");

    public static string XdvdfsPath => Path.Combine(Application.StartupPath, "External", "xdvdfs", "xdvdfs.exe");

    public static string MkisofsPath => Path.Combine(Application.StartupPath, "External", "mkisofs", "mkisofs.exe");
    public static bool XdvdfsIsDownloaded => File.Exists(XdvdfsPath);

    public static bool MkisofsIsDownloaded => File.Exists(MkisofsPath);

    /// <summary>
    /// Path to game folder path for a given platform
    /// e.g. /Games/gc/bfbb/
    /// </summary>
    public static string GameFolderPath(Game game, GamePlatform platform) =>
        Path.Combine(Application.StartupPath, "Games", 
            PlatformToShortString(platform), 
            GameToString(game));
    
    /// <summary>
    /// Path to game settings file
    /// e.g. /Games/gc/bfbb/game.json
    /// </summary>
    public static string GameSettingsPath(Game game, GamePlatform platform) =>
        Path.Combine(GameFolderPath(game, platform), "game.json");

    /// <summary>
    /// Path to directory to unmodified game files
    /// e.g. /Games/gc/bfbb/backup/
    /// </summary>
    public static string GameBackupPath(Game game, GamePlatform platform) =>
        Path.Combine(GameFolderPath(game, platform), "backup");
    
    /// <summary>
    /// Path to directory containing patched game
    /// e.g. /Games/gc/bfbb/game/
    /// </summary>
    public static string GameGamePath(Game game, GamePlatform platform) =>
        Path.Combine(GameFolderPath(game, platform), "game");

    public static string GameGameFilesPath(Game game, GamePlatform platform)
    {
        return Path.Combine(GameGamePath(game, platform), platform == GamePlatform.GameCube ? "files" : "");
    }
    
    public static string GameBuildPath(Game game, GamePlatform platform) =>
        Path.Combine(GameFolderPath(game, platform), "iso");

    public static string GameGameINIPath(Game game, GamePlatform platform)
    {
        return Path.Combine(GameGamePath(game, platform), GameIniFileName(game));
    }

    public static bool EmulatorPathIsSet(GamePlatform platform)
    {
        switch (platform)
        {
            case GamePlatform.GameCube:
                return !string.IsNullOrWhiteSpace(DolphinPath);
            case GamePlatform.PlayStation2:
                return !string.IsNullOrWhiteSpace(PCSX2Path);
            case GamePlatform.Xbox:
                return !string.IsNullOrWhiteSpace(XemuPath);
            default:
                return false;
        }
    }

    public static bool CheckForUpdatesOnStartup { get; set; }
    public static bool DeveloperMode { get; set; }
    public static string DolphinPath { get; set; }
    public static string DolphinFolderPath { get; set; }

    public static string XemuPath { get; set; }

    public static string PCSX2Path { get; set; }

    public static string DolphinCommandLineArgs { get; set; }

    public static string XemuCommandLineArgs { get; set; }

    public static string PCSX2CommandLineArgs { get; set; }

    public static bool OpenIsoAfterExport { get; set; }

    public static Game CurrentGame { get; set; }
    public static GameSettings? CurrentGameSettings { get; private set; } = null;

    public static GamePlatform CurrentPlatform { get; set; } = GamePlatform.Unknown;

    private static string[] ValidThumbnailExtensions = [".png", ".jpg", ".jpeg", ".bmp", ".gif", ".tiff", ".tif"];

    public static bool ModHasImage(Mod mod)
    {

        string modPath = GetModPath(mod.ModId);

        foreach (var ext in ValidThumbnailExtensions)
        {
            string filePath = Path.Combine(modPath, $"mod{ext}");

            if (File.Exists(filePath))
                return true;
        }

        return false;
    }

    public static Bitmap? GetModImage(Mod mod)
    {
        string modPath = GetModPath(mod.ModId);

        foreach (var ext in ValidThumbnailExtensions)
        {
            string filePath = Path.Combine(modPath, $"mod{ext}");

            if (File.Exists(filePath))
                return new Bitmap(filePath);
        }

        return null;
    }

    public static void SaveSettings(ModManagerSettings settings)
    {
        settings.CurrentGame = CurrentGame;
        settings.CurrentPlatform = CurrentPlatform;
        settings.DolphinPath = DolphinPath;
        settings.DolphinFolderPath = DolphinFolderPath;
        settings.XemuPath = XemuPath;
        settings.PCSX2Path = PCSX2Path;

        settings.DolphinCommandLineArgs = DolphinCommandLineArgs;
        settings.XemuCommandLineArgs = XemuCommandLineArgs;
        settings.PCSX2CommandLineArgs = PCSX2CommandLineArgs;

        settings.CheckForUpdatesOnStartup = CheckForUpdatesOnStartup;
        settings.DeveloperMode = DeveloperMode;
        settings.Icon = IconManager.CurrentIcon;
        settings.Language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        settings.OpenIsoAfterExport = OpenIsoAfterExport;

        File.WriteAllText(ModManagerSettingsPath, JsonSerializer.Serialize(settings));
    }

    public static ModManagerSettings LoadSettings()
    {
        ModManagerSettings? settings = File.Exists(ModManagerSettingsPath) ?
             JsonSerializer.Deserialize<ModManagerSettings>(File.ReadAllText(ModManagerSettingsPath)) :
             new ModManagerSettings();

        settings ??= new ModManagerSettings();

        CurrentGame = settings.CurrentGame;
        CurrentPlatform = settings.CurrentPlatform;

        var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        var defaultDolphinPath = Path.Combine(programFiles, "Dolphin-x64", "Dolphin.exe");
        DolphinPath = (string.IsNullOrWhiteSpace(settings.DolphinPath) && File.Exists(defaultDolphinPath)) ? defaultDolphinPath : settings.DolphinPath;
        XemuPath = settings.XemuPath;
        PCSX2Path = settings.PCSX2Path;

        DolphinCommandLineArgs = settings.DolphinCommandLineArgs;
        XemuCommandLineArgs = settings.XemuCommandLineArgs;
        PCSX2CommandLineArgs = settings.PCSX2CommandLineArgs;
        OpenIsoAfterExport = settings.OpenIsoAfterExport;

        var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var defaultDolphinFolderPath = Path.Combine(documents, "Dolphin Emulator");
        DolphinFolderPath = (string.IsNullOrWhiteSpace(settings.DolphinFolderPath) && Directory.Exists(defaultDolphinFolderPath)) ? defaultDolphinFolderPath : settings.DolphinFolderPath;

        CheckForUpdatesOnStartup = settings.CheckForUpdatesOnStartup;

        if (settings.Version >= 2)
        {
            DeveloperMode = settings.DeveloperMode;
            IconManager.CurrentIcon = settings.Icon;
        }

        if (settings.Version >= 3 && settings.Language != null)
        {
            CultureInfo.CurrentCulture = new CultureInfo(settings.Language);
            CultureInfo.CurrentUICulture = new CultureInfo(settings.Language);
        }

        return settings;
    }

    public static void SetDolphinPath()
    {
        var openFile = new OpenFileDialog()
        {
            Filter = "Executables|*.exe",
            Title = "Please select your Dolphin executable"
        };

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            DolphinPath = openFile.FileName;
            // TODO: Localize!
            MessageBox.Show("Dolphin path set successfully.", "Dolphin path set", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static void SetDolphinFolderPath()
    {
        var openFile = new FolderBrowserDialog();

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            DolphinFolderPath = openFile.SelectedPath;
            // TODO: Localize!
            MessageBox.Show("Dolphin folder path set successfully.", "Dolphin folder path set", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static void SetCurrentGame(Game game)
    {
        SaveGameSettings(CurrentGame, CurrentPlatform);
        CurrentGame = game;
        RefreshGameSettings(CurrentGame, CurrentPlatform);
    }

    public static void SaveGameSettings(Game game, GamePlatform platform)
    {
        if (CurrentGame != Game.Null && CurrentGameSettings != null && platform != GamePlatform.Unknown)
        {
            if (!Directory.Exists(GameFolderPath(game, platform)))
                Directory.CreateDirectory(GameFolderPath(game, platform));

            File.WriteAllText(GameSettingsPath(game, platform), 
                JsonSerializer.Serialize(CurrentGameSettings));
        }
    }

    public static void RefreshGameSettings(Game game, GamePlatform platform)
    {
        CurrentGameSettings = File.Exists(GameSettingsPath(game, platform)) ?
            JsonSerializer.Deserialize<GameSettings>(File.ReadAllText(GameSettingsPath(game, platform))) :
            new GameSettings();

        RefreshModList();
    }

    public static void RefreshModList()
    {
        if (!Directory.Exists(ModsFolderPath))
            Directory.CreateDirectory(ModsFolderPath);

        foreach (var modFolder in Directory.GetDirectories(ModsFolderPath))
        {
            try
            {
                var modJsonPath = Path.Combine(modFolder, "mod.json");
                if (File.Exists(modJsonPath))
                {
                    var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));
                    if (mod.Game == CurrentGame)
                    {
                        CurrentGameSettings.AddMod(mod);
                    }
                }
            }
            catch
            {
            }
        }

        foreach (var modId in CurrentGameSettings.Mods.ToList())
        {
            try
            {
                var modJsonPath = GetModJsonPath(modId);
                if (!File.Exists(modJsonPath))
                {
                    CurrentGameSettings.RemoveMod(modId);
                }
            }
            catch
            {
            }
        }

        Invalidate();
    }

    public static void InstallMod()
    {
        var openFile = new OpenFileDialog()
        {
            Filter = "ZIP Archives|*.zip",
            Title = "Select one or more mod ZIPs to add",
            Multiselect = true,
        };

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            foreach (var fileName in openFile.FileNames)
                ZipManager.InstallMod(fileName);
            RefreshModList();
        }
    }

    public static void DeleteMod(string modId)
    {
        var path = GetModPath(modId);
        if (Directory.Exists(path))
            Directory.Delete(path, true);
    }

    public static bool RestoreBackupIso(string isoPath, Game game, GamePlatform platform)
    {
        if (Directory.Exists(GameBackupPath(game, platform)))
            Directory.Delete(GameBackupPath(game, platform), true);

        // TODO DON'T ASSUME GAMECUBE IMAGE!!
        GameCubeImage image;

        try
        {
            image = new GameCubeImage(isoPath);
        }
        catch (Exception ex)
        {
            // TODO: Localize!
            MessageBox.Show("Unable to read ISO: " + ex.Message, "Error reading ISO",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        Directory.CreateDirectory(GameBackupPath(game, platform));

        try
        {
            //image.Dump(GameBackupFilesPath(game, platform), GameBackupSysPath);
            throw new NotImplementedException("wehhh");
        }
        catch (Exception ex)
        {
            // TODO: Localize!
            MessageBox.Show("Unable to create backup from ISO: " + ex.Message, "Backup failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.Delete(GameBackupPath(game, platform), true);
            return false;
        }

        MessageBox.Show($"Game backup for {GameToStringFull(game)} succesfully created. You can apply mods now.",
            "Backup successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return true;
    }

    public static bool RestoreBackupFromFolder(string rootPath, Game game, GamePlatform platform)
    {
        var fs = new Microsoft.VisualBasic.Devices.Computer().FileSystem;

        if (Directory.Exists(GameBackupPath(game, platform)))
            Directory.Delete(GameBackupPath(game, platform), true);

        // Create backup directory
        Directory.CreateDirectory(GameBackupPath(game, platform));

        // We only care about these paths if it's a GC backup
        if (platform == GamePlatform.GameCube)
        {
            var files = Path.Combine(rootPath, "files");
            var sys = Path.Combine(rootPath, "sys");

            if (!Directory.Exists(files))
            {
                return false;
            }
            
            if (!Directory.Exists(sys))
            {
                return false;
            }

            // Create files and sys folders
            string destFilesPath = Path.Combine(GameBackupPath(game, platform), "files");
            string destSysPath = Path.Combine(GameBackupPath(game, platform), "sys");

            Directory.CreateDirectory(destFilesPath);
            Directory.CreateDirectory(destSysPath);

            fs.CopyDirectory(files, destFilesPath);
            fs.CopyDirectory(sys, destSysPath);
        }
        else
        {
            fs.CopyDirectory(rootPath, GameBackupPath(game, platform));
        }

        return true;
    }

    public static void Invalidate()
    {
        // FIXME: Crashes when a game is not selected.

        CurrentGameSettings.Invalidated = true;
        SaveGameSettings(CurrentGame, CurrentPlatform);
    }

    public static bool ResetGameFromBackup(Game game, GamePlatform platform)
    {
        if (!GameBackupExists(game, platform))
        {
            // TODO: Localize!
            MessageBox.Show("Unable to perform action: game backup not found. Please create the game's backup first.",
                "Game backup not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        var fs = new Microsoft.VisualBasic.Devices.Computer().FileSystem;

        if (Directory.Exists(GameGamePath(game, platform)))
            Directory.Delete(GameGamePath(game, platform), true);

        Directory.CreateDirectory(GameGamePath(game, platform));
        fs.CopyDirectory(GameBackupPath(game, platform), GameGamePath(game, platform));

        return true;
    }

    public static void ApplyMods(Game game, GamePlatform platform)
    {
        if (!Directory.Exists(GameGamePath(game, platform)) && !ResetGameFromBackup(game, platform))
            return;

        if (!DeveloperMode && !CurrentGameSettings.Invalidated)
            return;

        // var dol = File.ReadAllBytes(GameDolPath);
        var hasDolPatches = false;

        var arCodes = new List<DolphinCode>();
        var geckoCodes = new List<DolphinCode>();

        var modsUsingCustomGameId = 0;
        string? gameId = null;

        foreach (var modId in CurrentGameSettings.Mods)
            if (CurrentGameSettings.ActiveMods.Contains(modId))
            {
                var modJsonPath = GetModJsonPath(modId);
                var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));

                mod.RemoveRemoveFiles();
                mod.CopyFiles();
                mod.ApplyIniPatches();

                // if (mod.ApplyIPSPatch(ref dol) | mod.ApplyDolPatches(ref dol))
                //     hasDolPatches = true;

                if (!string.IsNullOrEmpty(mod.ArCodes))
                    AddOrReplaceCodes(ref arCodes, mod.GetArCodes());

                if (!string.IsNullOrEmpty(mod.GeckoCodes))
                    AddOrReplaceCodes(ref geckoCodes, mod.GetGeckoCodes());

                if (!string.IsNullOrWhiteSpace(mod.GameId))
                {
                    gameId = mod.GameId;
                    modsUsingCustomGameId++;
                }
            }

        if (gameId == null && (arCodes.Any() || geckoCodes.Any()))
            gameId = GetDefaultCodesGameId();

        if (gameId != null)
        {
            CreateCustomDolphinSettings(gameId, arCodes, geckoCodes);
            CopyDolphinSysSettings(gameId);

            hasDolPatches = true;

            // ApplyGameIdOnDol(gameId, ref dol);
            //ApplyGameIdOnBootBin(gameId);
        }

        if (hasDolPatches)
            // File.WriteAllBytes(GameDolPath, dol);

        CurrentGameSettings.Invalidated = false;
        SaveGameSettings(game, platform);

        if (modsUsingCustomGameId > 1)
            MessageBox.Show(GlobalResources.multipleModsSaveFiles, GlobalResources.multipleModsSaveFilesTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private static void AddOrReplaceCodes(ref List<DolphinCode> codeList, List<DolphinCode> toAdd)
    {
        foreach (var code in toAdd)
        {
            codeList.RemoveAll(c => c.Name == code.Name);
            if (string.IsNullOrWhiteSpace(code.Name))
                code.Name = "code_" + code.GetHashCode().ToString();
            code.Enabled = true;
            codeList.Add(code);
        }
    }

    private static string GetDefaultCodesGameId()
    {
        var strBuilder = new System.Text.StringBuilder(GameToGameID(CurrentGame));
        strBuilder[3] = 'H';
        return strBuilder.ToString();
    }

    public static string GameDolphinSettingsPath(string gameId) => Path.Combine(DolphinFolderPath, "GameSettings", gameId + ".ini");

    public static string DolphinExecutableFolderPath => Path.GetDirectoryName(DolphinPath) ?? string.Empty;

    public static string GameDolphinSysSettingsPath(string gameId) => Path.Combine(DolphinExecutableFolderPath, "Sys", "GameSettings", gameId + ".ini");

    private static void CreateCustomDolphinSettings(string destinationGameId, List<DolphinCode> arCodes, List<DolphinCode> geckoCodes)
    {
        DolphinGameSettings dolphinSettings;
        var originalDolphinSettingsPath = GameDolphinSettingsPath(GameToGameID(CurrentGame));

        try
        {
            dolphinSettings = DolphinGameSettings.FromPath(originalDolphinSettingsPath);
        }
        catch
        {
            MessageBox.Show("There was an error reading the Dolphin settings. Existing settings will not be applied to the mod.", "Error reading Dolphin settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dolphinSettings = DolphinGameSettings.FromContents("");
        }

        dolphinSettings.Core["EnableCheats"] = "True";

        dolphinSettings.ActionReplay.RemoveAll(c => c.Enabled == false);
        dolphinSettings.ActionReplay.AddRange(arCodes);

        dolphinSettings.Gecko.RemoveAll(c => c.Enabled == false);
        dolphinSettings.Gecko.AddRange(geckoCodes);

        var newDolphinSettingsPath = GameDolphinSettingsPath(destinationGameId);
        var dir = Path.GetDirectoryName(newDolphinSettingsPath);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        dolphinSettings.SaveTo(newDolphinSettingsPath);
    }

    private static void CopyDolphinSysSettings(string destinationGameId)
    {
        var originalFile = GameDolphinSysSettingsPath(GameToGameID(CurrentGame));
        if (File.Exists(originalFile))
            File.Copy(originalFile, GameDolphinSysSettingsPath(destinationGameId), true);
    }

    private static void ApplyGameIdOnDol(string gameId, ref byte[] dol)
    {
        switch (CurrentGame)
        {
            case Game.Scooby:
                WriteGameIdOnDol(ref dol, 0x1DC820, gameId);
                dol[0x1DC828] = (byte)gameId[4];
                dol[0x1DC829] = (byte)gameId[5];
                break;
            case Game.BFBB:
                WriteGameIdOnDol(ref dol, 0x2635C0, gameId);
                dol[0x2635C5] = (byte)gameId[4];
                dol[0x2635C6] = (byte)gameId[5];
                break;
            case Game.Movie:
                WriteGameIdOnDol(ref dol, 0x374CE8, gameId);
                WriteGameIdOnDol(ref dol, 0x3752BF, gameId);
                WriteGameIdOnDol(ref dol, 0x3752C4, gameId);
                WriteGameIdOnDol(ref dol, 0x3752C9, gameId);
                WriteGameIdOnDol(ref dol, 0x3752CE, gameId);
                dol[0x3752D3] = (byte)gameId[4];
                dol[0x3752D4] = (byte)gameId[5];
                WriteGameIdOnDol(ref dol, 0x3754F8, gameId);
                break;
            case Game.Incredibles:
                WriteGameIdOnDol(ref dol, 0x2D5878, gameId);
                WriteGameIdOnDol(ref dol, 0x2DAFF8, gameId);
                break;
            case Game.Underminer:
                WriteGameIdOnDol(ref dol, 0x2C8E19, gameId);
                WriteGameIdOnDol(ref dol, 0x2C8E1E, gameId);
                WriteGameIdOnDol(ref dol, 0x2C8E23, gameId);
                break;
            default:
                throw new NotImplementedException("Cannot change game ID for this game yet.");
        }
    }

    private static void WriteGameIdOnDol(ref byte[] dol, int startOffset, string gameId, int amount = 4)
    {
        for (int i = 0; i < amount; i++)
            dol[startOffset + i] = (byte)gameId[i];
    }

    // private static void ApplyGameIdOnBootBin(string gameId)
    // {
    //     var bootBinPath = Path.Combine(GameGameSysPath, "boot.bin");
    //     var bootBin = File.ReadAllBytes(bootBinPath);
    //
    //     bootBin[0] = (byte)gameId[0];
    //     bootBin[1] = (byte)gameId[1];
    //     bootBin[2] = (byte)gameId[2];
    //     bootBin[3] = (byte)gameId[3];
    //     bootBin[4] = (byte)gameId[4];
    //     bootBin[5] = (byte)gameId[5];
    //
    //     File.WriteAllBytes(bootBinPath, bootBin);
    // }

    public static bool GameBackupExists(Game game, GamePlatform platform)
    {
        var path = GameBackupPath(game, platform);

        return Directory.Exists(path) &&
               Directory.EnumerateFileSystemEntries(path).Any();
    }
    
    public static bool GameExists(Game game, GamePlatform platform)
    {
        var path = GameGamePath(game, platform);

        return Directory.Exists(path) &&
               Directory.EnumerateFileSystemEntries(path).Any();
    }

    public static void CloseEmulator()
    {
        // TODO handle other emulators
        foreach (var p in Process.GetProcessesByName("Dolphin"))
            if (!p.HasExited)
            {
                p.CloseMainWindow();
            }
    }

    /// <summary>
    /// Runs the current patched game with the emulator
    /// </summary>
    public static async Task<SaveIsoResult> RunGameAsync(Game game, GamePlatform platform)
    {
        string emulatorPath = "";
        
        switch (platform)
        {
            case GamePlatform.GameCube:
                emulatorPath = DolphinPath;
                break;
            case GamePlatform.PlayStation2:
                emulatorPath = PCSX2Path;
                break;
            case GamePlatform.Xbox:
                emulatorPath = XemuPath;
                break;
        }

        if (String.IsNullOrEmpty(emulatorPath))
        {
            return SaveIsoResult.EmulatorNotFound;
        }
        
        string runPath = GameGamePath(game, platform);

        if (platform != GamePlatform.GameCube)
        {
            // Need to build iso
            if (!Path.Exists(GameBuildPath(game, platform)))
                Directory.CreateDirectory(GameBuildPath(game, platform));
                
            runPath = Path.Combine(GameBuildPath(game, platform), "game.iso");
            
            // If iso exists already, delete it
            if (File.Exists(runPath))
                File.Delete(runPath);
            
            var result = await SaveISOAsync(runPath, game, platform);

            if (result == SaveIsoResult.MissingXdvdfs)
                return SaveIsoResult.MissingXdvdfs;

            if (result == SaveIsoResult.MissingMkisofs)
                return SaveIsoResult.MissingMkisofs;
        }
        
        string extraArgs = GetCommandLineArguments(platform); // may be empty

        var startInfo = new ProcessStartInfo
        {
            FileName = emulatorPath,
            UseShellExecute = false // required if you want to redirect output or avoid shell quoting issues
        };

        // Add extra arguments if any
        if (!string.IsNullOrWhiteSpace(extraArgs))
        {
            foreach (var arg in extraArgs.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                startInfo.ArgumentList.Add(arg);
        }

        // Always add the game path last
        // Add platform-specific arguments
        if (platform == GamePlatform.Xbox)
        {
            startInfo.ArgumentList.Add("-dvd_path");
            startInfo.ArgumentList.Add(runPath);
        }
        else
        {
            // Other platforms just pass the game path
            startInfo.ArgumentList.Add(runPath);
        }

        // Start the emulator
        Process.Start(startInfo);

        return SaveIsoResult.Success;
    }

    private static string GetCommandLineArguments(GamePlatform platform)
    {
        switch (platform)
        {
            case GamePlatform.GameCube:
                return DolphinCommandLineArgs;
            case GamePlatform.PlayStation2:
                return PCSX2CommandLineArgs;
            case GamePlatform.Xbox:
                return XemuCommandLineArgs;
            default:
                return "";
        }
    }

    public enum SaveIsoResult
    {
        Success,
        MissingXdvdfs,
        MissingMkisofs,
        EmulatorNotFound
    }

    public static async Task<SaveIsoResult> SaveISOAsync(string path, Game game, GamePlatform platform)
    {
        switch (platform)
        {
            case GamePlatform.GameCube:
                DiscImage.CreateFile(GameGamePath(game, platform), path);
                break;
            case GamePlatform.PlayStation2:
                {
                    if (!MkisofsIsDownloaded)
                        return SaveIsoResult.MissingMkisofs;

                    var psiPs2 = new ProcessStartInfo
                    {
                        FileName = MkisofsPath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    };

                    psiPs2.ArgumentList.Add("-udf");
                    psiPs2.ArgumentList.Add("-o");
                    psiPs2.ArgumentList.Add(path);
                    psiPs2.ArgumentList.Add(GameGamePath(game, platform));

                    using var processPs2 = Process.Start(psiPs2)!;

                    Task<string> outputTask = processPs2.StandardOutput.ReadToEndAsync();
                    Task<string> errorTask = processPs2.StandardError.ReadToEndAsync();

                    await processPs2.WaitForExitAsync();

                    string outputPs2 = await outputTask;
                    string errorPs2 = await errorTask;

                    if (processPs2.ExitCode != 0)
                        throw new Exception($"Error creating PS2 ISO (exit code {processPs2.ExitCode}): {errorPs2}");

                    break;
                }
            case GamePlatform.Xbox:
                {
                    if (!XdvdfsIsDownloaded)
                        return SaveIsoResult.MissingXdvdfs;

                    var psi = new ProcessStartInfo
                    {
                        FileName = XdvdfsPath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    };

                    psi.ArgumentList.Add("pack");
                    psi.ArgumentList.Add(GameGamePath(game, platform)); // in
                    psi.ArgumentList.Add(path); // out

                    using var process = Process.Start(psi);

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(error))
                        throw new Exception("Error creating Xbox ISO: " + error);

                    break;
                }
        }
        return SaveIsoResult.Success;
    }

    /// <summary>
    /// Opens the settings.json file in the default text editor.
    /// </summary>
    public static void OpenSettingsFile()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = ModManagerSettingsPath,
            UseShellExecute = true
        });
    }

    /// <summary>
    /// Gets the size of a directory and all its subdirectories.
    /// </summary>
    public static long GetDirectorySize(string path)
    {
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException($"Directory not found: {path}");

        return Directory
            .EnumerateFiles(path, "*", SearchOption.AllDirectories)
            .Sum(file =>
            {
                try
                {
                    return new FileInfo(file).Length;
                }
                catch
                {
                    return 0L;
                }
            });
    }

    /// <summary>
    /// Formats a file size in bytes into a human-readable string in kibibytes, mebibytes, etc.
    /// </summary>
    public static string GetFormattedSize(long bytes)
    {
        string[] sizes = { "B", "KiB", "MiB", "GiB", "TiB" };
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len /= 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }

    private static void ForceDeleteDirectory(string path)
    {
        var dirInfo = new DirectoryInfo(path);
        ClearAttributesRecursive(dirInfo);
        Directory.Delete(path, true);
    }

    private static void ClearAttributesRecursive(DirectoryInfo dir)
    {
        dir.Attributes = FileAttributes.Normal;

        foreach (var subDir in dir.GetDirectories())
            ClearAttributesRecursive(subDir);

        foreach (var file in dir.GetFiles())
            file.Attributes = FileAttributes.Normal;
    }

    public static async Task DownloadAndExtractMkisofs()
    {
        string baseDir = Path.Combine(Application.StartupPath, "External", "mkisofs");
        Directory.CreateDirectory(baseDir);

        string rarPath = Path.Combine(baseDir, "cdrtools.rar");

        string url = "https://sourceforge.net/projects/cdrtfe/files/tools/binaries/cdrtools/cdrtools-3.02a10-bin-win32-patched.rar/download";

        // 1. Download with manual redirect handling (like curl -L)
        while (true)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.AllowAutoRedirect = false; // IMPORTANT
            request.Accept = "*/*";
            request.KeepAlive = true;

            using var response = (HttpWebResponse)await request.GetResponseAsync();

            // Handle redirect manually
            if ((int)response.StatusCode >= 300 && (int)response.StatusCode < 400)
            {
                string? location = response.Headers["Location"];
                if (string.IsNullOrEmpty(location))
                    throw new Exception("Redirect with no location");

                // Handle relative redirects
                if (!location.StartsWith("http"))
                {
                    var baseUri = new Uri(url);
                    location = new Uri(baseUri, location).ToString();
                }

                url = location;
                continue;
            }

            // Final response → save file
            using (var responseStream = response.GetResponseStream())
            using (var fileStream = new FileStream(rarPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await responseStream.CopyToAsync(fileStream);
            }

            break;
        }

        // 2. Extract
        SevenZipLib.SevenZip.ExtractToDir(rarPath, Path.GetDirectoryName(MkisofsPath));

        if (File.Exists(MkisofsPath))
        {
            // Delete other files except mkisofs.exe
            foreach (var file in Directory.GetFiles(Path.GetDirectoryName(MkisofsPath)))
            {
                if (!file.EndsWith("mkisofs.exe", StringComparison.OrdinalIgnoreCase))
                {
                    File.Delete(file);
                }
            }
            // Delete folders
            foreach (var dir in Directory.GetDirectories(Path.GetDirectoryName(MkisofsPath)))
            {
                ForceDeleteDirectory(dir);
            }
        }

        // Download cygwin1.dll
        var cygwinDllUrl = "https://raw.githubusercontent.com/FormLink/cygwin-files/master/cygwin1.dll";
        // Download and put in same folder as mkisofs

        string outputPath = Path.Combine(Path.GetDirectoryName(MkisofsPath), "cygwin1.dll");

        using HttpClient client = new HttpClient();
        byte[] fileBytes = await client.GetByteArrayAsync(cygwinDllUrl);
        await File.WriteAllBytesAsync(outputPath, fileBytes);
    }

    public static async Task DownloadLatestXdvdfsAsync()
    {
        string apiUrl = "https://api.github.com/repos/antangelo/xdvdfs/releases/latest";

        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("HeavyModManager");

        // Get release metadata
        string json = await client.GetStringAsync(apiUrl);
        using JsonDocument doc = JsonDocument.Parse(json);

        var assets = doc.RootElement.GetProperty("assets");

        string downloadUrl = null;

        foreach (var asset in assets.EnumerateArray())
        {
            string name = asset.GetProperty("name").GetString();

            if (name.StartsWith("xdvdfs-windows") && name.EndsWith(".zip"))
            {
                downloadUrl = asset.GetProperty("browser_download_url").GetString();
                break;
            }
        }

        if (downloadUrl == null)
            throw new Exception("Could not find Windows xdvdfs release.");

        string exePath = XdvdfsPath;
        string dir = Path.GetDirectoryName(exePath);

        Directory.CreateDirectory(dir);

        string zipPath = Path.Combine(dir, "xdvdfs.zip");

        // Download zip
        using (var response = await client.GetAsync(downloadUrl))
        {
            response.EnsureSuccessStatusCode();

            using var fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write);
            await response.Content.CopyToAsync(fs);
        }

        // Extract zip
        using (var archive = ZipFile.OpenRead(zipPath))
        {
            foreach (var entry in archive.Entries)
            {
                if (entry.Name.Equals("xdvdfs.exe", StringComparison.OrdinalIgnoreCase))
                {
                    entry.ExtractToFile(exePath, true);
                    break;
                }
            }
        }

        File.Delete(zipPath);
    }

    public static int MigrateLegacyMods(List<string> modDirectories)
    {
        int numMigrated = 0;

        foreach(var modDirectory in modDirectories)
        {
            bool result = MigrateLegacyMod(modDirectory);

            if (result)
                numMigrated++;
        }

        return numMigrated;
    }

    private static bool MigrateLegacyMod(string modDirectory, GamePlatform platform = GamePlatform.GameCube)
    {
        // To migrate a legacy mod, do the following:
        // Deserialize mod.json, set its Platform to the platform parameter (default to GameCube), then serialize the mod.json back.

        string modJsonPath = Path.Combine(modDirectory, "mod.json");

        // If mod.json doesn't exist, return false
        if (!File.Exists(modJsonPath))
            return false;

        var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));

        mod.Platform = platform;

        // Serialize
        mod.SaveModJson(false);

        return true;
    }

    public static List<string> GetLegacyModDirectories()
    {
        // On startup, check for mods in old format (don't contain a Platform in mod.json)

        string modsDir = ModsFolderPath;

        // Check every folder in modsDir
        // Check if mod.json exists. If it does, check if it contains a Platform property. If it doesn't, it's a legacy mod.

        if (!Directory.Exists(modsDir))
            return [];

        var modDirectories = new List<string>();

        foreach (var modFolder in Directory.GetDirectories(modsDir))
        {
            var modJsonPath = Path.Combine(modFolder, "mod.json");
            if (File.Exists(modJsonPath))
            {
                try
                {
                    var json = File.ReadAllText(modJsonPath);
                    using var doc = JsonDocument.Parse(json);
                    if (!doc.RootElement.TryGetProperty("Platform", out _))
                    {
                        modDirectories.Add(modFolder);
                    }
                }
                catch
                {
                    // If there's an error reading/parsing the file, ignore it and move on to the next
                }
            }
        }

        return modDirectories;
    }
}