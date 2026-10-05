using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using HeavyModManager.Core.Classes;
using HeavyModManager.Core.Enum;
using HeavyModManager.Core.Functions;
using HeavyModManager.Core.Platform;
using HeavyModManager.Desktop.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeavyModManager.Desktop.Views;

public class ModItemViewModel : INotifyPropertyChanged
{
    private readonly Mod _mod;
    private bool _isActive;

    public Mod Mod => _mod;
    public string UpdatedText => _mod.UpdatedAt.ToShortDateString();

    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive != value)
            {
                _isActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
                OnActiveChanged?.Invoke(this);
            }
        }
    }

    public Action<ModItemViewModel>? OnActiveChanged { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ModItemViewModel(Mod mod, bool isActive)
    {
        _mod = mod;
        _isActive = isActive;
    }
}

public partial class MainWindow : Window
{
    private readonly ObservableCollection<ModItemViewModel> _modItems = new();
    private bool _suppressSelectionEvents = false;

    public MainWindow()
    {
        InitializeComponent();

        ModManager.Dialogs = new AvaloniaDialogService();

        ListBoxMods.ItemsSource = _modItems;
        ListBoxMods.SelectionChanged += ListBoxMods_SelectionChanged;

        // Initialize Games
        foreach (Game game in ModManager.EvilEngineGames)
        {
            ComboBoxGame.Items.Add(new ComboBoxGameItem(game));
        }

        ComboBoxGame.SelectionChanged += ComboBoxGame_SelectionChanged;

        // Wire Buttons
        ButtonAddMod.Click += async (s, e) => await AddModZipAsync();
        ButtonRefreshMods.Click += (s, e) => RefreshModList();
        ButtonMoveUp.Click += (s, e) => MoveSelectedMod(-1);
        ButtonMoveDown.Click += (s, e) => MoveSelectedMod(1);

        ButtonEditMod.Click += async (s, e) => await EditSelectedModAsync();
        ButtonOpenFolder.Click += (s, e) => OpenSelectedModFolder();
        ButtonDeleteMod.Click += async (s, e) => await DeleteSelectedModAsync();

        ButtonLaunchGame.Click += async (s, e) => await LaunchGameAsync();
        ButtonSaveIso.Click += async (s, e) => await SaveIsoAsync();

        // Wire Menu Items
        WireMenuActions();

        // Wire Drag & Drop
        AddHandler(DragDrop.DropEvent, OnFileDrop);
        AddHandler(DragDrop.DragOverEvent, (s, e) =>
        {
            if (e.Data.Contains(DataFormats.Files))
                e.DragEffects = DragDropEffects.Copy;
            else
                e.DragEffects = DragDropEffects.None;
        });

        // Load Initial State
        SelectInitialGame();
        UpdateDolphinStatusLabels();
        UpdateDetailsPane(null);
    }

    private void SelectInitialGame()
    {
        if (ModManager.CurrentGame != Game.Null)
        {
            for (int i = 0; i < ComboBoxGame.Items.Count; i++)
            {
                if (ComboBoxGame.Items[i] is ComboBoxGameItem item && item.Game == ModManager.CurrentGame)
                {
                    ComboBoxGame.SelectedIndex = i;
                    return;
                }
            }
        }

        if (ComboBoxGame.Items.Count > 0)
            ComboBoxGame.SelectedIndex = 0;
    }

