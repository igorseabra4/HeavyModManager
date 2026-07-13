using HeavyModManager.Classes;
using HeavyModManager.Enum;
using HeavyModManager.Forms;
using HeavyModManager.Forms.Other;
using HeavyModManager.Functions;
using HeavyModManager.Properties;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace HeavyModManager;

public partial class MainForm : Form
{
    public MainForm()
    {
        showOnboarding = !File.Exists(ModManager.ModManagerSettingsPath);
        var settings = LoadSettings();
        // Set theme e.g. Classic/Dark
        Application.SetColorMode(settings.Theme);

        InitializeComponent();

        labelStatus.Text = "0 mods selected";
        SetThemeDropdownValues(); // Must come after InitializeComponent
        InitializeManageMenus();
        UpdateFormSize(settings);
        UpdateCurrentLanguageMenuItem();
        UpdateCurrentThemeMenuItem(settings.Theme);
        UpdateSaveIsoText();
        showISOAfterSavingToolStripMenuItem.Checked = ModManager.OpenIsoAfterExport;

        IconManager.SetIcon(this);

        CheckForLegacyMods();

        toolTip = new ToolTip();
        aboutBox = new AboutBox();

        foreach (Game game in ModManager.EvilEngineGames)
            comboBoxGame.Items.Add(new ComboBoxGameItem(game));

        developerModeToolStripMenuItem.Checked = ModManager.DeveloperMode;
        checkForUpdatesOnStartupToolStripMenuItem.Checked = ModManager.CheckForUpdatesOnStartup;

        if (ModManager.CheckForUpdatesOnStartup)
            TryUpdate();

        if (ModManager.CurrentPlatform == GamePlatform.Unknown)
            ModManager.CurrentPlatform = DefaultPlatform;

        comboBoxPlatform.Items.Clear();
        if (ModManager.CurrentGame == Game.Null)
            comboBoxGame.SelectedIndex = -1;
        else
        {
            for (int i = 0; i < comboBoxGame.Items.Count; i++)
                if (((ComboBoxGameItem)comboBoxGame.Items[i]).Game == ModManager.CurrentGame)
                {
                    comboBoxGame.SelectedIndex = i;
                    break;
                }
        }


        labelModInfo.AutoSize = true;
        labelModInfo.MaximumSize = new Size(panelLabelModInfo.Width - SystemInformation.VerticalScrollBarWidth, 0);
        labelModInfo.Text = "";

        UpdateDeveloperMode();
        UpdateStatusLabel();
        ShowToolTip();
        UpdatePlatformIcon();
    }

    private bool showOnboarding = false;

    private readonly GamePlatform DefaultPlatform = GamePlatform.GameCube;

    private ToolStripMenuItem createModToolStripMenuItem;
    private ToolStripMenuItem editModToolStripMenuItem;
    private ToolStripMenuItem openModFolderToolStripMenuItem;
    private ToolStripMenuItem zipModToolStripMenuItem;
    private ToolStripMenuItem deleteModToolStripMenuItem;

    private ToolStripMenuItem editModToolStripMenuItemContext;
    private ToolStripMenuItem openModFolderToolStripMenuItemContext;
    private ToolStripMenuItem zipModToolStripMenuItemContext;
    private ToolStripMenuItem deleteModToolStripMenuItemContext;

    private ContextMenuStrip manageContextMenuStrip;

    private void CheckForLegacyMods()
    {
        var legacyModDirectories = ModManager.GetLegacyModDirectories();
        int numLegacyMods = legacyModDirectories.Count;

        if (numLegacyMods == 0)
            return;

        var result = MessageBox.Show(
            $"It looks like you have {numLegacyMods} mod(s) created with an older version of Heavy Mod Manager. Would you like to migrate them? They will be marked as GameCube mods.",
            "Legacy mods detected",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (result != DialogResult.Yes)
            return;

        // Update legacy mods.
        int numMigrated = ModManager.MigrateLegacyMods(legacyModDirectories);

        MessageBox.Show(
            $"Successfully migrated {numMigrated} mod(s).",
            "Migration complete",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }

    private void InitializeManageMenus()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));

        createModToolStripMenuItem = new ToolStripMenuItem();
        editModToolStripMenuItem = new ToolStripMenuItem();
        openModFolderToolStripMenuItem = new ToolStripMenuItem();
        zipModToolStripMenuItem = new ToolStripMenuItem();
        deleteModToolStripMenuItem = new ToolStripMenuItem();

        createModToolStripMenuItem.Text = GlobalResources.createModText;
        createModToolStripMenuItem.Click += createModToolStripMenuItem_Click;

        editModToolStripMenuItem.Text = GlobalResources.editModText;
        editModToolStripMenuItem.Click += editModToolStripMenuItem_Click;

        openModFolderToolStripMenuItem.Text = GlobalResources.openModFolderText;
        openModFolderToolStripMenuItem.Click += openModFolderToolStripMenuItem_Click;

        zipModToolStripMenuItem.Text = GlobalResources.zipModText;
        zipModToolStripMenuItem.Click += zipModToolStripMenuItem_Click;

