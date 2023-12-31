﻿using HeavyModManager.Classes;
using HeavyModManager.Enum;
using HeavyModManager.Forms;
using HeavyModManager.Forms.Other;
using HeavyModManager.Functions;
using System.Text.Json;

namespace HeavyModManager;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        LoadSettings();
        IconManager.SetIcon(this);

        toolTip = new ToolTip();
        aboutBox = new AboutBox();

        foreach (Game game in ModManager.EvilEngineGames)
            comboBoxGame.Items.Add(new ComboBoxGameItem(game));

        developerModeToolStripMenuItem.Checked = ModManager.DeveloperMode;
        checkForUpdatesOnStartupToolStripMenuItem.Checked = ModManager.CheckForUpdatesOnStartup;

        if (ModManager.CheckForUpdatesOnStartup)
            TryUpdate();

        if (ModManager.CurrentGame == Game.Null)
            comboBoxGame.SelectedIndex = -1;
        else
            for (int i = 0; i < comboBoxGame.Items.Count; i++)
                if (((ComboBoxGameItem)comboBoxGame.Items[i]).Game == ModManager.CurrentGame)
                {
                    comboBoxGame.SelectedIndex = i;
                    break;
                }

        labelModInfo.AutoSize = true;
        labelModInfo.MaximumSize = new Size(panelLabelModInfo.Width - SystemInformation.VerticalScrollBarWidth, 0);
        labelModInfo.Text = "";

        UpdateDolphinLabel();
    }

    private async void TryUpdate()
    {
        if (await AutomaticUpdater.Update())
        {
            Close();
            System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "HeavyModManager.exe"));
        }
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
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

        ModManager.SaveSettings(settings);
    }

    private void LoadSettings()
    {
        var settings = ModManager.LoadSettings();

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

        createModToolStripMenuItem.Enabled = true;
        groupBoxMods.Enabled = comboBoxGame.SelectedIndex != -1;
        buttonApplyMods.Enabled = CanApplyMods;
        buttonRunGame.Enabled = CanRunGame;
        buttonCreateBackup.Enabled = comboBoxGame.SelectedIndex != -1;

        ShowToolTip();

        SaveSettings();
    }

    private bool CanApplyMods => comboBoxGame.SelectedIndex != -1 &&
        ModManager.GameBackupExists &&
        !string.IsNullOrWhiteSpace(ModManager.DolphinPath) &&
        !string.IsNullOrWhiteSpace(ModManager.DolphinFolderPath);

    private bool CanRunGame => comboBoxGame.SelectedIndex != -1 &&
        ModManager.GameExists &&
        !string.IsNullOrWhiteSpace(ModManager.DolphinPath) &&
        !string.IsNullOrWhiteSpace(ModManager.DolphinFolderPath);

    private readonly ToolTip toolTip;

    private void ShowToolTip()
    {
        toolTip.Hide(comboBoxGame);

        if (string.IsNullOrEmpty(ModManager.DolphinPath))
        {
            toolTip.Show("Dolphin executable path not set.\n" +
                "Please click on Settings -> Choose Dolphin Path and select the Dolphin executable.\n" +
                "It is usually located under \"C:\\Program Files\\Dolphin-x64\\Dolphin.exe\". Selecting a shortcut is also possible.", comboBoxGame, 0, 24, 12 * 1000);
        }
        else if (string.IsNullOrEmpty(ModManager.DolphinFolderPath))
        {
            toolTip.Show("Dolphin user folder path not set.\n" +
                "Please click on Settings -> Choose Dolphin User Folder Path and select the Dolphin user folder\n" +
                "It is usually located under \"Documents\\Dolphin Emulator\".", comboBoxGame, 0, 24, 12 * 1000);
        }
        else if (comboBoxGame.SelectedIndex != -1)
        {
            if (!ModManager.GameBackupExists)
                toolTip.Show("You do not have a backup for this game.\nPlease click on \"Create Backup\" and select the game's ISO file.", comboBoxGame, 0, 24, 8 * 1000);
            else if (listViewMods.Items.Count == 0)
                toolTip.Show("You do not have mods for this game.\nPlease click on \"Add Mods\" and select a mod ZIP file.", comboBoxGame, 0, 24, 8 * 1000);
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
            var dr = MessageBox.Show($"Are you sure you want to delete the mod '{mod.ModName}' by '{mod.Author}'?", "Delete Mod", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                MessageBox.Show("There was an error creating your mod ZIP archive: " + ex.Message);
            }
        }
    }

    private bool programChangingData = false;

    private void PopulateModList(string selectedModId = "")
    {
        programChangingData = true;

        labelModInfo.Text = "";
        listViewMods.Items.Clear();

        editModToolStripMenuItem.Enabled = false;
        deleteModToolStripMenuItem.Enabled = false;
        zipModToolStripMenuItem.Enabled = false;
        openModFolderToolStripMenuItem.Enabled = false;

        foreach (var modId in ModManager.CurrentGameSettings.Mods)
        {
            var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(ModManager.GetModJsonPath(modId)));
            bool active = ModManager.CurrentGameSettings.ActiveMods.Contains(mod.ModId);
            listViewMods.Items.Add(ListViewItemFromMod(mod, active, selectedModId == mod.ModId));
        }

        UpdateDolphinLabel();

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

        ModManager.SaveGameSettings();
    }

    private void listViewMods_SelectedIndexChanged(object sender, EventArgs e)
    {
        labelModInfo.Text = "";

        var mod = GetSelectedMod();

        if (mod != null)
        {
            if (!string.IsNullOrWhiteSpace(mod.Description))
                labelModInfo.Text += $"{mod.Description}\n\n";

            if (!string.IsNullOrEmpty(mod.GameId))
                labelModInfo.Text += $"Has a custom save file: {mod.GameId}\n";

            if (!string.IsNullOrEmpty(mod.MergeFiles))
                labelModInfo.Text += "Has HIP/HOP files for merging\n";

            if (!string.IsNullOrEmpty(mod.DOLPatches))
                labelModInfo.Text += "Has DOL Patches\n";

            if (!string.IsNullOrEmpty(mod.ArCodes))
                labelModInfo.Text += "Has AR Codes\n";

            if (!string.IsNullOrEmpty(mod.GeckoCodes))
                labelModInfo.Text += "Has Gecko Codes\n";

            if (!labelModInfo.Text.EndsWith("\n\n"))
                labelModInfo.Text += "\n";

            labelModInfo.Text += $"Mod ID:\n{mod.ModId}\n\n";

            editModToolStripMenuItem.Enabled = true;
            deleteModToolStripMenuItem.Enabled = true;
            zipModToolStripMenuItem.Enabled = true;
            openModFolderToolStripMenuItem.Enabled = true;
        }
        else
        {
            editModToolStripMenuItem.Enabled = false;
            deleteModToolStripMenuItem.Enabled = false;
            zipModToolStripMenuItem.Enabled = false;
            openModFolderToolStripMenuItem.Enabled = false;
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
        if (mod != null)
        {
            int previndex = listViewMods.SelectedIndices[0];
            if (previndex > 0)
            {
                (ModManager.CurrentGameSettings.Mods[previndex], ModManager.CurrentGameSettings.Mods[previndex - 1]) = (ModManager.CurrentGameSettings.Mods[previndex - 1], ModManager.CurrentGameSettings.Mods[previndex]);
                ModManager.Invalidate();
            }
            PopulateModList(mod.ModId);
        }
    }

    private void buttonMoveDown_Click(object sender, EventArgs e)
    {
        var mod = GetSelectedMod();
        if (mod != null)
        {
            int previndex = listViewMods.SelectedIndices[0];
            if (previndex < listViewMods.Items.Count - 1)
            {
                (ModManager.CurrentGameSettings.Mods[previndex], ModManager.CurrentGameSettings.Mods[previndex + 1]) = (ModManager.CurrentGameSettings.Mods[previndex + 1], ModManager.CurrentGameSettings.Mods[previndex]);
                ModManager.Invalidate();
            }
            PopulateModList(mod.ModId);
        }
    }

    private void buttonRestoreBackup_Click(object sender, EventArgs e)
    {
        var openFile = new OpenFileDialog()
        {
            Filter = "ISO or main.dol|*.iso;main.dol",
            Title = "Please select your game's ISO or the main.dol from an unchanged Dolphin dump."
        };

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            Enabled = false;

            if (Path.GetExtension(openFile.FileName).ToLower().Equals(".iso"))
            {
                ModManager.RestoreBackupIso(openFile.FileName);
            }
            else if (Path.GetExtension(openFile.FileName).ToLower().Equals(".dol"))
            {
                ModManager.RestoreBackupDol(Path.GetDirectoryName(Path.GetDirectoryName(openFile.FileName)));
            }
            else
            {
                MessageBox.Show("Unsupported file type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Enabled = true;

            buttonApplyMods.Enabled = CanApplyMods;
            buttonRunGame.Enabled = CanRunGame;
        }
    }

    private void buttonApplyMods_Click(object sender, EventArgs e)
    {
        Enabled = false;
        ModManager.ApplyMods(true);
        Enabled = true;
        buttonRunGame.Enabled = CanRunGame;
    }

    private void buttonRunGame_Click(object sender, EventArgs e)
    {
        Enabled = false;
        ModManager.ApplyMods();
        Enabled = true;
        ModManager.RunGame();
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

    private void chooseDolphinPathToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ModManager.SetDolphinPath();
        SaveSettings();
        UpdateDolphinLabel();
        ShowToolTip();
    }

    private void chooseDolphinUserFolderPathToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ModManager.SetDolphinFolderPath();
        SaveSettings();
        UpdateDolphinLabel();
        ShowToolTip();
    }

    private void developerModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ModManager.DeveloperMode = !ModManager.DeveloperMode;
        developerModeToolStripMenuItem.Checked = ModManager.DeveloperMode;
        ModManager.Invalidate();
        UpdateDolphinLabel();
    }

    private void checkForUpdatesOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ModManager.CheckForUpdatesOnStartup = !ModManager.CheckForUpdatesOnStartup;
        checkForUpdatesOnStartupToolStripMenuItem.Checked = ModManager.CheckForUpdatesOnStartup;
    }

    private void UpdateDolphinLabel()
    {
        if (string.IsNullOrEmpty(ModManager.DolphinPath))
        {
            labelDolphin.Text = "Dolphin executable path not set.";
            return;
        }

        if (!File.Exists(ModManager.DolphinPath))
        {
            labelDolphin.Text = "Dolphin executable not found on set path.";
            return;
        }

        if (string.IsNullOrEmpty(ModManager.DolphinFolderPath))
        {
            labelDolphin.Text = "Dolphin user folder path not set.";
            return;
        }

        if (!Directory.Exists(ModManager.DolphinFolderPath))
        {
            labelDolphin.Text = "Dolphin user folder not found on set path.";
            return;
        }

        labelDolphin.Text = $"Dolphin: {ModManager.DolphinPath}\nDolphin user folder: {ModManager.DolphinFolderPath}";

        if (ModManager.DeveloperMode)
            labelDolphin.Text += "\nDeveloper Mode";
    }

    private void changeIconToolStripMenuItem_Click(object sender, EventArgs e)
    {
        IconManager.ChangeIcon();
        IconManager.SetIcon(this);
        IconManager.SetIcon(aboutBox);
    }
}