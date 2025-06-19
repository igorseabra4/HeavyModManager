﻿using HeavyModManager.Classes;
using HeavyModManager.Enum;
using HeavyModManager.Functions;

namespace HeavyModManager.Forms;

public partial class CreateMod : Form
{
    public CreateMod()
    {
        isEditing = false;

        InitializeComponent();
        toolTip = new ToolTip();

        defaultBackgroundColor = textBoxGameId.BackColor;

        foreach (Game game in ModManager.EvilEngineGames)
            comboBoxGame.Items.Add(new ComboBoxGameItem(game));

        dateTimePickerCreatedAt.Value = DateTime.Now;
        dateTimePickerUpdatedAt.Value = DateTime.Now;

        buttonIniImport.Enabled = false;
    }

    private bool isEditing;
    private Game prevGame;

    public CreateMod(Mod mod)
    {
        isEditing = true;

        InitializeComponent();
        toolTip = new ToolTip();

        defaultBackgroundColor = textBoxGameId.BackColor;

        prevGame = mod.Game;
        textBoxModName.Text = mod.ModName;
        textBoxAuthor.Text = mod.Author;
        richTextBoxDescription.Text = mod.Description;
        textBoxModId.Text = mod.ModId;
        richTextBoxArCodes.Text = mod.ArCodes;
        richTextBoxGeckoCodes.Text = mod.GeckoCodes;
        textBoxGameId.Text = mod.GameId;
        richTextBoxINIValues.Text = mod.INIReplacements;
        richTextBoxMergeHips.Text = mod.MergeFiles;
        richTextBoxRemoveFiles.Text = mod.RemoveFiles;
        richTextBoxDolPatches.Text = mod.DOLPatches;
        textBoxIpsPatch.Text = mod.IpsPatchBase64;

        comboBoxGame.Items.Add(new ComboBoxGameItem(mod.Game));
        comboBoxGame.SelectedIndex = 0;
        SetDefaultGameID(mod.Game);
        comboBoxGame.Enabled = false;
        groupBoxGame.Enabled = false;
        groupBoxModId.Enabled = false;

        try
        {
            dateTimePickerCreatedAt.Value = mod.CreatedAt;
        }
        catch
        {
            dateTimePickerCreatedAt.Value = DateTime.Now;
        }

        try
        {
            dateTimePickerUpdatedAt.Value = mod.UpdatedAt;
        }
        catch
        {
            dateTimePickerUpdatedAt.Value = DateTime.Now;
        }

        Text = GlobalResources.editMod;
        buttonCreateMod.Text = GlobalResources.save;
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetCreateModEnabled();
        SetDefaultGameID(((ComboBoxGameItem)comboBoxGame.SelectedItem).Game);
        if (!isEditing)
            ResetModId();
    }

    private void textBoxModName_TextChanged(object sender, EventArgs e)
    {
        SetCreateModEnabled();
        if (!isEditing)
            ResetModId();
    }

    private void textBoxAuthor_TextChanged(object sender, EventArgs e)
    {
        SetCreateModEnabled();
        if (!isEditing)
            ResetModId();
    }

    private bool programChangingData = false;

    private void textBoxModId_TextChanged(object sender, EventArgs e)
    {
        if (programChangingData)
            return;

        SetCreateModEnabled();

        programChangingData = true;
        textBoxModId.Text = TreatString(textBoxModId.Text);
        programChangingData = false;
    }

    private void SetCreateModEnabled()
    {
        buttonCreateMod.Enabled = (isEditing || comboBoxGame.SelectedIndex > -1) &&
            TreatString(textBoxAuthor.Text).Length > 0 &&
            TreatString(textBoxModName.Text).Length > 0 &&
            textBoxModId.Text.Length > 0 &&
            (textBoxGameId.Text.Length == 0 || textBoxGameId.Text.Length == 6) &&
            DolPatchesValid() &&
            IniPatchesValid() &&
            ArCodesValid() &&
            GeckoCodesValid();
    }

    private void ResetModId()
    {
        var selectedGameItem = (ComboBoxGameItem)comboBoxGame.SelectedItem;
        var gameName = selectedGameItem == null ? "" : ModManager.GameToString(selectedGameItem.Game);
        string modId = $"{gameName}-{TreatString(textBoxAuthor.Text)}-{TreatString(textBoxModName.Text)}";

        textBoxModId.Text = modId;
    }