    private void ComboBoxGame_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ComboBoxGame.SelectedItem is ComboBoxGameItem item)
        {
            ModManager.SetCurrentGame(item.Game);
            RefreshModList();
        }
    }

    public void RefreshModList(string? selectModId = null)
    {
        _suppressSelectionEvents = true;
        _modItems.Clear();

        if (ModManager.CurrentGameSettings != null)
        {
            ModManager.RefreshGameSettings();

            foreach (var modId in ModManager.CurrentGameSettings.Mods)
            {
                string jsonPath = ModManager.GetModJsonPath(modId);
                if (File.Exists(jsonPath))
                {
                    try
                    {
                        var mod = System.Text.Json.JsonSerializer.Deserialize<Mod>(File.ReadAllText(jsonPath));
                        if (mod != null)
                        {
                            bool active = ModManager.CurrentGameSettings.ActiveMods.Contains(mod.ModId);
                            var vm = new ModItemViewModel(mod, active)
                            {
                                OnActiveChanged = OnModActiveToggled
                            };
                            _modItems.Add(vm);
                        }
                    }
                    catch { }
                }
            }
        }

        _suppressSelectionEvents = false;

        if (!string.IsNullOrEmpty(selectModId))
        {
            var target = _modItems.FirstOrDefault(m => m.Mod.ModId == selectModId);
            if (target != null)
                ListBoxMods.SelectedItem = target;
        }

        UpdateDetailsPane(GetSelectedMod());
        UpdateDolphinStatusLabels();
    }

    private void OnModActiveToggled(ModItemViewModel vm)
    {
        if (ModManager.CurrentGameSettings == null)
            return;

        if (vm.IsActive)
            ModManager.CurrentGameSettings.ActivateMod(vm.Mod.ModId);
        else
            ModManager.CurrentGameSettings.DeactivateMod(vm.Mod.ModId);

        ModManager.SaveGameSettings();
    }

    private Mod? GetSelectedMod()
    {
        if (ListBoxMods.SelectedItem is ModItemViewModel vm)
            return vm.Mod;
        return null;
    }

    private void ListBoxMods_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_suppressSelectionEvents)
            return;

        UpdateDetailsPane(GetSelectedMod());
    }

    private void UpdateDetailsPane(Mod? mod)
    {
        PanelBadges.Children.Clear();

        if (mod == null)
        {
            TextDetailModName.Text = "No Mod Selected";
            TextDetailAuthor.Text = "";
            TextDetailDescription.Text = "Select a mod from the list to view its details, or drag & drop a .zip file anywhere into this window to install a mod.";
            TextDetailModId.Text = "";
            ButtonEditMod.IsEnabled = false;
            ButtonOpenFolder.IsEnabled = false;
            ButtonDeleteMod.IsEnabled = false;
            return;
        }

        TextDetailModName.Text = mod.ModName;
        TextDetailAuthor.Text = string.IsNullOrWhiteSpace(mod.Author) ? "" : $"by {mod.Author}";
        TextDetailDescription.Text = string.IsNullOrWhiteSpace(mod.Description) ? "(No description provided)" : mod.Description;
        TextDetailModId.Text = mod.ModId;

        ButtonEditMod.IsEnabled = true;
        ButtonOpenFolder.IsEnabled = true;
        ButtonDeleteMod.IsEnabled = true;

        // Add badges
        if (!string.IsNullOrEmpty(mod.GameId))
            AddBadge($"Save File: {mod.GameId}", "#3498db");

        if (!string.IsNullOrEmpty(mod.MergeFiles))
            AddBadge("HIP/HOP Merge", "#9b59b6");

        if (!string.IsNullOrEmpty(mod.DOLPatches))
            AddBadge("DOL Patches", "#e67e22");

        if (!string.IsNullOrEmpty(mod.IpsPatchBase64))
            AddBadge("IPS Patch", "#e74c3c");

        if (!string.IsNullOrEmpty(mod.ArCodes))
            AddBadge("AR Codes", "#2ecc71");

        if (!string.IsNullOrEmpty(mod.GeckoCodes))
            AddBadge("Gecko Codes", "#1abc9c");
    }

    private void AddBadge(string text, string colorHex)
    {
        var border = new Border
        {
            Background = Avalonia.Media.Brush.Parse(colorHex),
            CornerRadius = new Avalonia.CornerRadius(4),
            Padding = new Avalonia.Thickness(6, 2),
            Margin = new Avalonia.Thickness(0, 0, 6, 6)
        };
        border.Child = new TextBlock
        {
            Text = text,
            FontSize = 11,
            Foreground = Avalonia.Media.Brushes.White,
            FontWeight = Avalonia.Media.FontWeight.SemiBold
        };
        PanelBadges.Children.Add(border);
    }

    private void MoveSelectedMod(int direction)
    {
        if (ModManager.CurrentGameSettings == null)
            return;

        int index = ListBoxMods.SelectedIndex;
        if (index < 0) return;

        int targetIndex = index + direction;
        if (targetIndex < 0 || targetIndex >= _modItems.Count)
            return;

        var currentModId = _modItems[index].Mod.ModId;
        var targetModId = _modItems[targetIndex].Mod.ModId;

        int idx1 = ModManager.CurrentGameSettings.Mods.IndexOf(currentModId);
        int idx2 = ModManager.CurrentGameSettings.Mods.IndexOf(targetModId);

        if (idx1 >= 0 && idx2 >= 0)
        {
            (ModManager.CurrentGameSettings.Mods[idx1], ModManager.CurrentGameSettings.Mods[idx2]) =
                (ModManager.CurrentGameSettings.Mods[idx2], ModManager.CurrentGameSettings.Mods[idx1]);

            ModManager.Invalidate();
            RefreshModList(currentModId);
        }
    }

    private async Task AddModZipAsync()
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select Mod ZIP Archive(s)",
            AllowMultiple = true,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("ZIP Archives") { Patterns = new[] { "*.zip" } },
                new FilePickerFileType("All Files") { Patterns = new[] { "*.*" } }
            }
        });

        if (files.Count > 0)
        {
            foreach (var file in files)
            {
                await ZipManager.InstallModAsync(file.Path.LocalPath, ModManager.Dialogs);
            }
            RefreshModList();
        }
    }

    private async void OnFileDrop(object? sender, DragEventArgs e)
    {
        var files = e.Data.GetFiles();
        if (files == null) return;

        bool added = false;
        foreach (var file in files)
        {
            string localPath = file.Path.LocalPath;
            if (localPath.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                await ZipManager.InstallModAsync(localPath, ModManager.Dialogs);
                added = true;
            }
        }

        if (added)
            RefreshModList();
    }

    private async Task EditSelectedModAsync()
    {
        var mod = GetSelectedMod();
        if (mod == null) return;

        var editWin = new CreateModWindow(mod);
        await editWin.ShowDialog(this);

        if (editWin.ResultMod != null)
            RefreshModList(editWin.ResultMod.ModId);
    }

    private void OpenSelectedModFolder()
    {
        var mod = GetSelectedMod();
        if (mod == null) return;

        PlatformService.Instance.OpenFolder(ModManager.GetModPath(mod.ModId));
    }

    private async Task DeleteSelectedModAsync()
    {
        var mod = GetSelectedMod();
        if (mod == null) return;

        bool confirm = await MessageDialog.ShowConfirmAsync(this, "Confirm Deletion",
            $"Are you sure you want to delete mod '{mod.ModName}'?");

        if (confirm)
        {
            ModManager.DeleteMod(mod.ModId);
            RefreshModList();
        }
    }

    private async Task SetGameIsoAsync()
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select GameCube ISO",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("GameCube ISO") { Patterns = new[] { "*.iso", "*.gcm" } },
                new FilePickerFileType("All Files") { Patterns = new[] { "*.*" } }
            }
        });

        if (files.Count > 0)
        {
            var progressWin = new ProgressWindow
            {
                Title = "Extracting Game Backup..."
            };
            progressWin.SetStatus("Reading and extracting GameCube ISO...");
            progressWin.Show(this);

            bool success = false;
            string? error = null;
            try
            {
                success = await Task.Run(async () =>
                {
                    return await ModManager.RestoreBackupIsoAsync(files[0].Path.LocalPath, progressWin, showDialog: false);
                });
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                progressWin.Close();
            }

            if (success)
            {
                RefreshModList();
                await MessageDialog.ShowAsync(this, "Backup Successful",
                    $"Game backup for {ModManager.GameToStringFull(ModManager.CurrentGame)} successfully created. You can apply mods now.");
            }
            else
            {
                await MessageDialog.ShowAsync(this, "Backup Failed",
                    ModManager.LastError ?? (error != null ? $"Unable to create backup from ISO: {error}" : "Unable to create backup from ISO."));
            }
        }
    }

    private async Task SetGameFolderAsync()
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select Extracted Game Folder (containing 'files' and 'sys')",
            AllowMultiple = false
        });

        if (folders.Count > 0)
        {
            var progressWin = new ProgressWindow
            {
                Title = "Copying Game Backup..."
            };
            progressWin.SetStatus("Copying game files to backup folder...");
            progressWin.SetIndeterminate(true);
            progressWin.Show(this);

            bool success = false;
            string? error = null;
            try
            {
                success = await Task.Run(async () =>
                {
                    return await ModManager.RestoreBackupFolderAsync(folders[0].Path.LocalPath, showDialog: false);
                });
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                progressWin.Close();
            }

            if (success)
            {
                RefreshModList();
                await MessageDialog.ShowAsync(this, "Backup Successful",
                    $"Game backup for {ModManager.GameToStringFull(ModManager.CurrentGame)} successfully created. You can apply mods now.");
            }
            else
            {
                await MessageDialog.ShowAsync(this, "Backup Failed",
                    ModManager.LastError ?? (error != null ? $"Unable to create backup: {error}" : "Unable to create backup from folder."));
            }
        }
    }

    private async Task SetDolphinExecutableAsync()
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select Dolphin Executable or Application",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("Dolphin Executable / App") { Patterns = new[] { "*.app", "*.exe", "*" } }
            }
        });

        if (files.Count > 0)
        {
            ModManager.DolphinPath = files[0].Path.LocalPath;
            ModManager.SaveSettings(new ModManagerSettings());
            UpdateDolphinStatusLabels();
            await MessageDialog.ShowAsync(this, "Success", "Dolphin path updated successfully.");
        }
    }

    private async Task SetDolphinFolderAsync()
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select Dolphin User Folder (containing GameSettings)",
            AllowMultiple = false
        });

        if (folders.Count > 0)
        {
            ModManager.DolphinFolderPath = folders[0].Path.LocalPath;
            ModManager.SaveSettings(new ModManagerSettings());
            UpdateDolphinStatusLabels();
            await MessageDialog.ShowAsync(this, "Success", "Dolphin user folder updated successfully.");
        }
    }

    private async Task LaunchGameAsync()
    {
        if (!ModManager.GameBackupExists)
        {
            await MessageDialog.ShowAsync(this, "Backup Required",
                $"No game backup found for {ModManager.GameToStringFull(ModManager.CurrentGame)}. Please set the Game ISO or Folder first under File -> Set Game ISO.");
            return;
        }

        IsEnabled = false;
        try
        {
            ModManager.CloseDolphin();

            if (ModManager.DeveloperMode || (ModManager.CurrentGameSettings?.Invalidated ?? false))
            {
                await Task.Run(async () =>
                {
                    ModManager.ResetGameFromBackup();
                    await ModManager.ApplyModsAsync();
                });
            }

            await ModManager.RunGameAsync();
        }
        finally
        {
            IsEnabled = true;
        }
    }

    private async Task SaveIsoAsync()
    {
        if (!ModManager.GameBackupExists)
        {
            await MessageDialog.ShowAsync(this, "Backup Required",
                "No game backup found. Please create a game backup first under File -> Set Game ISO.");
            return;
        }

        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var saveFile = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Export GameCube ISO with Active Mods",
            DefaultExtension = "iso",
            SuggestedFileName = $"{ModManager.GameToString(ModManager.CurrentGame)}_modded.iso",
            FileTypeChoices = new[]
            {
                new FilePickerFileType("GameCube ISO (*.iso)") { Patterns = new[] { "*.iso" } }
            }
        });

        if (saveFile == null)
            return;

        string targetPath = saveFile.Path.LocalPath;

        IsEnabled = false;
        var progressWin = new ProgressWindow
        {
            Title = "Saving ISO..."
        };
        progressWin.SetStatus("Applying mods and building GameCube ISO image...");
        progressWin.SetIndeterminate(true);
        progressWin.Show(this);

        try
        {
            await Task.Run(async () =>
            {
                ModManager.ResetGameFromBackup();
                await ModManager.ApplyModsAsync();
                ModManager.SaveISO(targetPath);
            });

            progressWin.Close();
            await MessageDialog.ShowAsync(this, "ISO Saved", $"GameCube ISO successfully exported to:\n{targetPath}");
        }
        catch (Exception ex)
        {
            progressWin.Close();
            await MessageDialog.ShowAsync(this, "Export Failed", $"Failed to save ISO:\n{ex.Message}");
        }
        finally
        {
            IsEnabled = true;
        }
    }

    private void UpdateDolphinStatusLabels()
    {
        bool exeValid = !string.IsNullOrWhiteSpace(ModManager.DolphinPath) &&
                        (File.Exists(ModManager.DolphinPath) || Directory.Exists(ModManager.DolphinPath));

        bool folderValid = !string.IsNullOrWhiteSpace(ModManager.DolphinFolderPath) &&
                          Directory.Exists(ModManager.DolphinFolderPath);

        TextDolphinPathStatus.Text = exeValid
            ? $"Dolphin: {ModManager.DolphinPath}"
            : "Dolphin: Executable not set or not found";

        TextDolphinFolderStatus.Text = folderValid
            ? $"User Folder: {ModManager.DolphinFolderPath}"
            : "User Folder: Path not set or not found";
    }

    private void WireMenuActions()
    {
        // File Actions
        MenuSetIso.Click += async (s, e) => await SetGameIsoAsync();
        MenuSetFolder.Click += async (s, e) => await SetGameFolderAsync();
        MenuSetDolphinExe.Click += async (s, e) => await SetDolphinExecutableAsync();
        MenuSetDolphinFolder.Click += async (s, e) => await SetDolphinFolderAsync();
        MenuExit.Click += (s, e) => Close();

        // Mods Actions
        MenuAddMod.Click += async (s, e) => await AddModZipAsync();
        MenuCreateMod.Click += async (s, e) =>
        {
            var win = new CreateModWindow();
            await win.ShowDialog(this);
            if (win.ResultMod != null)
                RefreshModList(win.ResultMod.ModId);
        };
        MenuOpenModsFolder.Click += (s, e) => ModManager.OpenModsFolder();
        MenuRefreshMods.Click += (s, e) => RefreshModList();

        // Manage Actions
        MenuOpenGameFolder.Click += (s, e) => ModManager.OpenGameFolder();
        MenuOpenGameIni.Click += (s, e) => ModManager.OpenGameINI();
        MenuDeleteBackup.Click += async (s, e) =>
        {
            if (Directory.Exists(ModManager.GameBackupPath))
            {
                bool confirm = await MessageDialog.ShowConfirmAsync(this, "Confirm Delete",
                    $"Delete game backup for {ModManager.GameToStringFull(ModManager.CurrentGame)}?");
                if (confirm)
                {
                    Directory.Delete(ModManager.GameBackupPath, true);
                    RefreshModList();
                }
            }
        };

        // Tools Actions
        MenuSaveIso.Click += async (s, e) => await SaveIsoAsync();
        MenuLaunchGame.Click += async (s, e) => await LaunchGameAsync();
        MenuOpenDolphin.Click += (s, e) =>
        {
            if (!string.IsNullOrWhiteSpace(ModManager.DolphinPath))
                PlatformService.Instance.LaunchDolphin(ModManager.DolphinPath, "");
        };

        // Options Actions
        MenuThemeSystem.Click += (s, e) => ChangeTheme(AppTheme.System);
        MenuThemeLight.Click += (s, e) => ChangeTheme(AppTheme.Classic);
        MenuThemeDark.Click += (s, e) => ChangeTheme(AppTheme.Dark);
        MenuOpenSettings.Click += (s, e) => ModManager.OpenSettingsFile();

        MenuDevMode.Click += (s, e) =>
        {
            ModManager.DeveloperMode = !ModManager.DeveloperMode;
            UpdateDolphinStatusLabels();
        };

        // Help Actions
        MenuAbout.Click += async (s, e) =>
        {
            var win = new AboutWindow();
            await win.ShowDialog(this);
        };
        MenuWiki.Click += (s, e) => PlatformService.Instance.OpenUrl("https://heavyironmodding.org/wiki/Heavy_Mod_Manager");
        MenuDiscord.Click += (s, e) => PlatformService.Instance.OpenUrl("https://discord.gg/9eAE6UB");

        // Set up Native Menu for macOS
        SetupNativeMenu();
    }

    private void SetupNativeMenu()
    {
        if (!PlatformService.Instance.IsMacOS)
            return;

        try
        {
            var nativeMenu = new NativeMenu();

            // File
            var fileItem = new NativeMenuItem("File") { Menu = new NativeMenu() };
            var setIso = new NativeMenuItem("Set Game ISO (Backup)...") { Gesture = new KeyGesture(Key.O, KeyModifiers.Meta) };
            setIso.Click += async (s, e) => await SetGameIsoAsync();
            var setFolder = new NativeMenuItem("Set Game Folder (Backup)...");
            setFolder.Click += async (s, e) => await SetGameFolderAsync();
            var setExe = new NativeMenuItem("Set Dolphin Executable...");
            setExe.Click += async (s, e) => await SetDolphinExecutableAsync();
            var setFolderDolphin = new NativeMenuItem("Set Dolphin User Folder...");
            setFolderDolphin.Click += async (s, e) => await SetDolphinFolderAsync();

            fileItem.Menu.Items.Add(setIso);
            fileItem.Menu.Items.Add(setFolder);
            fileItem.Menu.Items.Add(new NativeMenuItemSeparator());
            fileItem.Menu.Items.Add(setExe);
            fileItem.Menu.Items.Add(setFolderDolphin);

            // Mods
            var modsItem = new NativeMenuItem("Mods") { Menu = new NativeMenu() };
            var addMod = new NativeMenuItem("Add Mod (.zip)...");
            addMod.Click += async (s, e) => await AddModZipAsync();
            var createMod = new NativeMenuItem("Create Mod...") { Gesture = new KeyGesture(Key.N, KeyModifiers.Meta) };
            createMod.Click += async (s, e) =>
            {
                var win = new CreateModWindow();
                await win.ShowDialog(this);
                if (win.ResultMod != null)
                    RefreshModList(win.ResultMod.ModId);
            };
            var openModsFolder = new NativeMenuItem("Open Mods Folder");
            openModsFolder.Click += (s, e) => ModManager.OpenModsFolder();
            var refreshMods = new NativeMenuItem("Refresh Mod List") { Gesture = new KeyGesture(Key.R, KeyModifiers.Meta) };
            refreshMods.Click += (s, e) => RefreshModList();

            modsItem.Menu.Items.Add(addMod);
            modsItem.Menu.Items.Add(createMod);
            modsItem.Menu.Items.Add(openModsFolder);
            modsItem.Menu.Items.Add(refreshMods);

            // Tools
            var toolsItem = new NativeMenuItem("Tools") { Menu = new NativeMenu() };
            var saveIso = new NativeMenuItem("Save ISO...") { Gesture = new KeyGesture(Key.S, KeyModifiers.Meta) };
            saveIso.Click += async (s, e) => await SaveIsoAsync();
            var launchGame = new NativeMenuItem("Launch Game") { Gesture = new KeyGesture(Key.Enter, KeyModifiers.Meta) };
            launchGame.Click += async (s, e) => await LaunchGameAsync();
            var openDolphin = new NativeMenuItem("Open Dolphin");
            openDolphin.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(ModManager.DolphinPath))
                    PlatformService.Instance.LaunchDolphin(ModManager.DolphinPath, "");
            };

            toolsItem.Menu.Items.Add(saveIso);
            toolsItem.Menu.Items.Add(launchGame);
            toolsItem.Menu.Items.Add(openDolphin);

            // Help
            var helpItem = new NativeMenuItem("Help") { Menu = new NativeMenu() };
            var about = new NativeMenuItem("About Heavy Mod Manager");
            about.Click += async (s, e) =>
            {
                var win = new AboutWindow();
                await win.ShowDialog(this);
            };
            var wiki = new NativeMenuItem("Heavy Iron Modding Wiki");
            wiki.Click += (s, e) => PlatformService.Instance.OpenUrl("https://heavyironmodding.org/wiki/Heavy_Mod_Manager");

            helpItem.Menu.Items.Add(about);
            helpItem.Menu.Items.Add(wiki);

            nativeMenu.Items.Add(fileItem);
            nativeMenu.Items.Add(modsItem);
            nativeMenu.Items.Add(toolsItem);
            nativeMenu.Items.Add(helpItem);

            NativeMenu.SetMenu(this, nativeMenu);
        }
        catch { }
    }

    private void ChangeTheme(AppTheme theme)
    {
        App.ApplyTheme(theme);
        ModManager.CurrentTheme = theme;
        ModManager.SaveSettings(new ModManagerSettings());
    }
}