        deleteModToolStripMenuItem.Text = GlobalResources.deleteModText;
        deleteModToolStripMenuItem.Click += deleteModToolStripMenuItem_Click;

        manageToolStripMenuItem.DropDownItems.AddRange([createModToolStripMenuItem, editModToolStripMenuItem, openModFolderToolStripMenuItem, zipModToolStripMenuItem, deleteModToolStripMenuItem]);

        editModToolStripMenuItemContext = new ToolStripMenuItem();
        openModFolderToolStripMenuItemContext = new ToolStripMenuItem();
        zipModToolStripMenuItemContext = new ToolStripMenuItem();
        deleteModToolStripMenuItemContext = new ToolStripMenuItem();

        editModToolStripMenuItemContext.Text = GlobalResources.editModText;
        editModToolStripMenuItemContext.Click += editModToolStripMenuItem_Click;

        openModFolderToolStripMenuItemContext.Text = GlobalResources.openModFolderText;
        openModFolderToolStripMenuItemContext.Click += openModFolderToolStripMenuItem_Click;

        zipModToolStripMenuItemContext.Text = GlobalResources.zipModText;
        zipModToolStripMenuItemContext.Click += zipModToolStripMenuItem_Click;

        deleteModToolStripMenuItemContext.Text = GlobalResources.deleteModText;
        deleteModToolStripMenuItemContext.Click += deleteModToolStripMenuItem_Click;