    private void buttonCreateMod_Click(object sender, EventArgs e)
    {
        if (!isEditing)
        {
            var existingModPath = ModManager.GetModPath(textBoxModId.Text);
            if (Directory.Exists(existingModPath))
            {
                MessageBox.Show(GlobalResources.modIdAlreadyExists,
                    GlobalResources.unableToCreateMod,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        var mod = new Mod()
        {
            Game = isEditing ? prevGame : ((ComboBoxGameItem)comboBoxGame.SelectedItem).Game,
            ModName = textBoxModName.Text,
            Author = textBoxAuthor.Text,
            Description = richTextBoxDescription.Text,
            ModId = textBoxModId.Text,
            GameId = textBoxGameId.Text,
            INIReplacements = richTextBoxINIValues.Text,
            MergeFiles = richTextBoxMergeHips.Text,
            RemoveFiles = richTextBoxRemoveFiles.Text,
            DOLPatches = richTextBoxDolPatches.Text,
            ArCodes = richTextBoxArCodes.Text,
            GeckoCodes = richTextBoxGeckoCodes.Text,
            CreatedAt = dateTimePickerCreatedAt.Value,
            UpdatedAt = dateTimePickerUpdatedAt.Value,
            IpsPatchBase64 = textBoxIpsPatch.Text,
        };

        string modPath = mod.SaveModJson(isEditing);

        MessageBox.Show(GlobalResources.modCreatedAt + " " + modPath,
            GlobalResources.modCreated,
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        System.Diagnostics.Process.Start("explorer.exe", modPath);

        Close();
    }

    private static readonly string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
    private static string TreatString(string text)
    {
        var result = "";
        foreach (var c in text)
            if (validChars.Contains(c))
                result += $"{c}".ToLower();
        return result;
    }

    private void SetDefaultGameID(Game game)
    {
        labelDefaultGameId.Text = $"{GlobalResources.labelDefaultGameIdText}: {ModManager.GameToGameID(game)}";
    }

    private Color defaultBackgroundColor;

    private void textBoxGameId_TextChanged(object sender, EventArgs e)
    {
        if (textBoxGameId.Text.Length == 0 || textBoxGameId.Text.Length == 6)
        {
            textBoxGameId.BackColor = defaultBackgroundColor;
        }
        else
        {
            textBoxGameId.BackColor = Color.Red;
        }

        SetCreateModEnabled();
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        toolTip.Hide(this);
    }

    private readonly ToolTip toolTip;

    private void ShowToolTip(string text)
    {
        toolTip.Hide(this);
        toolTip.Show(text, this, PointToClient(Cursor.Position), 20 * 1000);
    }

    private void buttonModIdInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip(GlobalResources.modIdInfo);
    }

    private void buttonGameIdInfo_Click(object sender, EventArgs e)
    {

        // todo: show compatible games (Scooby, BFBB, Movie, Incredibles, Underminer)
        ShowToolTip(GlobalResources.gameIdInfo);
    }

    private void buttonMergeHipsInfo_Click(object sender, EventArgs e)
    {
        // todo: show compatible games (Scooby, BFBB, Movie, Incredibles, Underminer, RatProto)
        ShowToolTip(GlobalResources.mergeHipsInfo);

        //ShowToolTip(
        //    "Enter your mod's HIP and HOP files which should be merged into the running\n" +
        //    "copy of the game instead of replacing the original ones, one per line.\n" +
        //    "Assets from the mod will be imported into the destination archive, replacing any\n" +
        //    "assets with the same asset ID if they exist, and assets of certain types will\n" +
        //    "be merged into one (namely: Collision Table, Jaw Data Table, Level of Detail Table,\n" +
        //    "Pipe Info Table, Shadow Table and Sound Info).\n\n" +
        //    "Example:\n\n" +
        //    "boot.HIP\n" +
        //    "hb\\hb01.HOP\n" +
        //    "mn\\mn04.HIP\n\n" +
        //    "Supported games: Scooby, BFBB, Movie, Incredibles, Underminer, RatProto");
    }

    private void buttonRemoveFilesInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip(GlobalResources.removeFilesInfo);
        //ShowToolTip(
        //    "Enter the folders or files present in the original game\n" +
        //    "which should be deleted from the mod, one per line.\n\n" +
        //    "Example:\n\n" +
        //    "boot.HIP\n" +
        //    "hb\\hb01.HOP\n" +
        //    "mn\\mn04.HIP\n\n" +
        //    "Supported games: Scooby, BFBB, Movie, Incredibles, Underminer, RatProto");
    }

    private void buttonIniValuesInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip(GlobalResources.IniValuesInfo);
        //ShowToolTip(
        //    "Enter the game's configuration INI key-value pairs for this mod, in the form of\n" +
        //    "<key>=<value>, one per line. You can add comments after #s. You only need to\n" +
        //    "enter the lines needed by your mod.\n" +
        //    "Example:\n\n" +
        //    "BOOT=HB00\n" +
        //    "ShowMenuOnBoot=0 # This is a comment\n" +
        //    "G.BubbleBowl=1\n" +
        //    "#another comment\n\n" +
        //    "On an already existing mod, click on 'Import' to import the mod's\n" +
        //    "INI into here. Only modified values will be imported and the file\n" +
        //    "itself will be deleted.\n\n" +
        //    "A few types of key are special because they can appear multiple times in the INI:\n" +
        //    "- ScenePlayerMapping, ThresholdPointsRange and AlternateCostumeMapping:\n" +
        //    "will replace values based on the stage ID name (first 4 characters of the value)\n" +
        //    "- TaskStatus and Extra: if present, will replace ALL entries, so if you're\n" +
        //    "replacing those, you must enter all of them.\n" +
        //    "If you're still unsure how to use these keys, create your INI file\n" +
        //    "manually, then use Import. The tool will import the values exactly\n" +
        //    "as they are needed.\n\n" +
        //    "Supported games: Scooby, BFBB, Movie, Incredibles, Underminer, RatProto");
    }

    private void buttonDolPatchesInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip(GlobalResources.DolPatchesInfo);
        //ShowToolTip(
        //    "Enter patches to be applied to the game's DOL file, in the form of\n" +
        //    "<offset> <value>, both 4-byte hexadecimal numbers, one per line.\n" +
        //    "You can add comments after #s.\n" +
        //    "Example:\n\n" +
        //    "00287D10 53494D50\n" +
        //    "00287DB0 54455854 # This is a comment\n" +
        //    "#another comment\n\n" +
        //    "Supported games: Scooby, BFBB, Movie, Incredibles, Underminer, RatProto");
    }

