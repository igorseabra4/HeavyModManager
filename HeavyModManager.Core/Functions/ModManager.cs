using GCNTools;
using HeavyModManager.Core.Classes;
using HeavyModManager.Core.Enum;
using HeavyModManager.Core.Platform;
using HeavyModManager.Core.Services;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace HeavyModManager.Core.Functions;

/// <summary>
/// Contains functions related to managing mods.
/// </summary>
public static class ModManager
{
    private static string _baseDirectory = AppContext.BaseDirectory;
    public static string BaseDirectory
    {
        get => _baseDirectory;
        set => _baseDirectory = value;
    }

    public static IPlatformService Platform => PlatformService.Instance;
    public static IDialogService Dialogs { get; set; } = new NullDialogService();

    /// <summary>
    /// Returns the short name of a Heavy Iron game.
    /// </summary>
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

    /// <summary>
    /// Returns the abbreviated name of a Heavy Iron game.
    /// </summary>
    public static string GameToStringAbbreviated(Game game)
    {
        return game switch
        {
            Game.Scooby => "ScoobyN100F",
            Game.BFBB => "BFBB",
            Game.Movie => "TSSM",
            Game.Incredibles => "Incredibles",
            Game.Underminer => "ROTU",
            Game.RatProto => "RatProto",
            Game.Ratatouille => "Ratatouille",
            Game.WallE => "WALLE",
            Game.Up => "Up",
            Game.TruthOrSquare => "TOS",
            Game.UFC => "UFCPT",
            Game.FamilyGuy => "FamilyGuy",
            Game.HollywoodWorkout => "HollywoodWorkout",
            _ => throw new ArgumentException("Invalid game.", nameof(game)),
        };
    }

    /// <summary>
    /// Returns the long name of a Heavy Iron game.
    /// </summary>
    public static string GameToStringFull(Game game)
    {
        return game switch
        {
            Game.Scooby => "Scooby-Doo! Night of 100 Frights",
            Game.BFBB => "SpongeBob SquarePants: Battle for Bikini Bottom",
            Game.Movie => "The SpongeBob SquarePants Movie",
            Game.Incredibles => "The Incredibles",
            Game.Underminer => "The Incredibles: Rise of the Underminer",
            Game.RatProto => "Ratatouille (January 18th, 2006 Prototype)",
            Game.Ratatouille => "Ratatouille",
            Game.WallE => "WALL-E",
            Game.Up => "Up",
            Game.TruthOrSquare => "SpongeBob's Truth or Square",
            Game.UFC => "UFC Personal Trainer",
            Game.FamilyGuy => "Family Guy: Back to the Multiverse",
            Game.HollywoodWorkout => "Harley Pasternak's Hollywood Workout",
            _ => throw new ArgumentException("Invalid game.", nameof(game)),
        };
    }