        manageContextMenuStrip = new ContextMenuStrip();
        manageContextMenuStrip.Items.AddRange([editModToolStripMenuItemContext, openModFolderToolStripMenuItemContext, zipModToolStripMenuItemContext, deleteModToolStripMenuItemContext]);
    }

    private void UpdateCurrentLanguageMenuItem()
    {
        foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
        {
            if (item.Tag.ToString() == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
            {
                item.Checked = true;
                return;
            }
        }

        englishToolStripMenuItem.Checked = true;
        return;
    }

    private void SetThemeDropdownValues()
    {
        systemToolStripMenuItem.Tag = SystemColorMode.System;
        lightToolStripMenuItem.Tag = SystemColorMode.Classic;
        darkToolStripMenuItem.Tag = SystemColorMode.Dark;
    }

    private void UpdateCurrentThemeMenuItem(SystemColorMode theme)
    {
        foreach (ToolStripMenuItem item in themeToolStripMenuItem.DropDownItems)
        {
            if (item.Tag is SystemColorMode itemTheme && itemTheme == theme)
            {
                item.Checked = true;
            }
            else
            {
                item.Checked = false;
            }
        }
    }

    private async void TryUpdate(bool showMessageIfNotAvailable = false)
    {
        switch (await AutomaticUpdater.Update())
        {
            case UpdateResult.Updated:
                Close();
                System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "HeavyModManager.exe"));
                break;
            case UpdateResult.NoUpdateAvailable:
                if (showMessageIfNotAvailable)
                    MessageBox.Show(GlobalResources.noUpdateAvailable, GlobalResources.noUpdateAvailable, MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;
        }
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
        if (showOnboarding)
        {
            MessageBox.Show(
                "It looks like your first time running Heavy Mod Manager.\n\n" +
                "You can find instructions at heavyironmodding.org.\n" +
                "Feel free to ask for help in the Heavy Iron Modding Discord, under Help > About.",
                "Welcome",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        ShowToolTip();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveSettings();
    }

    private void SaveSettings()
    {
        var settings = new ModManagerSettings
        {
            MainFormWidth = Width,
            MainFormHeight = Height
        };

        foreach (ColumnHeader c in listViewMods.Columns)
        {
            settings.ColumnIndices.Add(c.DisplayIndex);
            settings.ColumnSizes.Add(c.Width);
        }

        settings.Theme = Application.ColorMode;

        ModManager.SaveSettings(settings);
    }

    private ModManagerSettings LoadSettings()
    {
        return ModManager.LoadSettings();
    }

    private void UpdateFormSize(ModManagerSettings settings)
    {
        if (settings.MainFormWidth > MaximumSize.Width)
            Width = settings.MainFormWidth;
        if (settings.MainFormHeight > MaximumSize.Height)
            Height = settings.MainFormHeight;

        if (settings.ColumnIndices != null && settings.ColumnIndices.Count == listViewMods.Columns.Count &&
            settings.ColumnSizes != null && settings.ColumnSizes.Count == listViewMods.Columns.Count)
            for (int i = 0; i < listViewMods.Columns.Count; i++)
            {
                listViewMods.Columns[i].DisplayIndex = settings.ColumnIndices[i];
                listViewMods.Columns[i].Width = Math.Max(settings.ColumnSizes[i], 32);
            }
    }

    private AboutBox aboutBox;

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        aboutBox.ShowDialog();
    }

    private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
    {
        ModManager.SetCurrentGame(comboBoxGame.SelectedIndex == -1 ? Game.Null : ((ComboBoxGameItem)comboBoxGame.SelectedItem).Game);

        PopulateModList();

        groupBoxMods.Enabled = comboBoxGame.SelectedIndex != -1;
        createModToolStripMenuItem.Enabled = true;
        buttonRestoreBackupDev.Enabled = CanApplyMods;
        buttonRunGameDev.Enabled = CanApplyMods;
        buttonSaveIso.Enabled = CanSaveIso;
        buttonRunGame.Enabled = CanApplyMods;
        buttonCreateBackup.Enabled = comboBoxGame.SelectedIndex != -1;

        // Update platforms
        var platforms = ModManager.SupportedPlatformsForGame(ModManager.CurrentGame);
        // Update comboBoxPlatform with supported platforms

        // Get selected platform if one is selected
        int selected = comboBoxPlatform.SelectedIndex;

        comboBoxPlatform.Items.Clear();

        foreach (var plat in platforms)
        {
            bool exists = false;
            foreach (ComboBoxPlatformItem item in comboBoxPlatform.Items)
            {
                if (item.Platform == plat)
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
                comboBoxPlatform.Items.Add(new ComboBoxPlatformItem(plat));
        }

        // If the previously selected platform is still valid, keep it selected. Otherwise select the first one.
        if (selected != -1 && selected < comboBoxPlatform.Items.Count)
        {
            comboBoxPlatform.SelectedIndex = selected;
        }
        else
        {
            int savedIndex = -1;
            for (int i = 0; i < comboBoxPlatform.Items.Count; i++)
            {
                if (((ComboBoxPlatformItem)comboBoxPlatform.Items[i]).Platform == ModManager.CurrentPlatform)
                {
                    savedIndex = i;
                    break;
                }
            }

            if (savedIndex != -1)
                comboBoxPlatform.SelectedIndex = savedIndex;
            else if (comboBoxPlatform.Items.Count > 0)
                comboBoxPlatform.SelectedIndex = 0;
        }

        ShowToolTip();

        SaveSettings();
    }

    private bool CanApplyMods => comboBoxGame.SelectedIndex != -1 &&
                                 ModManager.GameBackupExists(ModManager.CurrentGame, ModManager.CurrentPlatform) &&
                                 ModManager.EmulatorPathIsSet(ModManager.CurrentPlatform);


    private bool CanSaveIso => comboBoxGame.SelectedIndex != -1 &&
        ModManager.GameBackupExists(ModManager.CurrentGame, ModManager.CurrentPlatform);

    private readonly ToolTip toolTip;

    private void ShowToolTip()
    {
        toolTip.Hide(comboBoxGame);

        int tooltipX = 0;
        int tooltipY = 24;
        int tooltipDurationMs = 12 * 1000;

        // Display localised strings (from MainForm.resx) in tooltips instead of hard-coded string.
        // if (string.IsNullOrEmpty(ModManager.DolphinPath))
        // {
        //     toolTip.Show(GlobalResources.dolphinPathNotSetTooltip,
        //         comboBoxGame, tooltipX, tooltipY, tooltipDurationMs);
        // }
        // else if (string.IsNullOrEmpty(ModManager.DolphinFolderPath))
        // {
        //     toolTip.Show(GlobalResources.dolphinUserFolderPathNotSetTooltip,
        //         comboBoxGame, tooltipX, tooltipY, tooltipDurationMs);
        // }

        if (comboBoxGame.SelectedIndex != -1)
        {
            if (!ModManager.GameBackupExists(ModManager.CurrentGame, ModManager.CurrentPlatform))
                toolTip.Show(GlobalResources.noBackupTooltip, comboBoxGame, tooltipX, tooltipY, tooltipDurationMs);
            //toolTip.Show("You do not have a backup for this game.\nPlease click on \"Create Backup\" and select the game's ISO file.", comboBoxGame, 0, 24, 8 * 1000);
            else if (listViewMods.Items.Count == 0)
                toolTip.Show(GlobalResources.noModsTooltip, comboBoxGame, tooltipX, tooltipY, tooltipDurationMs);
            //toolTip.Show("You do not have mods for this game.\nPlease click on \"Add Mods\" and select a mod ZIP file.", comboBoxGame, 0, 24, 8 * 1000);
        }
    }

    private void createModToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new CreateMod().ShowDialog();
        ModManager.RefreshModList();
        PopulateModList();
    }

    private void editModToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var mod = GetSelectedMod();
        if (mod != null)
        {
            new CreateMod(mod).ShowDialog();
            ModManager.RefreshModList();
            PopulateModList(mod.ModId);
        }
    }

    private void openModFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var mod = GetSelectedMod();
        if (mod != null)
            System.Diagnostics.Process.Start("explorer.exe", ModManager.GetModPath(mod.ModId));
    }

    private void deleteModToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var mod = GetSelectedMod();
        if (mod != null)
        {
            string message = string.Format(GlobalResources.confirmDeleteMod, mod.ModName, mod.Author);

            var dr = MessageBox.Show(
                message,
                GlobalResources.confirmDeleteModTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                ModManager.DeleteMod(mod.ModId);
                ModManager.RefreshModList();
                PopulateModList();
            }
        }
    }

    private void zipModToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var mod = GetSelectedMod();
        if (mod != null)
        {
            try
            {
                string TreatToFilename(string s)
                {
                    foreach (var c in "*\"/\\<>:|?")
                        s = s.Replace($"{c}", "");
                    return s;
                }
                ZipManager.ZipMod(mod.ModId, TreatToFilename($"{ModManager.GameToStringFull(mod.Game)} - {mod.Author} - {mod.ModName}"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    GlobalResources.errorCreatingModZip + " " + ex.Message,
                    GlobalResources.error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    private bool programChangingData = false;
    private int _sortColumn = -1;
    private bool _sortAscending = true;

    private void PopulateModList(string selectedModId = "")
    {
        programChangingData = true;
        pictureBoxMod.Image = Resources.image_placeholder;

        labelModInfo.Text = "";
        listViewMods.Items.Clear();

        editModToolStripMenuItem.Enabled = false;
        deleteModToolStripMenuItem.Enabled = false;
        zipModToolStripMenuItem.Enabled = false;
        openModFolderToolStripMenuItem.Enabled = false;

        editModToolStripMenuItemContext.Enabled = false;
        deleteModToolStripMenuItemContext.Enabled = false;
        zipModToolStripMenuItemContext.Enabled = false;
        openModFolderToolStripMenuItemContext.Enabled = false;

        var activePlatform = ModManager.CurrentPlatform;

        foreach (var modId in ModManager.CurrentGameSettings.Mods)
        {
            var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(ModManager.GetModJsonPath(modId)));
            bool active = ModManager.CurrentGameSettings.ActiveMods.Contains(mod.ModId);

            if (mod.Platform == activePlatform || mod.Platform == GamePlatform.Unknown)
                listViewMods.Items.Add(ListViewItemFromMod(mod, active, selectedModId == mod.ModId));
        }

        UpdateStatusLabel();

        programChangingData = false;
    }

    private static ListViewItem ListViewItemFromMod(Mod mod, bool active, bool selected)
    {
        ListViewItem item = new(mod.ModName)
        {
            Selected = selected,
            Checked = active,
            Tag = mod
        };

        item.SubItems.AddRange(new ListViewItem.ListViewSubItem[]
        {
            new ListViewItem.ListViewSubItem(item, mod.Author),
            new ListViewItem.ListViewSubItem(item, ModManager.PlatformToStringFull(mod.Platform)),
            new ListViewItem.ListViewSubItem(item, mod.Version),
            new ListViewItem.ListViewSubItem(item, mod.CreatedAt.ToShortDateString()),
            new ListViewItem.ListViewSubItem(item, mod.UpdatedAt.ToShortDateString()),
        });

        return item;
    }

    private Mod? GetSelectedMod()
    {
        if (listViewMods.SelectedIndices.Count == 1)
            return (Mod)listViewMods.SelectedItems[0].Tag;
        return null;
    }

    private void listViewMods_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (programChangingData)
            return;

        var mod = (Mod)listViewMods.Items[e.Index].Tag;

        if (e.NewValue == CheckState.Checked)
            ModManager.CurrentGameSettings.ActivateMod(mod.ModId);
        else
            ModManager.CurrentGameSettings.DeactivateMod(mod.ModId);

        // Deactive mods that don't have the active platform
        var platform = ModManager.CurrentPlatform;

        foreach (var item in ModManager.CurrentGameSettings.ActiveMods.ToList())
        {
            var m = JsonSerializer.Deserialize<Mod>(File.ReadAllText(ModManager.GetModJsonPath(item)));
            if (m.Platform != platform && m.Platform != GamePlatform.Unknown)
                ModManager.CurrentGameSettings.DeactivateMod(m.ModId);
        }

        ModManager.SaveGameSettings(ModManager.CurrentGame, ModManager.CurrentPlatform);
        UpdateStatusLabel();
    }

    private void listViewMods_SelectedIndexChanged(object sender, EventArgs e)
    {
        labelModInfo.Text = "";

        var mod = GetSelectedMod();

        if (mod != null)
        {
            // Update image
            if (ModManager.ModHasImage(mod))
                pictureBoxMod.Image = ModManager.GetModImage(mod);
            else
                pictureBoxMod.Image = Resources.image_placeholder;

            if (!string.IsNullOrWhiteSpace(mod.Description))
                labelModInfo.Text += $"{mod.Description}\n\n";

            if (!string.IsNullOrEmpty(mod.GameId))
                labelModInfo.Text += $"Has a custom save file: {mod.GameId}\n";

            if (!string.IsNullOrEmpty(mod.MergeFiles))
                labelModInfo.Text += "Has HIP/HOP files for merging\n";

            if (!string.IsNullOrEmpty(mod.DOLPatches))
                labelModInfo.Text += "Has DOL Patches\n";

            if (!string.IsNullOrEmpty(mod.IpsPatchBase64))
                labelModInfo.Text += "Has IPS Patch\n";

            if (!string.IsNullOrEmpty(mod.ArCodes))
                labelModInfo.Text += "Has AR Codes\n";

            if (!string.IsNullOrEmpty(mod.GeckoCodes))
                labelModInfo.Text += "Has Gecko Codes\n";

            if (!labelModInfo.Text.EndsWith("\n\n"))
                labelModInfo.Text += "\n";

            labelModInfo.Text += $"Mod ID:\n{mod.ModId}\n\n";

            long size = ModManager.GetDirectorySize(ModManager.GetModPath(mod.ModId));
            string sizeString = ModManager.GetFormattedSize(size);

            labelModInfo.Text += $"Size on disk: {sizeString}";

            editModToolStripMenuItem.Enabled = true;
            deleteModToolStripMenuItem.Enabled = true;
            zipModToolStripMenuItem.Enabled = true;
            openModFolderToolStripMenuItem.Enabled = true;

            editModToolStripMenuItemContext.Enabled = true;
            deleteModToolStripMenuItemContext.Enabled = true;
            zipModToolStripMenuItemContext.Enabled = true;
            openModFolderToolStripMenuItemContext.Enabled = true;
        }
        else
        {
            editModToolStripMenuItem.Enabled = false;
            deleteModToolStripMenuItem.Enabled = false;
            zipModToolStripMenuItem.Enabled = false;
            openModFolderToolStripMenuItem.Enabled = false;

            editModToolStripMenuItemContext.Enabled = false;
            deleteModToolStripMenuItemContext.Enabled = false;
            zipModToolStripMenuItemContext.Enabled = false;
            openModFolderToolStripMenuItemContext.Enabled = false;
        }
    }

    private void listViewMods_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
            deleteModToolStripMenuItem_Click(sender, e);
    }

    private void buttonMoveUp_Click(object sender, EventArgs e)
    {
        var mod = GetSelectedMod();
        if (mod == null) return;

        int visualIndex = listViewMods.SelectedIndices[0];
        if (visualIndex > 0)
        {
            var displayedIndices = GetDisplayedModIndices();
            var allMods = ModManager.CurrentGameSettings.Mods;
            (allMods[displayedIndices[visualIndex]], allMods[displayedIndices[visualIndex - 1]]) =
                (allMods[displayedIndices[visualIndex - 1]], allMods[displayedIndices[visualIndex]]);
            ModManager.Invalidate();
        }
        PopulateModList(mod.ModId);
    }

    private void buttonMoveDown_Click(object sender, EventArgs e)
    {
        var mod = GetSelectedMod();
        if (mod == null) return;

        int visualIndex = listViewMods.SelectedIndices[0];
        var displayedIndices = GetDisplayedModIndices();
        if (visualIndex < displayedIndices.Count - 1)
        {
            var allMods = ModManager.CurrentGameSettings.Mods;
            (allMods[displayedIndices[visualIndex]], allMods[displayedIndices[visualIndex + 1]]) =
                (allMods[displayedIndices[visualIndex + 1]], allMods[displayedIndices[visualIndex]]);
            ModManager.Invalidate();
        }
        PopulateModList(mod.ModId);
    }

    private List<int> GetDisplayedModIndices()
    {
        var activePlatform = ModManager.CurrentPlatform;
        var allMods = ModManager.CurrentGameSettings.Mods;
        var indices = new List<int>();

        for (int i = 0; i < allMods.Count; i++)
        {
            var modJsonPath = ModManager.GetModJsonPath(allMods[i]);
            if (!File.Exists(modJsonPath)) continue;
            var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));
            if (mod.Platform == activePlatform || mod.Platform == GamePlatform.Unknown)
                indices.Add(i);
        }

        return indices;
    }

    private void listViewMods_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        if (_sortColumn == e.Column)
            _sortAscending = !_sortAscending;
        else
        {
            _sortColumn = e.Column;
            _sortAscending = true;
        }

        SortModsByColumn(_sortColumn, _sortAscending);
    }

    private void SortModsByColumn(int column, bool ascending)
    {
        var activePlatform = ModManager.CurrentPlatform;
        var allMods = ModManager.CurrentGameSettings.Mods;

        var platformModIndices = new List<int>();
        var platformMods = new List<Mod>();

        for (int i = 0; i < allMods.Count; i++)
        {
            var modJsonPath = ModManager.GetModJsonPath(allMods[i]);
            if (!File.Exists(modJsonPath)) continue;
            var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));
            if (mod.Platform == activePlatform || mod.Platform == GamePlatform.Unknown)
            {
                platformModIndices.Add(i);
                platformMods.Add(mod);
            }
        }

        platformMods.Sort((a, b) =>
        {
            int cmp = column switch
            {
                0 => string.Compare(a.ModName, b.ModName, StringComparison.OrdinalIgnoreCase),
                1 => string.Compare(a.Author, b.Author, StringComparison.OrdinalIgnoreCase),
                2 => string.Compare(ModManager.PlatformToStringFull(a.Platform), ModManager.PlatformToStringFull(b.Platform), StringComparison.OrdinalIgnoreCase),
                3 => string.Compare(a.Version, b.Version, StringComparison.OrdinalIgnoreCase),
                4 => a.CreatedAt.CompareTo(b.CreatedAt),
                5 => a.UpdatedAt.CompareTo(b.UpdatedAt),
                _ => 0
            };
            return ascending ? cmp : -cmp;
        });

        for (int i = 0; i < platformModIndices.Count; i++)
            allMods[platformModIndices[i]] = platformMods[i].ModId;

        ModManager.Invalidate();
        PopulateModList();
    }

    private async void buttonRestoreBackup_Click(object sender, EventArgs e)
    {
        string platform = ModManager.PlatformToStringFull(ModManager.CurrentPlatform);
        string executableType = ModManager.PlatformToExecutable(ModManager.CurrentPlatform);
        string title = $"Select {platform} ISO";

        if (ModManager.CurrentPlatform != GamePlatform.PlayStation2)
            title += $" or {executableType}";
        else
            title += " or ELF executable";

        var openFile = new OpenFileDialog()
        {
            // TODO Localise strings
            Filter = "ISO or main executable" + $"|*.iso;{executableType}|All files(*.*)|*.*",
            Title = title
        };

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            bool done = false;
            while (!done)
            {
                Enabled = false;
                ModManager.Result result = ModManager.Result.Error;

                // Extract game from ISO (platform-dependent)
                if (Path.GetExtension(openFile.FileName).ToLower().Equals(".iso"))
                {
                    try
                    {
                        result = ModManager.RestoreBackupIso(openFile.FileName, ModManager.CurrentGame, ModManager.CurrentPlatform);
                    } catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred while restoring backup from ISO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    result = ModManager.RestoreBackupFromFolder(
                        Path.GetDirectoryName(openFile.FileName),
                        ModManager.CurrentGame,
                        ModManager.CurrentPlatform
                        );
                }

                if (result == ModManager.Result.Success)
                {
                    done = true;
                    TaskbarFlasher.Flash(this.Handle);
                    MessageBox.Show(
                        $"Game backup for {ModManager.GameToStringFull(ModManager.CurrentGame)} succesfully created. You can apply mods now.",
                        "Backup successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    TaskbarFlasher.Stop(this.Handle);
                }
                else if (result == ModManager.Result.MissingXdvdfs)
                {
                    bool downloaded = await PromptToDownloadXdvdfs();
                }
                else
                {
                    done = true;
                    MessageBox.Show(
                        $"Failed to create game backup for {ModManager.GameToStringFull(ModManager.CurrentGame)}.",
                        "Backup failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }

            Enabled = true;

            buttonRestoreBackupDev.Enabled = CanApplyMods;
            buttonRunGameDev.Enabled = CanApplyMods;
            buttonRunGame.Enabled = CanApplyMods;
            buttonSaveIso.Enabled = CanSaveIso;
        }
    }

    private void buttonRestoreBackupDev_Click(object sender, EventArgs e)
    {
        Enabled = false;
        ModManager.ResetGameFromBackup(ModManager.CurrentGame, ModManager.CurrentPlatform);
        Enabled = true;
    }

    private void buttonRunGameDev_Click(object sender, EventArgs e)
    {
        Enabled = false;
        ModManager.CloseEmulator();
        ModManager.ApplyMods(ModManager.CurrentGame, ModManager.CurrentPlatform);
        Enabled = true;
        RunGame();
    }

    private async void RunGame()
    {
        try
        {
            var result = await ModManager.RunGameAsync(ModManager.CurrentGame, ModManager.CurrentPlatform);

            if (result == ModManager.Result.EmulatorNotFound)
            {
                // warn user
                MessageBox.Show(
                    $"Emulator not found. Please set the emulator path for {ModManager.PlatformToStringFull(ModManager.CurrentPlatform)} in the settings.",
                    "Emulator not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (result == ModManager.Result.MissingXdvdfs)
            {
                bool downloaded = await PromptToDownloadXdvdfs();

                if (downloaded)
                {
                    // Try running the game again
                    RunGame();
                }
            }
            else if (result == ModManager.Result.MissingMkisofs)
            {
                bool downloaded = await PromptToDownloadMkisofs();

                if (downloaded)
                {
                    // Try running the game again
                    RunGame();
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(
                "There was an error running the game.\n\n" + e.Message,
                "Error running game",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }
    }

    private async void buttonRunGame_Click(object sender, EventArgs e)
    {
        Enabled = false;
        ModManager.CloseEmulator();
        var progressBar = new ProgressBarForm()
        {
            Text = "Running game..."
        };
        progressBar.SetDetails("Applying mods...");
        progressBar.Show(this);

        if (ModManager.CurrentGameSettings.Invalidated)
        {
            await Task.Run(() =>
            {
                ModManager.ResetGameFromBackup(ModManager.CurrentGame, ModManager.CurrentPlatform);
                ModManager.ApplyMods(ModManager.CurrentGame, ModManager.CurrentPlatform);
            });
        }

        progressBar.Close();
        Enabled = true;
        RunGame();
    }

    private void buttonAddMod_Click(object sender, EventArgs e)
    {
        ModManager.InstallMod();
        PopulateModList();
    }

    private void buttonRefreshModList_Click(object sender, EventArgs e)
    {
        ModManager.RefreshModList();
        PopulateModList();
    }

    //private void chooseDolphinPathToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //    ModManager.SetDolphinPath();
    //    SaveSettings();
    //    UpdateStatusLabel();
    //    ShowToolTip();
    //}

    //private void chooseDolphinUserFolderPathToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //    ModManager.SetDolphinFolderPath();
    //    SaveSettings();
    //    UpdateStatusLabel();
    //    ShowToolTip();
    //}

    private void developerModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ModManager.DeveloperMode = !ModManager.DeveloperMode;
        developerModeToolStripMenuItem.Checked = ModManager.DeveloperMode;
        if (comboBoxGame.SelectedItem != null)
            ModManager.Invalidate();
        UpdateStatusLabel();
        UpdateDeveloperMode();
        UpdateSaveIsoText();
    }

    private void UpdateSaveIsoText()
    {
        if (ModManager.DeveloperMode)
            buttonSaveIso.Text = GlobalResources.applyAndSaveIso;
        else
            buttonSaveIso.Text = GlobalResources.saveIso;
    }

    private void UpdateDeveloperMode()
    {
        if (developerModeToolStripMenuItem.Checked)
        {
            buttonRestoreBackupDev.Visible = true;
            buttonRunGameDev.Visible = true;
            buttonRunGame.Visible = false;
        }
        else
        {
            buttonRestoreBackupDev.Visible = false;
            buttonRunGameDev.Visible = false;
            buttonRunGame.Visible = true;
        }
    }

    private void checkForUpdatesOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ModManager.CheckForUpdatesOnStartup = !ModManager.CheckForUpdatesOnStartup;
        checkForUpdatesOnStartupToolStripMenuItem.Checked = ModManager.CheckForUpdatesOnStartup;
    }

    private void checkForUpdatesNowToolStripMenuItem_Click(object sender, EventArgs e)
    {
        TryUpdate(true);
    }

    private void UpdateStatusLabel()
    {
        if (ModManager.CurrentGameSettings != null)
        {
            int numModsSelected = ModManager.CurrentGameSettings.ActiveMods.Count;
            bool addPluralS = numModsSelected != 1;
            string text = $"{numModsSelected} mod{(addPluralS ? "s" : "")} selected";

            if (ModManager.DeveloperMode)
                text += " - " + GlobalResources.developerMode;

            labelStatus.Text = text;
        }
    }

    private void changeIconToolStripMenuItem_Click(object sender, EventArgs e)
    {
        IconManager.ChangeIcon();
        IconManager.SetIcon(this);
        IconManager.SetIcon(aboutBox);
    }

    private void changeLanguageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // If sender is already checked, do nothing
        if (((ToolStripMenuItem)sender).Checked)
            return;

        // Get the tag of the sender
        string tag = ((ToolStripMenuItem)sender).Tag.ToString();

        if (!string.IsNullOrEmpty(tag))
        {
            // Set the current culture to the one from the tag
            CultureInfo.CurrentCulture = new CultureInfo(tag);
            CultureInfo.CurrentUICulture = new CultureInfo(tag);

            SaveSettings();
            Close();

            // Start a new instance of the form
            System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "HeavyModManager.exe"));
        }
    }

    private void listViewMods_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var focusedItem = listViewMods.FocusedItem;
            if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                manageContextMenuStrip.Show(Cursor.Position);
        }
    }

    private void themeItemToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        if (sender is not ToolStripMenuItem item)
            return;

        if (item.Tag is not SystemColorMode selectedTheme)
            return;

        Application.SetColorMode(selectedTheme);
        SaveAndRestart();
    }

    private void SaveAndRestart()
    {
        SaveSettings();
        Close();

        // Start a new instance of the form
        System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "HeavyModManager.exe"));
    }

    private async void buttonSaveIso_Click(object sender, EventArgs e)
    {
        string initialFilename = "game.iso";
        string platform = ModManager.PlatformToStringFull(ModManager.CurrentPlatform);

        // Open save dialog box
        var dialog = new SaveFileDialog
        {
            FileName = initialFilename,
            Title = "Save ISO File",
            AddExtension = true,
            Filter = $"{platform} ISO (*.iso)|*.iso|All files (*.*)|*.*"
        };

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        Enabled = false;

        var progressBar = new ProgressBarForm()
        {
            Text = "Saving ISO..."
        };
        progressBar.SetDetails("Applying mods...");
        progressBar.Show(this);

        if (ModManager.DeveloperMode || ModManager.CurrentGameSettings.Invalidated)
        {
            await Task.Run(() =>
            {
                ModManager.ResetGameFromBackup(ModManager.CurrentGame, ModManager.CurrentPlatform);
                ModManager.ApplyMods(ModManager.CurrentGame, ModManager.CurrentPlatform);
            });
        }

        progressBar.SetDetails("Saving to file...");
        try
        {
            while (true)
            {
                long expectedSize = ModManager.GetDirectorySize(
                    ModManager.GameGamePath(ModManager.CurrentGame, ModManager.CurrentPlatform));

                var creationTask = Task.Run(() =>
                {
                    return ModManager.SaveISOAsync(dialog.FileName, ModManager.CurrentGame, ModManager.CurrentPlatform);
                });

                while (!creationTask.IsCompleted)
                {
                    if (File.Exists(dialog.FileName))
                    {
                        long currentSize = new FileInfo(dialog.FileName).Length;
                        int percent = (int)((currentSize / (double)expectedSize) * 100);
                        Debug.WriteLine(percent);
                        progressBar.SetProgress(percent);
                    }

                    await Task.Delay(50);
                }

                var result = await creationTask;

                if (result == ModManager.Result.MissingXdvdfs)
                {
                    bool downloaded = await PromptToDownloadXdvdfs();

                    if (downloaded)
                    {
                        continue; // retry SaveISO
                    }
                    else
                    {
                        return; // user cancelled or failed
                    }
                }

                progressBar.SetProgress(100);
                break;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                this,
                $"ISO creation failed:\n\n{ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }
        finally
        {
            progressBar.Close();
            Enabled = true;
        }
        TaskbarFlasher.Flash(this.Handle);
        MessageBox.Show(
            "ISO Saved to " + dialog.FileName,
            "ISO Saved",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
        TaskbarFlasher.Stop(this.Handle);

        // Open folder containing ISO
        if (ModManager.OpenIsoAfterExport)
        {
            Process.Start("explorer.exe", "/select,\"" + dialog.FileName + "\"");
        }
    }

    private void openSettingsjsonToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (!File.Exists(ModManager.ModManagerSettingsPath))
            {
                MessageBox.Show("Settings file not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ModManager.OpenSettingsFile();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open settings file:\n{ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void comboBoxPlatform_SelectedIndexChanged(object sender, EventArgs e)
    {
        ModManager.CurrentPlatform = comboBoxPlatform.SelectedIndex == -1 ?
            GamePlatform.Unknown :
            ((ComboBoxPlatformItem)comboBoxPlatform.SelectedItem).Platform;

        if (comboBoxGame.SelectedIndex != -1 && ModManager.CurrentPlatform != GamePlatform.Unknown)
            ModManager.RefreshGameSettings(ModManager.CurrentGame, ModManager.CurrentPlatform);

        buttonRunGame.Text = GetPlayButtonText(ModManager.CurrentPlatform);
        PopulateModList();
        ShowToolTip();

        buttonRunGame.Enabled = CanApplyMods;
        buttonRestoreBackupDev.Enabled = CanApplyMods;
        buttonRunGameDev.Enabled = CanApplyMods;
        buttonSaveIso.Enabled = CanSaveIso;

        UpdatePlatformIcon();
    }

    private void UpdatePlatformIcon()
    {
        switch (ModManager.CurrentPlatform)
        {
            case GamePlatform.GameCube:
                pictureBoxPlatform.Image = Resources.gamecube;
                break;
            case GamePlatform.PlayStation2:
                pictureBoxPlatform.Image = Resources.ps2;
                break;
            case GamePlatform.Xbox:
                pictureBoxPlatform.Image = Resources.xbox;
                break;
            default:
                pictureBoxPlatform.Image = null;
                break;
        }
    }

    private string GetPlayButtonText(GamePlatform platform)
    {
        string text = "Launch Game";

        switch (platform)
        {
            case GamePlatform.GameCube:
                text += " in Dolphin";
                break;
            case GamePlatform.Xbox:
                text += " in xemu";
                break;
            case GamePlatform.PlayStation2:
                text += " in PCSX2";
                break;
        }

        return text;
    }

    private void emulatorSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var settingsForm = new SettingsForm();
        settingsForm.ShowDialog(this);

        buttonRunGame.Enabled = CanApplyMods;
        buttonRunGameDev.Enabled = CanApplyMods;
        buttonRestoreBackupDev.Enabled = CanApplyMods;
    }

    private void comboBoxGame_Leave(object sender, EventArgs e)
    {

    }

    private void comboBoxPlatform_Leave(object sender, EventArgs e)
    {

    }

    private void showISOAfterSavingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ModManager.OpenIsoAfterExport = !ModManager.OpenIsoAfterExport;
        showISOAfterSavingToolStripMenuItem.Checked = ModManager.OpenIsoAfterExport;
    }

    private void downloadXdvdfsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Prompt the user if they want to download.
        PromptToDownloadXdvdfs();
    }

    private async Task<bool> PromptToDownloadXdvdfs()
    {
        var result = MessageBox.Show(
            "This will download the XDVDFS tool, which is required to extract and build Xbox game ISOs.\nEstimated size on disk: 3.45MB.\n\nDo you want to proceed?",
            "Download XDVDFS",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                await ModManager.DownloadLatestXdvdfsAsync();
                TaskbarFlasher.Flash(this.Handle);
                MessageBox.Show("XDVDFS downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaskbarFlasher.Stop(this.Handle);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to download XDVDFS:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        return false;
    }

    private async Task<bool> PromptToDownloadMkisofs()
    {
        var result = MessageBox.Show(
            "This will download the mkisofs tool and cygwin, which is required to build Playstation 2 ISOs.\nEstimated size on disk: 4.64MB.\n\nDo you want to proceed?",
            "Download mkisofs",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                await ModManager.DownloadAndExtractMkisofs();
                TaskbarFlasher.Flash(this.Handle);
                MessageBox.Show("mkisofs downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaskbarFlasher.Stop(this.Handle);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to download mkisofs:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        return false;
    }

    private void downloadMkisofsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        PromptToDownloadMkisofs();
    }

    private void buttonBrowseMods_Click(object sender, EventArgs e)
    {
        // Open url in browser
        string url = "https://heavyironmodding.org/wiki/Mods";

        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open browser:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
