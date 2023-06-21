using NoCheese.Classes;
using NoCheese.Enum;
using System.Text.Json;

namespace NoCheese;

public static class ModManager
{
    public static string GameToString(Game game)
    {
        switch (game)
        {
            case Game.Scooby:
                return "scooby";
            case Game.BFBB:
                return "bfbb";
            case Game.Movie:
                return "movie";
            case Game.Incredibles:
                return "incredibles";
            case Game.Underminer:
                return "rotu";
            case Game.RatProto:
                return "ratproto";
            case Game.Ratatouille:
                return "ratatouille";
            case Game.WallE:
                return "walle";
            case Game.Up:
                return "up";
            case Game.TruthOrSquare:
                return "tos";
            case Game.UFC:
                return "ufc";
            case Game.FamilyGuy:
                return "familyguy";
            case Game.HollywoodWorkout:
                return "hollywoodworkout";
        }
        throw new ArgumentException("Invalid game.");
    }

    public static string GameToStringFull(Game game)
    {
        switch (game)
        {
            case Game.Scooby:
                return "Scooby-Doo! Night of 100 Frights";
            case Game.BFBB:
                return "SpongeBob SquarePants: Battle for Bikini Bottom";
            case Game.Movie:
                return "The SpongeBob SquarePants Movie";
            case Game.Incredibles:
                return "The Incredibles";
            case Game.Underminer:
                return "The Incredibles: Rise of the Underminer";
            case Game.RatProto:
                return "Ratatouille (January 18th, 2006 Prototype)";
            case Game.Ratatouille:
                return "Ratatouille";
            case Game.WallE:
                return "WALL-E";
            case Game.Up:
                return "Up";
            case Game.TruthOrSquare:
                return "SpongeBob's Truth or Square";
            case Game.UFC:
                return "UFC Personal Trainer";
            case Game.FamilyGuy:
                return "Family Guy: Back to the Multiverse";
            case Game.HollywoodWorkout:
                return "Harley Pasternak's Hollywood Workout";
        }
        throw new ArgumentException("Invalid game.");
    }

    public static Game StringToGame(string game)
    {
        switch (game)
        {
            case "scooby":
                return Game.Scooby;
            case "bfbb":
                return Game.BFBB;
            case "movie":
                return Game.Movie;
            case "incredibles":
                return Game.Incredibles;
            case "rotu":
                return Game.Underminer;
            case "ratproto":
                return Game.RatProto;
            case "ratatouille":
                return Game.Ratatouille;
            case "walle":
                return Game.WallE;
            case "up":
                return Game.Up;
            case "tos":
                return Game.TruthOrSquare;
            case "ufc":
                return Game.UFC;
            case "familyguy":
                return Game.FamilyGuy;
            case "hollywoodworkout":
                return Game.HollywoodWorkout;
        }
        throw new ArgumentException("Invalid game.");
    }

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
    public static string GameDolPath => Path.Combine(GameGamePath, "sys", "main.dol");

    public static string DolphinPath { get; private set; }
    public static Game CurrentGame { get; private set; } = Game.Null;
    public static GameSettings? CurrentGameSettings { get; private set; } = null;

    public static void SaveSettings()
    {
        File.WriteAllText(ModManagerSettingsPath, JsonSerializer.Serialize(new ModManagerSettings()
        {
            currentGame = CurrentGame,
            dolphinPath = DolphinPath
        }));
    }

    public static void LoadSettings()
    {
        CurrentGame = Game.Null;
        DolphinPath = "";
        if (File.Exists(ModManagerSettingsPath))
        {
            var settings = JsonSerializer.Deserialize<ModManagerSettings>(File.ReadAllText(ModManagerSettingsPath));
            CurrentGame = settings.currentGame;
            DolphinPath = settings.dolphinPath;
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
            MessageBox.Show("Dolphin path set successfully.");
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

        SaveGameSettings();
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

    public static void RestoreBackup(string rootPath)
    {
        var files = Path.Combine(rootPath, "files");

        if (!Directory.Exists(files))
        {
            MessageBox.Show("Unable to create backup: 'files' directory not found. Are you sure you are using a proper ISO dump?");
            return;
        }

        var sys = Path.Combine(rootPath, "sys");

        if (!Directory.Exists(sys))
        {
            MessageBox.Show("Unable to create backup: 'sys' directory not found. Are you sure you are using a proper ISO dump?");
            return;
        }

        if (Directory.Exists(GameBackupPath))
            Directory.Delete(GameBackupPath, true);

        Directory.CreateDirectory(GameBackupPath);
        Directory.CreateDirectory(GameBackupFilesPath);
        Directory.CreateDirectory(GameBackupSysPath);

        new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(files, GameBackupFilesPath);
        new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(sys, GameBackupSysPath);

        MessageBox.Show($"Game backup for {GameToStringFull(CurrentGame)} succesfully created. You can apply mods now.");
    }

    public static void ApplyMods(bool force)
    {
        if (!force && !CurrentGameSettings.Invalidated)
            return;

        if (!GameBackupExists)
        {
            MessageBox.Show("Unable to apply mods: game backup not found. Please create the game's backup first.");
            return;
        }

        if (Directory.Exists(GameGamePath))
            Directory.Delete(GameGamePath, true);

        Directory.CreateDirectory(GameGamePath);
        Directory.CreateDirectory(GameGameFilesPath);
        Directory.CreateDirectory(GameGameSysPath);

        new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(GameBackupFilesPath, GameGameFilesPath);
        new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(GameBackupSysPath, GameGameSysPath);

        foreach (var modId in CurrentGameSettings.Mods)
            if (CurrentGameSettings.ActiveMods.Contains(modId))
            {
                var modFilesPath = GetModFilesPath(modId);
                if (Directory.Exists(modFilesPath))
                    new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(modFilesPath, GameGameFilesPath, true);

                // now apply INI, ar/gecko codes and remove files
            }

        CurrentGameSettings.Invalidated = false;
        SaveGameSettings();
    }

    public static bool GameBackupExists => Directory.Exists(GameBackupFilesPath) && Directory.Exists(GameBackupSysPath);
    public static bool GameExists => Directory.Exists(GameGameFilesPath) && Directory.Exists(GameGameSysPath) && File.Exists(GameDolPath);

    public static void RunGame()
    {
        if (string.IsNullOrEmpty(DolphinPath))
        {
            MessageBox.Show("Unable to launch game: Dolphin executable path not set.");
            return;
        }

        if (!File.Exists(DolphinPath))
        {
            MessageBox.Show("Unable to launch game: Dolphin executable not found on set path.");
            return;
        }

        if (!GameExists)
        {
            MessageBox.Show("Unable to launch game: game executable not found.");
            return;
        }

        System.Diagnostics.Process.Start(DolphinPath, new string[] { GameDolPath });
    }
}