    public static string GameToGameID(Game game)
    {
        return game switch
        {
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

    public static List<Game> EvilEngineGames => new() {
        Game.Scooby,
        Game.BFBB,
        Game.Movie,
        Game.Incredibles,
        Game.Underminer,
        Game.RatProto,
    };

    public static List<Game> GoodEngineGames => new() {
        Game.Ratatouille,
        Game.WallE,
        Game.Up,
        Game.TruthOrSquare,
        Game.UFC,
        Game.FamilyGuy,
        Game.HollywoodWorkout
    };

    public static string ModManagerSettingsPath => Path.Combine(BaseDirectory, "settings.json");

    public static string ModsFolderPath => Path.Combine(BaseDirectory, "Mods");
    public static string GetModPath(string modId) => Path.Combine(ModsFolderPath, modId);
    public static string GetModJsonPath(string modId) => Path.Combine(GetModPath(modId), "mod.json");
    public static string GetModFilesPath(string modId) => Path.Combine(GetModPath(modId), "files");

    public static string GameFolderPath => Path.Combine(BaseDirectory, "Games", "gc", GameToString(CurrentGame));
    public static string GameSettingsPath => Path.Combine(GameFolderPath, "game.json");

    public static string GameBackupPath => Path.Combine(GameFolderPath, "backup");
    public static string GameBackupFilesPath => Path.Combine(GameBackupPath, "files");
    public static string GameBackupSysPath => Path.Combine(GameBackupPath, "sys");

    public static string GameGamePath => Path.Combine(GameFolderPath, "game");
    public static string GameGameFilesPath => Path.Combine(GameGamePath, "files");
    public static string GameGameSysPath => Path.Combine(GameGamePath, "sys");
    public static string GameDolPath => Path.Combine(GameGameSysPath, "main.dol");
    public static string GameGameINIPath => Path.Combine(GameGameFilesPath, GameIniFileName(CurrentGame));

    public static bool CheckForUpdatesOnStartup { get; set; }
    public static bool DeveloperMode { get; set; }
    public static string DolphinPath { get; set; } = "";
    public static string DolphinFolderPath { get; set; } = "";
    public static Game CurrentGame { get; private set; }
    public static GameSettings? CurrentGameSettings { get; private set; } = null;
    public static HeavyModManagerIcon CurrentIcon { get; set; } = HeavyModManagerIcon.Rainbow;
    public static AppTheme CurrentTheme { get; set; } = AppTheme.System;

    public static void SaveSettings(ModManagerSettings settings)
    {
        settings.CurrentGame = CurrentGame;
        settings.DolphinPath = DolphinPath;
        settings.DolphinFolderPath = DolphinFolderPath;
        settings.CheckForUpdatesOnStartup = CheckForUpdatesOnStartup;
        settings.DeveloperMode = DeveloperMode;
        settings.Icon = CurrentIcon;
        settings.Theme = CurrentTheme;
        settings.Language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        File.WriteAllText(ModManagerSettingsPath, JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));
    }

    public static ModManagerSettings LoadSettings()
    {
        ModManagerSettings? settings = null;
        if (File.Exists(ModManagerSettingsPath))
        {
            try
            {
                settings = JsonSerializer.Deserialize<ModManagerSettings>(File.ReadAllText(ModManagerSettingsPath));
            }
            catch { }
        }

        settings ??= new ModManagerSettings();

        CurrentGame = settings.CurrentGame;

        // Auto-detect default Dolphin executable
        var defaultDolphin = Platform.DefaultDolphinExecutablePath;
        if (string.IsNullOrWhiteSpace(settings.DolphinPath))
        {
            DolphinPath = (File.Exists(defaultDolphin) || Directory.Exists(defaultDolphin)) ? defaultDolphin : "";
        }
        else
        {
            DolphinPath = settings.DolphinPath;
        }

        // Auto-detect default Dolphin user folder
        var defaultDolphinFolder = Platform.DefaultDolphinFolderPath;
        if (string.IsNullOrWhiteSpace(settings.DolphinFolderPath))
        {
            DolphinFolderPath = Directory.Exists(defaultDolphinFolder) ? defaultDolphinFolder : "";
        }
        else
        {
            DolphinFolderPath = settings.DolphinFolderPath;
        }

        CheckForUpdatesOnStartup = settings.CheckForUpdatesOnStartup;
        DeveloperMode = settings.DeveloperMode;
        CurrentIcon = settings.Icon;
        CurrentTheme = settings.Theme;

        if (!string.IsNullOrEmpty(settings.Language))
        {
            try
            {
                CultureInfo.CurrentCulture = new CultureInfo(settings.Language);
                CultureInfo.CurrentUICulture = new CultureInfo(settings.Language);
            }
            catch { }
        }

        return settings;
    }

    public static void SetCurrentGame(Game game)
    {
        SaveGameSettings();
        CurrentGame = game;
        RefreshGameSettings();
    }

    public static void SaveGameSettings()
    {
        if (CurrentGame != Game.Null && CurrentGameSettings != null)
        {
            if (!Directory.Exists(GameFolderPath))
                Directory.CreateDirectory(GameFolderPath);

            File.WriteAllText(GameSettingsPath, JsonSerializer.Serialize(CurrentGameSettings, new JsonSerializerOptions { WriteIndented = true }));
        }
    }

    public static void RefreshGameSettings()
    {
        CurrentGameSettings = null;
        if (File.Exists(GameSettingsPath))
        {
            try
            {
                CurrentGameSettings = JsonSerializer.Deserialize<GameSettings>(File.ReadAllText(GameSettingsPath));
            }
            catch { }
        }

        CurrentGameSettings ??= new GameSettings();
        RefreshModList();
    }

    public static void RefreshModList()
    {
        if (CurrentGameSettings == null)
            return;

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
                    if (mod != null && mod.Game == CurrentGame)
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

    public static void DeleteMod(string modId)
    {
        var path = GetModPath(modId);
        if (Directory.Exists(path))
            Directory.Delete(path, true);
    }

    public static string? LastError { get; set; }

    public static async Task<bool> RestoreBackupIsoAsync(string isoPath, IProgress<int>? progress = null, bool showDialog = true)
    {
        LastError = null;
        if (Directory.Exists(GameBackupPath))
            Directory.Delete(GameBackupPath, true);

        GameCubeImage image;

        try
        {
            image = new GameCubeImage(isoPath);
        }
        catch (Exception ex)
        {
            LastError = "Unable to read ISO: " + ex.Message;
            if (showDialog)
                await Dialogs.ShowErrorAsync("Error reading ISO", LastError);
            return false;
        }

        Directory.CreateDirectory(GameBackupPath);
        Directory.CreateDirectory(GameBackupFilesPath);
        Directory.CreateDirectory(GameBackupSysPath);

        try
        {
            image.Dump(GameBackupFilesPath, GameBackupSysPath, progress);
        }
        catch (Exception ex)
        {
            LastError = "Unable to create backup from ISO: " + ex.Message;
            if (showDialog)
                await Dialogs.ShowErrorAsync("Backup failed", LastError);
            if (Directory.Exists(GameBackupPath))
                Directory.Delete(GameBackupPath, true);
            return false;
        }

        if (showDialog)
        {
            await Dialogs.ShowInfoAsync("Backup successful",
                $"Game backup for {GameToStringFull(CurrentGame)} successfully created. You can apply mods now.");
        }
        return true;
    }

    public static async Task<bool> RestoreBackupFolderAsync(string rootPath, bool showDialog = true)
    {
        LastError = null;
        var files = Path.Combine(rootPath, "files");
        if (!Directory.Exists(files))
        {
            LastError = "Unable to create backup: 'files' directory not found. Are you sure you are using a proper ISO dump?";
            if (showDialog)
                await Dialogs.ShowErrorAsync("Backup failed", LastError);
            return false;
        }

        var sys = Path.Combine(rootPath, "sys");
        if (!Directory.Exists(sys))
        {
            LastError = "Unable to create backup: 'sys' directory not found. Are you sure you are using a proper ISO dump?";
            if (showDialog)
                await Dialogs.ShowErrorAsync("Backup failed", LastError);
            return false;
        }

        if (Directory.Exists(GameBackupPath))
            Directory.Delete(GameBackupPath, true);

        Directory.CreateDirectory(GameBackupPath);
        Directory.CreateDirectory(GameBackupFilesPath);
        Directory.CreateDirectory(GameBackupSysPath);

        Platform.CopyDirectory(files, GameBackupFilesPath);
        Platform.CopyDirectory(sys, GameBackupSysPath);

        if (showDialog)
        {
            await Dialogs.ShowInfoAsync("Backup successful",
                $"Game backup for {GameToStringFull(CurrentGame)} successfully created. You can apply mods now.");
        }
        return true;
    }

    public static void Invalidate()
    {
        if (CurrentGameSettings != null)
        {
            CurrentGameSettings.Invalidated = true;
            SaveGameSettings();
        }
    }

    public static bool ResetGameFromBackup()
    {
        if (!GameBackupExists)
        {
            Dialogs.ShowErrorAsync("Game backup not found",
                "Unable to perform action: game backup not found. Please create the game's backup first.");
            return false;
        }

        if (Directory.Exists(GameGamePath))
            Directory.Delete(GameGamePath, true);

        Directory.CreateDirectory(GameGamePath);
        Directory.CreateDirectory(GameGameFilesPath);
        Directory.CreateDirectory(GameGameSysPath);

        Platform.CopyDirectory(GameBackupFilesPath, GameGameFilesPath);
        Platform.CopyDirectory(GameBackupSysPath, GameGameSysPath);

        return true;
    }

    public static async Task ApplyModsAsync()
    {
        if (CurrentGameSettings == null)
            return;

        if (!Directory.Exists(GameGamePath) && !ResetGameFromBackup())
            return;

        if (!DeveloperMode && !CurrentGameSettings.Invalidated)
            return;

        var dol = File.ReadAllBytes(GameDolPath);
        var hasDolPatches = false;

        var arCodes = new List<DolphinCode>();
        var geckoCodes = new List<DolphinCode>();

        var modsUsingCustomGameId = 0;
        string? gameId = null;

        foreach (var modId in CurrentGameSettings.Mods)
        {
            if (CurrentGameSettings.ActiveMods.Contains(modId))
            {
                var modJsonPath = GetModJsonPath(modId);
                if (!File.Exists(modJsonPath))
                    continue;

                var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));
                if (mod == null)
                    continue;

                mod.RemoveRemoveFiles();
                mod.CopyFiles();
                mod.ApplyIniPatches();

                if (mod.ApplyIPSPatch(ref dol) | mod.ApplyDolPatches(ref dol))
                    hasDolPatches = true;

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
        }

        if (gameId == null && (arCodes.Any() || geckoCodes.Any()))
            gameId = GetDefaultCodesGameId();

        if (gameId != null)
        {
            CreateCustomDolphinSettings(gameId, arCodes, geckoCodes);
            CopyDolphinSysSettings(gameId);

            hasDolPatches = true;

            ApplyGameIdOnDol(gameId, ref dol);
            ApplyGameIdOnBootBin(gameId);
        }

        if (hasDolPatches)
            File.WriteAllBytes(GameDolPath, dol);

        CurrentGameSettings.Invalidated = false;
        SaveGameSettings();

        if (modsUsingCustomGameId > 1)
        {
            await Dialogs.ShowWarningAsync("Warning",
                "Multiple active mods have custom save files specified. Only the last one's Game ID will be applied.");
        }
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
        if (strBuilder.Length >= 4)
            strBuilder[3] = 'H';
        return strBuilder.ToString();
    }

    public static string GameDolphinSettingsPath(string gameId) => Path.Combine(DolphinFolderPath, "GameSettings", gameId + ".ini");

    public static string DolphinSysSettingsPath => Platform.GetDolphinSysPath(DolphinPath);

    public static string GameDolphinSysSettingsPath(string gameId) => Path.Combine(DolphinSysSettingsPath, "GameSettings", gameId + ".ini");

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
            dolphinSettings = DolphinGameSettings.FromContents("");
        }

