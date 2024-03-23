using HeavyModManager.Classes;
using HeavyModManager.Enum;
using HeavyModManager.Forms;
using HeavyModManager.Forms.Other;
using HeavyModManager.Functions;
using System.Globalization;
using System.Text.Json;
using System.Resources;

namespace HeavyModManager;

public partial class MainForm : Form
{
    private ResourceManager ResourceManager = new ResourceManager("HeavyModManager.MainForm",
        typeof(Program).Assembly);


    public MainForm()
    {
        var settings = LoadSettings();
        InitializeComponent();
        UpdateFormSize(settings);
        UpdateCurrentLanguageMenuItem();

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

        int tooltipX = 0;
        int tooltipY = 24;
        int tooltipDurationMs = 12 * 1000;

        // Display localised strings (from MainForm.resx) in tooltips instead of hard-coded string.
        if (string.IsNullOrEmpty(ModManager.DolphinPath))
        {
            toolTip.Show(ResourceManager.GetString("dolphinPathNotSetTooltip"),
                comboBoxGame, tooltipX, tooltipY, tooltipDurationMs);
        }
        else if (string.IsNullOrEmpty(ModManager.DolphinFolderPath))
        {
            toolTip.Show(ResourceManager.GetString("dolphinUserFolderPathNotSetTooltip"),
                comboBoxGame, tooltipX, tooltipY, tooltipDurationMs);
        }
        else if (comboBoxGame.SelectedIndex != -1)
        {
            if (!ModManager.GameBackupExists)
                toolTip.Show(ResourceManager.GetString("noBackupTooltip"), comboBoxGame, tooltipX, tooltipY, tooltipDurationMs);
            //toolTip.Show("You do not have a backup for this game.\nPlease click on \"Create Backup\" and select the game's ISO file.", comboBoxGame, 0, 24, 8 * 1000);
            else if (listViewMods.Items.Count == 0)
                toolTip.Show(ResourceManager.GetString("noModsTooltip"), comboBoxGame, tooltipX, tooltipY, tooltipDurationMs);
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
            string message = string.Format(ResourceManager.GetString("confirmDeleteMod"), mod.ModName, mod.Author);

            var dr = MessageBox.Show(
                message,
                ResourceManager.GetString("confirmDeleteModTitle"),
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
                    ResourceManager.GetString("errorCreatingModZip") + " " + ex.Message,
                    ResourceManager.GetString("error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            Filter = ResourceManager.GetString("isoOrMainDol") + "|*.iso;main.dol|All files(*.*)|*.*",
            Title = ResourceManager.GetString("selectGameTitle")
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
                MessageBox.Show(ResourceManager.GetString("unsupportedFiletype"),
                    ResourceManager.GetString("error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        buttonApplyMods.Enabled = CanApplyMods;
    }

    private void buttonRefreshModList_Click(object sender, EventArgs e)
    {
        ModManager.RefreshModList();
        PopulateModList();
        buttonApplyMods.Enabled = CanApplyMods;
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
            labelDolphin.Text = ResourceManager.GetString("dolphinPathNotSetLabel");
            return;
        }

        if (!File.Exists(ModManager.DolphinPath))
        {
            labelDolphin.Text = ResourceManager.GetString("dolphinNotFoundLabel");
            return;
        }

        if (string.IsNullOrEmpty(ModManager.DolphinFolderPath))
        {
            labelDolphin.Text = ResourceManager.GetString("dolphinPathNotSetLabel");
            return;
        }

        if (!Directory.Exists(ModManager.DolphinFolderPath))
        {
            labelDolphin.Text = ResourceManager.GetString("dolphinUserFolderNotFoundLabel");
            return;
        }

        labelDolphin.Text = $"{ResourceManager.GetString("dolphin")} {ModManager.DolphinPath}\n{ResourceManager.GetString("dolphinUserFolder")} {ModManager.DolphinFolderPath}";

        if (ModManager.DeveloperMode)
            labelDolphin.Text += "\n" + ResourceManager.GetString("developerMode");
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

}