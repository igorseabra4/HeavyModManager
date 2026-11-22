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
        UpdateColumnToggles();

        EnableFileDragDrop(this);
    }

    private void EnableFileDragDrop(Control control)
    {
        control.AllowDrop = true;

        control.DragEnter += FileDragEnter;
        control.DragDrop += FileDragDrop;

        foreach (Control child in control.Controls)
            EnableFileDragDrop(child);
    }

    private void FileDragEnter(object? sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.None;
            return;
        }

        var files = (string[])e.Data.GetData(DataFormats.FileDrop);

        e.Effect = files.All(IsValidFile)
            ? DragDropEffects.Copy
            : DragDropEffects.None;
    }

    private void FileDragDrop(object? sender, DragEventArgs e)
    {
        var files = (string[]?)e?.Data?.GetData(DataFormats.FileDrop);
        if (files == null || files.Length == 0)
            return;

        foreach (var file in files)
            if (IsValidFile(file))
                ZipManager.InstallMod(file);

        ModManager.RefreshModList();
        PopulateModList();
    }

    private static bool IsValidFile(string file) => Path.GetExtension(file).Equals(".zip", StringComparison.OrdinalIgnoreCase);

    private void UpdateColumnToggles()
    {
        foreach (ToolStripMenuItem item in listColumnsToolStripMenuItem.DropDownItems)
        {
            if (item.Tag is string columnTag)
            {
                var column = listViewMods.Columns.Cast<ColumnHeader>().FirstOrDefault(c => c.Tag as string == columnTag);
                if (column != null)
                {
                    item.Checked = column.Width > 0;
                }
            }
        }
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
                listViewMods.Columns[i].Width = settings.ColumnSizes[i];
            }
    }

    private AboutBox aboutBox;

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        aboutBox.ShowDialog();
    }

    private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
    {
        var newGame = ((ComboBoxGameItem)comboBoxGame.SelectedItem).Game;
        var platforms = ModManager.SupportedPlatformsForGame(newGame);
        GamePlatform newPlatform = comboBoxPlatform.SelectedIndex != -1 ? ((ComboBoxPlatformItem)comboBoxPlatform.SelectedItem).Platform : GamePlatform.Unknown;
        if (!platforms.Contains(newPlatform))
            newPlatform = platforms.First();

        ModManager.SetCurrentGamePlatform(newGame, newPlatform);

        PopulateModList();

        buttonRestoreBackupDev.Enabled = CanApplyMods;
        buttonRunGameDev.Enabled = CanApplyMods;
        buttonSaveIso.Enabled = CanSaveIso;
        buttonRunGame.Enabled = CanApplyMods;

        buttonRunGame.Text = GetPlayButtonText(ModManager.CurrentPlatform);

        programaticPlatformChange = true;

        comboBoxPlatform.Items.Clear();
        foreach (var plat in platforms)
        {
            comboBoxPlatform.Items.Add(new ComboBoxPlatformItem(plat));
            if (plat == newPlatform)
                comboBoxPlatform.SelectedIndex = comboBoxPlatform.Items.Count - 1;
        }

        programaticPlatformChange = false;

        ShowToolTip();
        SaveSettings();
        UpdatePlatformIcon();
    }

    private bool programaticPlatformChange = false;

    private void comboBoxPlatform_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (programaticPlatformChange)
            return;

        ModManager.SetCurrentGamePlatform(ModManager.CurrentGame,
            comboBoxPlatform.SelectedIndex == -1 ?
            GamePlatform.Unknown :
            ((ComboBoxPlatformItem)comboBoxPlatform.SelectedItem).Platform);

        buttonRunGame.Text = GetPlayButtonText(ModManager.CurrentPlatform);
        PopulateModList();
        ShowToolTip();

        buttonRunGame.Enabled = CanApplyMods;
        buttonRestoreBackupDev.Enabled = CanApplyMods;
        buttonRunGameDev.Enabled = CanApplyMods;
        buttonSaveIso.Enabled = CanSaveIso;

        SaveSettings();
        UpdatePlatformIcon();
    }

    private bool CanApplyMods => comboBoxGame.SelectedIndex != -1 &&
        ModManager.GameBackupExists() &&
        ModManager.EmulatorPathIsSet(ModManager.CurrentPlatform);

    private bool CanSaveIso => comboBoxGame.SelectedIndex != -1 &&
        ModManager.GameBackupExists();

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
            if (!ModManager.GameBackupExists())
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
            Process.Start("explorer.exe", ModManager.GetModPath(mod.ModId));
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
                ZipManager.ZipMod(mod.ModId, ZipManager.CreateModZipName(mod));
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

    private int programaticCheckChanges = 0;
    private int _sortColumn = -1;
    private bool _sortAscending = true;

    private void PopulateModList(string selectedModId = "")
    {
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

        foreach (var modId in ModManager.CurrentGameSettings.Mods.ToList())
        {
            var modJsonPath = ModManager.GetModJsonPath(modId);
            if (!File.Exists(modJsonPath))
            {
                ModManager.CurrentGameSettings.RemoveMod(modId);
                continue;
            }
            var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));
            bool active = ModManager.CurrentGameSettings.ActiveMods.Contains(mod.ModId);
            if (mod.Platform == activePlatform || mod.Platform == GamePlatform.Unknown)
            {
                if (active)
                    programaticCheckChanges++;
                listViewMods.Items.Add(ListViewItemFromMod(mod, active, selectedModId == mod.ModId));
            }
        }

        UpdateStatusLabel();
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
            new(item, mod.Author),
            new(item, ModManager.PlatformToStringFull(mod.Platform)),
            new(item, mod.Version),
            new(item, mod.CreatedAt.ToShortDateString()),
            new(item, mod.UpdatedAt.ToShortDateString()),
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
        if (programaticCheckChanges > 0)
        {
            programaticCheckChanges--;
            return;
        }
        if (e.NewValue == e.CurrentValue)
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

        ModManager.SaveGameSettings();
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
        if (mod == null)
            return;

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
        if (mod == null)
            return;

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
            if (!File.Exists(modJsonPath))
                continue;
            var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(modJsonPath));
            if (mod.Platform == activePlatform || mod.Platform == GamePlatform.Unknown)
                indices.Add(i);
        }

        return indices;
    }

    private void listViewMods_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        return;

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
            if (!File.Exists(modJsonPath))
                continue;
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

    private async void buttonCreateBackup_Click(object sender, EventArgs e)
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
                        result = ModManager.RestoreBackupIso(openFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred while restoring backup from ISO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    result = ModManager.RestoreBackupFromFolder(Path.GetDirectoryName(openFile.FileName));
                }

                if (result == ModManager.Result.Success)
                {
                    done = true;
                    TaskbarFlasher.Flash(this.Handle);
                    MessageBox.Show(
                        $"Game backup for {ModManager.GameToStringFull(ModManager.CurrentGame)} ({ModManager.PlatformToStringFull(ModManager.CurrentPlatform)}) succesfully created. You can apply mods now.",
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
        ModManager.ResetGameFromBackup();
        Enabled = true;
    }

    private async void buttonRunGameDev_Click(object sender, EventArgs e)
    {
        Enabled = false;
        ModManager.CloseEmulator();
        if (await ApplyMods())
            RunGame();
        Enabled = true;
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

        bool run = true;
        if (ModManager.CurrentGameSettings.Invalidated)
        {
            run = await Task.Run(() =>
            {
                ModManager.ResetGameFromBackup();
                return ApplyMods();
            });
        }

        progressBar.Close();
        Enabled = true;
        if (run)
            RunGame();
    }

    private async Task<bool> ApplyMods(bool createIso = true)
    {
        var result = await ModManager.ApplyMods(createIso);

        if (result == ModManager.Result.MissingXdvdfs)
            return await PromptToDownloadXdvdfs();

        if (result == ModManager.Result.MissingImgBurn)
            PromptToDownloadImgBurn();

        return result == ModManager.Result.Success;
    }

    private async void RunGame()
    {
        try
        {
            var result = await ModManager.RunGameAsync();

            if (result == ModManager.Result.EmulatorNotFound)
            {
                // warn user
                MessageBox.Show(
                    $"Emulator not found. Please set the emulator path for {ModManager.PlatformToStringFull(ModManager.CurrentPlatform)} in the settings.",
                    "Emulator not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            buttonOpenGameFolderDev.Visible = true;
        }
        else
        {
            buttonRestoreBackupDev.Visible = false;
            buttonRunGameDev.Visible = false;
            buttonRunGame.Visible = true;
            buttonOpenGameFolderDev.Visible = false;
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
            {
                text += " - " + GlobalResources.developerMode;
                if (MessageReceived != null)
                    text += " | Latest Message: " + MessageReceived;
            }

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

        // TODO: warn user if any enabled mods contain AR or Gecko codes, as those are not applied whenbuilding ISO

        if (ModManager.DeveloperMode || ModManager.CurrentGameSettings.Invalidated)
        {
            var run = await Task.Run(async () =>
            {
                ModManager.ResetGameFromBackup();

                return await ApplyMods(false);

            });
            if (!run)
                return;
        }

        progressBar.SetDetails("Saving to file...");
        try
        {
            while (true)
            {
                long expectedSize = ModManager.GetDirectorySize(ModManager.GameGamePath);
                var creationTask = Task.Run(() =>
                {
                    return ModManager.BuildIso(dialog.FileName);
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
                if (result != ModManager.Result.Success)
                {
                    MessageBox.Show(
                        "ISO creation failed.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
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

    private void PromptToDownloadImgBurn()
    {
        var result = MessageBox.Show(
            "ImgBurn is required to create PlayStation 2 ISOs. Please download and install it, and locate ImgBurn.exe under Settings.\n\nOpen the download page now?",
            "Download ImgBurn",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

        if (result == DialogResult.Yes)
        {
            string url = "https://www.softpedia.com/get/CD-DVD-Tools/Data-CD-DVD-Burning/ImgBurn.shtml";
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

    private void buttonOpenGameFolderDev_Click(object sender, EventArgs e)
    {
        Process.Start("explorer.exe", ModManager.GameFolderPath);
    }

    private void toggleColumnStripMenuItem_Click(object sender, EventArgs e)
    {
        var iteme = (ToolStripItem)sender;

        // Get the tag of the menu strip item that was clicked. The listview column has the same name as the tag.
        if (sender is ToolStripMenuItem item && item.Tag is string columnName)
        {
            // Find the column in the listview with the same name as the tag
            var column = listViewMods.Columns.Cast<ColumnHeader>().FirstOrDefault(c => c.Tag.ToString() == columnName);

            if (column != null)
            {
                // Toggle the visibility of the column
                column.Width = column.Width == 0 ? -2 : 0;

                // Update the checked state of the menu strip item
                item.Checked = column.Width != 0;
            }
        }
    }

    private void listViewMods_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
    {
        UpdateColumnToggles();
    }
}