        dolphinSettings.Core["EnableCheats"] = "True";

        dolphinSettings.ActionReplay.RemoveAll(c => c.Enabled == false);
        dolphinSettings.ActionReplay.AddRange(arCodes);

        dolphinSettings.Gecko.RemoveAll(c => c.Enabled == false);
        dolphinSettings.Gecko.AddRange(geckoCodes);

        var newDolphinSettingsPath = GameDolphinSettingsPath(destinationGameId);
        var dir = Path.GetDirectoryName(newDolphinSettingsPath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        dolphinSettings.SaveTo(newDolphinSettingsPath);
    }

    private static void CopyDolphinSysSettings(string destinationGameId)
    {
        var originalFile = GameDolphinSysSettingsPath(GameToGameID(CurrentGame));
        if (File.Exists(originalFile))
        {
            var destPath = GameDolphinSysSettingsPath(destinationGameId);
            var dir = Path.GetDirectoryName(destPath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            File.Copy(originalFile, destPath, true);
        }
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

    private static void ApplyGameIdOnBootBin(string gameId)
    {
        var bootBinPath = Path.Combine(GameGameSysPath, "boot.bin");
        if (!File.Exists(bootBinPath))
            return;

        var bootBin = File.ReadAllBytes(bootBinPath);
        if (bootBin.Length >= 6 && gameId.Length >= 6)
        {
            bootBin[0] = (byte)gameId[0];
            bootBin[1] = (byte)gameId[1];
            bootBin[2] = (byte)gameId[2];
            bootBin[3] = (byte)gameId[3];
            bootBin[4] = (byte)gameId[4];
            bootBin[5] = (byte)gameId[5];

            File.WriteAllBytes(bootBinPath, bootBin);
        }
    }

    public static bool GameBackupExists => Directory.Exists(GameBackupFilesPath) && Directory.Exists(GameBackupSysPath);
    public static bool GameExists => Directory.Exists(GameGameFilesPath) && Directory.Exists(GameGameSysPath) && File.Exists(GameDolPath);

    public static void CloseDolphin() => Platform.CloseDolphin();

    public static async Task<bool> RunGameAsync()
    {
        if (string.IsNullOrEmpty(DolphinPath))
        {
            await Dialogs.ShowErrorAsync("Error launching game", "Unable to launch game: Dolphin executable path not set.");
            return false;
        }

        if (!File.Exists(DolphinPath) && !Directory.Exists(DolphinPath))
        {
            await Dialogs.ShowErrorAsync("Error launching game", "Unable to launch game: Dolphin executable not found on set path.");
            return false;
        }

        if (!GameExists)
        {
            await Dialogs.ShowErrorAsync("Error launching game", "Unable to launch game: game executable not found.");
            return false;
        }

        try
        {
            Platform.LaunchDolphin(DolphinPath, GameDolPath);
            return true;
        }
        catch (Exception ex)
        {
            await Dialogs.ShowErrorAsync("Error launching game", $"Failed to launch Dolphin: {ex.Message}");
            return false;
        }
    }

    public static void SaveISO(string path)
    {
        DiscImage.CreateFile(GameGamePath, path);
    }

    public static void OpenSettingsFile() => Platform.OpenFile(ModManagerSettingsPath);
    public static void OpenGameFolder() => Platform.OpenFolder(GameFolderPath);
    public static void OpenModsFolder() => Platform.OpenFolder(ModsFolderPath);
    public static void OpenGameINI() => Platform.OpenFile(GameGameINIPath);
}