    private void buttonArCodesInfo_Click(object sender, EventArgs e)
    {
        ShowCodesInfo("Action Replay (AR)");
    }

    private void buttonGeckoCodesInfo_Click(object sender, EventArgs e)
    {
        ShowCodesInfo("Gecko");
    }

    private void ShowCodesInfo(string codeType)
    {
        ShowToolTip(codeType + " " + GlobalResources.showCodesInfo);
        //ShowToolTip(
        //    "Enter " + codeType + " codes to be applied by Dolphin. Format should be similar to\n" +
        //    "Dolphin Settings: Each code starts with $<code name>, then each line follows\n" +
        //    "the format <offset> <value>, both 4-byte hexadecimal numbers.\n" +
        //    "You can add comments after *s.\n" +
        //    "Example:\n\n" +
        //    "$Blue Box Fix\n043CD04C 00000000\n" +
        //    "*This is a comment\n\n" +
        //    "$Warp Anywhere\n040BC1C8 38000001\n040BC258 38000001\n040BC300 38000001\n" +
        //    "*another comment\n\n" +
        //    "Supported games: Scooby, BFBB, Movie, Incredibles, Underminer, RatProto");
    }

    private void richTextBoxDolPatches_TextChanged(object sender, EventArgs e)
    {
        richTextBoxDolPatches.BackColor = DolPatchesValid() ? defaultBackgroundColor : Color.Red;
        SetCreateModEnabled();
    }

    private void richTextBoxINIValues_TextChanged(object sender, EventArgs e)
    {
        richTextBoxINIValues.BackColor = IniPatchesValid() ? defaultBackgroundColor : Color.Red;
        SetCreateModEnabled();
    }

    private void richTextBoxArCodes_TextChanged(object sender, EventArgs e)
    {
        richTextBoxArCodes.BackColor = ArCodesValid() ? defaultBackgroundColor : Color.Red;
        SetCreateModEnabled();
    }

    private void richTextBoxGeckoCodes_TextChanged(object sender, EventArgs e)
    {
        richTextBoxGeckoCodes.BackColor = GeckoCodesValid() ? defaultBackgroundColor : Color.Red;
        SetCreateModEnabled();
    }

