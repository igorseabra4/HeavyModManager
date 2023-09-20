using HeavyModManager.Classes;
using HeavyModManager.Enum;
using HeavyModManager.Forms.Other;
using System.Diagnostics;
using System.Text.Json;

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

    public static string GameFolderPath => Path.Combine(Application.StartupPath, "Games", "gc", GameToString(CurrentGame));
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
    public static string DolphinPath { get; private set; }
    public static Game CurrentGame { get; private set; }
    public static GameSettings? CurrentGameSettings { get; private set; } = null;

    public static void SaveSettings()
    {
        File.WriteAllText(ModManagerSettingsPath, JsonSerializer.Serialize(new ModManagerSettings()
        {
            CurrentGame = CurrentGame,
            DolphinPath = DolphinPath,
            CheckForUpdatesOnStartup = CheckForUpdatesOnStartup,
            DeveloperMode = DeveloperMode,
            Icon = IconManager.CurrentIcon,
        }));
    }

    public static void LoadSettings()
    {
        ModManagerSettings settings = File.Exists(ModManagerSettingsPath) ?
             JsonSerializer.Deserialize<ModManagerSettings>(File.ReadAllText(ModManagerSettingsPath)) :
             new ModManagerSettings();

        CurrentGame = settings.CurrentGame;
        DolphinPath = settings.DolphinPath;
        CheckForUpdatesOnStartup = settings.CheckForUpdatesOnStartup;
        if (settings.Version >= 2)
        {
            DeveloperMode = settings.DeveloperMode;
            IconManager.CurrentIcon = settings.Icon;
        }
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
            SaveSettings();
            MessageBox.Show("Dolphin path set successfully.", "Dolphin path set", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
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

            File.WriteAllText(GameSettingsPath, JsonSerializer.Serialize(CurrentGameSettings));
        }
    }

    public static void RefreshGameSettings()
    {
        if (File.Exists(GameSettingsPath))
            CurrentGameSettings = JsonSerializer.Deserialize<GameSettings>(File.ReadAllText(GameSettingsPath));
        else
            CurrentGameSettings = new GameSettings();

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
            Title = "Select a mod ZIP to install"
        };

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            ZipManager.InstallMod(openFile.FileName);
            RefreshModList();
        }
    }

    public static void DeleteMod(string modId, bool skipRefresh = false)
    {
        var path = GetModPath(modId);
        if (Directory.Exists(path))
            Directory.Delete(path, true);
        if (!skipRefresh)
            RefreshModList();
    }

    public static bool RestoreBackupIso(string isoPath)
    {
        if (Directory.Exists(GameBackupPath))
            Directory.Delete(GameBackupPath, true);

        GameCubeImage image;

        try
        {
            image = new GameCubeImage(isoPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to read ISO: " + ex.Message, "Error reading ISO",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        Directory.CreateDirectory(GameBackupPath);
        Directory.CreateDirectory(GameBackupFilesPath);
        Directory.CreateDirectory(GameBackupSysPath);

        try
        {
            image.Dump(GameBackupFilesPath, GameBackupSysPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to create backup from ISO: " + ex.Message, "Backup failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.Delete(GameBackupPath, true);
            return false;
        }

        MessageBox.Show($"Game backup for {GameToStringFull(CurrentGame)} succesfully created. You can apply mods now.",
            "Backup successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return true;
    }

    public static void RestoreBackupDol(string rootPath)
    {
        var files = Path.Combine(rootPath, "files");

        if (!Directory.Exists(files))
        {
            MessageBox.Show("Unable to create backup: 'files' directory not found. Are you sure you are using a proper ISO dump?",
                "Backup failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var sys = Path.Combine(rootPath, "sys");

        if (!Directory.Exists(sys))
        {
            MessageBox.Show("Unable to create backup: 'sys' directory not found. Are you sure you are using a proper ISO dump?",
                "Backup failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (Directory.Exists(GameBackupPath))
            Directory.Delete(GameBackupPath, true);

        Directory.CreateDirectory(GameBackupPath);
        Directory.CreateDirectory(GameBackupFilesPath);
        Directory.CreateDirectory(GameBackupSysPath);

        var fs = new Microsoft.VisualBasic.Devices.Computer().FileSystem;

        fs.CopyDirectory(files, GameBackupFilesPath);
        fs.CopyDirectory(sys, GameBackupSysPath);

        MessageBox.Show($"Game backup for {GameToStringFull(CurrentGame)} succesfully created. You can apply mods now.",
            "Backup successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void Invalidate()
    {
        CurrentGameSettings.Invalidated = true;
        SaveGameSettings();
    }

    public static void ApplyMods()
    {
        if (!DeveloperMode && !CurrentGameSettings.Invalidated)
            return;

        CloseDolphin();

        if (!GameBackupExists)
        {
            MessageBox.Show("Unable to apply mods: game backup not found. Please create the game's backup first.",
                "Game backup not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var fs = new Microsoft.VisualBasic.Devices.Computer().FileSystem;

        if (DeveloperMode)
        {
            if (!Directory.Exists(GameGamePath))
            {
                Directory.CreateDirectory(GameGamePath);
                Directory.CreateDirectory(GameGameFilesPath);
                Directory.CreateDirectory(GameGameSysPath);

                fs.CopyDirectory(GameBackupFilesPath, GameGameFilesPath);
                fs.CopyDirectory(GameBackupSysPath, GameGameSysPath);
            }
        }
        else
        {
            if (Directory.Exists(GameGamePath))
                Directory.Delete(GameGamePath, true);

            Directory.CreateDirectory(GameGamePath);
            Directory.CreateDirectory(GameGameFilesPath);
            Directory.CreateDirectory(GameGameSysPath);

            fs.CopyDirectory(GameBackupFilesPath, GameGameFilesPath);
            fs.CopyDirectory(GameBackupSysPath, GameGameSysPath);
        }

        foreach (var modId in CurrentGameSettings.Mods)
            if (CurrentGameSettings.ActiveMods.Contains(modId))
            {
                var modJsonPath = GetModJsonPath(modId);
                var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));
                mod.Apply();
            }

        CurrentGameSettings.Invalidated = false;
        SaveGameSettings();
    }

    public static bool GameBackupExists => Directory.Exists(GameBackupFilesPath) && Directory.Exists(GameBackupSysPath);
    public static bool GameExists => Directory.Exists(GameGameFilesPath) && Directory.Exists(GameGameSysPath) && File.Exists(GameDolPath);

    public static void CloseDolphin()
    {
        foreach (var p in Process.GetProcessesByName("Dolphin"))
            if (!p.HasExited)
            {
                p.CloseMainWindow();
                p.WaitForExit();
            }
    }

    public static void RunGame()
    {
        if (string.IsNullOrEmpty(DolphinPath))
        {
            MessageBox.Show("Unable to launch game: Dolphin executable path not set.", "Error launching game",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!File.Exists(DolphinPath))
        {
            MessageBox.Show("Unable to launch game: Dolphin executable not found on set path.", "Error launching game",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!GameExists)
        {
            MessageBox.Show("Unable to launch game: game executable not found.", "Error launching game",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Process.Start(DolphinPath, new string[] { GameDolPath });
    }
}