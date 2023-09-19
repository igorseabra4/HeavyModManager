﻿using HeavyModManager.Classes;
using HeavyModManager.Enum;
using HeavyModManager.Forms;
using HeavyModManager.Functions;
using System.Text.Json;

namespace HeavyModManager;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        toolTip = new ToolTip();
        aboutBox = new AboutBox();

        foreach (Game game in ModManager.Games)
            comboBoxGame.Items.Add(new ComboBoxGameItem(game));

        ModManager.LoadSettings();

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
        ModManager.SaveSettings();
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
        buttonApplyMods.Enabled = comboBoxGame.SelectedIndex != -1 && ModManager.GameBackupExists;
        buttonRunGame.Enabled = comboBoxGame.SelectedIndex != -1 && ModManager.GameExists;
        buttonCreateBackup.Enabled = comboBoxGame.SelectedIndex != -1;

        ShowToolTip();

        ModManager.SaveSettings();
    }

    private readonly ToolTip toolTip;

    private void ShowToolTip()
    {
        toolTip.Hide(comboBoxGame);

        if (string.IsNullOrEmpty(ModManager.DolphinPath))
        {
            toolTip.Show("Dolphin executable path not set.\nPlease click on Settings -> Choose Dolphin Path and select the Dolphin executable.", comboBoxGame, 0, 24, 12 * 1000);
        }
        else if (comboBoxGame.SelectedIndex != -1)
        {
            if (!ModManager.GameBackupExists)
                toolTip.Show("You do not have a backup for this game.\nPlease click on \"Create Backup\" and select the game's ISO file.", comboBoxGame, 0, 24, 8 * 1000);
            else if (listMods.Items.Count == 0)
                toolTip.Show("You do not have mods for this game.\nPlease click on \"Install Mod\" and select a mod ZIP file.", comboBoxGame, 0, 24, 8 * 1000);
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
        if (listMods.SelectedIndices.Count == 1)
        {
            var mod = (Mod)listMods.SelectedItem;
            var prev = listMods.SelectedIndex;
            new CreateMod(mod).ShowDialog();
            ModManager.RefreshModList();
            PopulateModList();
            listMods.SelectedIndex = prev;
        }
    }

    private void openModFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listMods.SelectedIndices.Count == 1)
        {
            var mod = (Mod)listMods.SelectedItem;
            System.Diagnostics.Process.Start("explorer.exe", ModManager.GetModPath(mod.ModId));
        }
    }

    private void deleteModToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listMods.SelectedIndices.Count == 1)
        {
            var mod = (Mod)listMods.SelectedItem;
            var dr = MessageBox.Show($"Are you sure you want to delete the mod '{mod.ModName}' by '{mod.Author}'?", "Delete Mod", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
                ModManager.DeleteMod(mod.ModId);
            PopulateModList();
        }
    }

    private void zipModToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listMods.SelectedIndices.Count == 1)
        {
            var mod = (Mod)listMods.SelectedItem;
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

    private bool activeModWithCheats = false;

    private void PopulateModList()
    {
        programChangingData = true;

        labelModInfo.Text = "";
        listMods.Items.Clear();

        editModToolStripMenuItem.Enabled = false;
        deleteModToolStripMenuItem.Enabled = false;
        zipModToolStripMenuItem.Enabled = false;
        openModFolderToolStripMenuItem.Enabled = false;

        activeModWithCheats = false;

        foreach (var modId in ModManager.CurrentGameSettings.Mods)
        {
            var mod = JsonSerializer.Deserialize<Mod>(File.ReadAllText(ModManager.GetModJsonPath(modId)));
            bool active = ModManager.CurrentGameSettings.ActiveMods.Contains(mod.ModId);
            listMods.Items.Add(mod, active);

            if (active)
                SetActiveModWithCheats(mod);
        }

        UpdateDolphinLabel();

        programChangingData = false;
    }

    private void SetActiveModWithCheats(Mod mod)
    {
        if (!string.IsNullOrEmpty(mod.ArCodes) || !string.IsNullOrEmpty(mod.GeckoCodes))
            activeModWithCheats = true;
    }

    private void listMods_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (programChangingData)
            return;

        var mod = (Mod)listMods.Items[e.Index];

        if (e.NewValue == CheckState.Checked)
            ModManager.CurrentGameSettings.ActivateMod(mod.ModId);
        else
            ModManager.CurrentGameSettings.DeactivateMod(mod.ModId);

        SetActiveModWithCheats(mod);
        ModManager.SaveGameSettings();
    }

    private void listMods_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listMods.SelectedIndex == -1)
        {
            labelModInfo.Text = "";
            editModToolStripMenuItem.Enabled = false;
            deleteModToolStripMenuItem.Enabled = false;
            zipModToolStripMenuItem.Enabled = false;
            openModFolderToolStripMenuItem.Enabled = false;
        }
        else
        {
            var mod = (Mod)listMods.SelectedItem;
            labelModInfo.Text = $"Author: {mod.Author}\n\n" +
                $"Description:\n{mod.Description}\n\n" +
                $"Mod ID:\n{mod.ModId}\n\n" +
                //$"Has AR codes: {(string.IsNullOrEmpty(mod.ArCodes) ? "No" : "Yes")}\n" +
                //$"Has Gecko codes: {(string.IsNullOrEmpty(mod.GeckoCodes) ? "No" : "Yes")}" +
                "";
            editModToolStripMenuItem.Enabled = true;
            deleteModToolStripMenuItem.Enabled = true;
            zipModToolStripMenuItem.Enabled = true;
            openModFolderToolStripMenuItem.Enabled = true;
        }
    }

    private void buttonMoveUp_Click(object sender, EventArgs e)
    {
        if (listMods.SelectedItems.Count == 1)
        {
            int previndex = listMods.SelectedIndex;

            if (previndex > 0)
            {
                (ModManager.CurrentGameSettings.Mods[previndex], ModManager.CurrentGameSettings.Mods[previndex - 1]) = (ModManager.CurrentGameSettings.Mods[previndex - 1], ModManager.CurrentGameSettings.Mods[previndex]);
                ModManager.Invalidate();
            }

            PopulateModList();
            listMods.SelectedIndex = Math.Max(previndex - 1, 0);
        }
    }

    private void buttonMoveDown_Click(object sender, EventArgs e)
    {
        if (listMods.SelectedItems.Count == 1)
        {
            int previndex = listMods.SelectedIndex;

            if (previndex < listMods.Items.Count - 1)
            {
                (ModManager.CurrentGameSettings.Mods[previndex], ModManager.CurrentGameSettings.Mods[previndex + 1]) = (ModManager.CurrentGameSettings.Mods[previndex + 1], ModManager.CurrentGameSettings.Mods[previndex]);
                ModManager.Invalidate();
            }

            PopulateModList();
            listMods.SelectedIndex = Math.Min(previndex + 1, listMods.Items.Count - 1);
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

            buttonApplyMods.Enabled = comboBoxGame.SelectedIndex != -1 && ModManager.GameBackupExists;
            buttonRunGame.Enabled = comboBoxGame.SelectedIndex != -1 && ModManager.GameExists;
        }
    }

    private void buttonApplyMods_Click(object sender, EventArgs e)
    {
        Enabled = false;
        ModManager.ApplyMods(developerModeToolStripMenuItem.Checked);
        Enabled = true;
        buttonRunGame.Enabled = comboBoxGame.SelectedIndex != -1 && ModManager.GameExists;
    }

    private void buttonRunGame_Click(object sender, EventArgs e)
    {
        Enabled = false;
        ModManager.ApplyMods(developerModeToolStripMenuItem.Checked);
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
        UpdateDolphinLabel();
        ShowToolTip();
    }

    private void developerModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        developerModeToolStripMenuItem.Checked = !developerModeToolStripMenuItem.Checked;
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

        labelDolphin.Text = "Dolphin path: " + ModManager.DolphinPath;

        if (developerModeToolStripMenuItem.Checked)
        {
            labelDolphin.Text += "\nDeveloper Mode";
        }

        if (activeModWithCheats)
        {
            labelDolphin.Text += "\nOne or more active mods use codes. Remember to activate \"Enable Cheats\" on Dolphin settings.";
        }
    }

    private void listMods_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Delete)
        {
            deleteModToolStripMenuItem_Click(sender, e);
        }
    }

    private void listMods_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            deleteModToolStripMenuItem_Click(sender, e);
        }
    }
}