    private bool DolPatchesValid()
    {
        try
        {
            var patches = richTextBoxDolPatches.Text
                .Split('\n')
                .Select(l => l.Split('#')[0].Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => l.Split(' '))
                .Where(vals => vals.Length == 2 ? true : throw new Exception())
                .Select(vals => (Convert.ToUInt32(vals[0], 16), BitConverter.GetBytes(Convert.ToUInt32(vals[1], 16))))
                .ToArray();

            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool IniPatchesValid()
    {
        try
        {
            var tempIni = INIFile.FromContents(richTextBoxINIValues.Text);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool ArCodesValid()
    {
        try
        {
            var tempSettings = DolphinGameSettings.FromContents(richTextBoxArCodes.Text, DolphinSettingsReaderMode.ActionReplay);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool GeckoCodesValid()
    {
        try
        {
            var tempSettings = DolphinGameSettings.FromContents(richTextBoxGeckoCodes.Text, DolphinSettingsReaderMode.Gecko);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private void flowLayoutPanelPage1_Resize(object sender, EventArgs e)
    {
        groupBoxGame.Size = new Size(flowLayoutPanelPage1.Width - 23, groupBoxGame.Size.Height);
    }

    private void flowLayoutPanelPage2_Resize(object sender, EventArgs e)
    {
        groupBoxGameId.Size = new Size(flowLayoutPanelPage2.Width - 23, groupBoxGameId.Size.Height);
    }

    private void buttonIniImport_Click(object sender, EventArgs e)
    {
        if (!ModManager.GameBackupExists)
        {
            MessageBox.Show(GlobalResources.gameBackupNotFound,
                GlobalResources.gameBackupNotFoundTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var modIniPath = Path.Combine(ModManager.GetModFilesPath(textBoxModId.Text), ModManager.GameIniFileName(prevGame));

        if (!File.Exists(modIniPath))
        {
            MessageBox.Show(
                string.Format(GlobalResources.iniNotFound, modIniPath),
                GlobalResources.iniNotFoundTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var iniFile = INIFile.FromPath(modIniPath);
        var ogIniFile = INIFile.FromPath(Path.Combine(ModManager.GameBackupFilesPath, ModManager.GameIniFileName(prevGame)));
        var result = new List<string>();

        if (!string.IsNullOrWhiteSpace(richTextBoxINIValues.Text))
            result.Add(richTextBoxINIValues.Text);

        foreach ((string key, string value) in iniFile.Properties)
            if (!ogIniFile.Properties.ContainsKey(key) || ogIniFile.Properties[key] != value)
                result.Add($"{key}={value}");

        foreach ((string key, string value) in iniFile.ScenePlayerMapping)
            if (!ogIniFile.ScenePlayerMapping.ContainsKey(key) || ogIniFile.ScenePlayerMapping[key] != value)
                result.Add($"ScenePlayerMapping={key} {value}");

        foreach ((string key, string value) in iniFile.ThresholdPointsRange)
            if (!ogIniFile.ThresholdPointsRange.ContainsKey(key) || ogIniFile.ThresholdPointsRange[key] != value)
                result.Add($"ThresholdPointsRange={key} {value}");

        foreach ((string key, string value) in iniFile.AlternateCostumeMapping)
            if (!ogIniFile.AlternateCostumeMapping.ContainsKey(key) || ogIniFile.AlternateCostumeMapping[key] != value)
                result.Add($"AlternateCostumeMapping={key} {value}");

        bool shouldAddTaskStatus = false;
        if (iniFile.TaskStatus.Count != ogIniFile.TaskStatus.Count)
        {
            shouldAddTaskStatus = true;
        }
        else
        {
            for (int i = 0; i < iniFile.TaskStatus.Count; i++)
            {
                if (iniFile.TaskStatus[i] != ogIniFile.TaskStatus[i])
                {
                    shouldAddTaskStatus = true;
                    break;
                }
            }
        }
        if (shouldAddTaskStatus)
            foreach (string value in iniFile.TaskStatus)
                result.Add($"TaskStatus={value}");

        bool shouldAddExtra = false;
        if (iniFile.Extra.Count != ogIniFile.Extra.Count)
        {
            shouldAddExtra = true;
        }
        else
        {
            for (int i = 0; i < iniFile.Extra.Count; i++)
            {
                if (iniFile.Extra[i] != ogIniFile.Extra[i])
                {
                    shouldAddExtra = true;
                    break;
                }
            }
        }
        if (shouldAddExtra)
            foreach (string value in iniFile.Extra)
                result.Add($"Extra={value}");

        richTextBoxINIValues.Text = string.Join("\n", result);

        File.Delete(modIniPath);
    }

    private void buttonOpenIpsFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Filter = "IPS Patch File|*.ips|All Files (*.*)|*.*",
            ReadOnlyChecked = true,
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            textBoxIpsPatch.Text = openFileDialog.FileName;
        }
    }
}