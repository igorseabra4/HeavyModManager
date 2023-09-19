using HeavyModManager.Classes;
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

        foreach (Game game in ModManager.Games)
            comboBoxGame.Items.Add(new ComboBoxGameItem(game));

        dateTimePickerCreatedAt.Value = DateTime.Now;
        dateTimePickerUpdatedAt.Value = DateTime.Now;
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
        textBoxDescription.Text = mod.Description;
        textBoxModId.Text = mod.ModId;
        // richTextBoxArCodes.Text = mod.ArCodes;
        // richTextBoxGeckoCodes.Text = mod.GeckoCodes;
        textBoxGameId.Text = mod.GameId;
        richTextBoxINIValues.Text = mod.INIReplacements;
        richTextBoxMergeHips.Text = mod.MergeFiles;
        richTextBoxRemoveFiles.Text = mod.RemoveFiles;
        richTextBoxDolPatches.Text = mod.DOLPatches;

        labelModIdInfo.Visible = false;
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

        Text = "Edit Mod";
        buttonCreateMod.Text = "Save";
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
            DolPatchesValid();
    }

    private void ResetModId()
    {
        var selectedGameItem = (ComboBoxGameItem)comboBoxGame.SelectedItem;
        var gameName = selectedGameItem == null ? "gamename" : ModManager.GameToString(selectedGameItem.Game);
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
                MessageBox.Show("Unable to create mod: a mod with the same ID already exists.");
                return;
            }
        }

        var mod = new Mod()
        {
            Game = isEditing ? prevGame : ((ComboBoxGameItem)comboBoxGame.SelectedItem).Game,
            ModName = textBoxModName.Text,
            Author = textBoxAuthor.Text,
            Description = textBoxDescription.Text,
            ModId = textBoxModId.Text,
            GameId = textBoxGameId.Text,
            INIReplacements = richTextBoxINIValues.Text,
            MergeFiles = richTextBoxMergeHips.Text,
            RemoveFiles = richTextBoxRemoveFiles.Text,
            DOLPatches = richTextBoxDolPatches.Text,
            ArCodes = "", // richTextBoxArCodes.Text,
            GeckoCodes = "", //richTextBoxGeckoCodes.Text,
            CreatedAt = dateTimePickerCreatedAt.Value,
            UpdatedAt = dateTimePickerUpdatedAt.Value,
        };

        mod.SaveModJson(isEditing);
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
        labelDefaultGameId.Text = $"Default game ID: {ModManager.GameToGameID(game)}";
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

    private void buttonGameIdInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip("Enter a custom game ID for the mod.\n" +
            "Save files are created using this game ID, enabling your mod to have a unique save file.\n" +
            "Make sure no other GameCube or Wii game has the same ID.\n" +
            "I recommend keeping the first four characters the same and changing only the last two.\n" +
            "Must be 6 characters long. Leave blank for default.");
    }

    private void buttonIniValuesInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip("Enter your mod's HIP and HOP files which should be\n" +
            "merged into the running copy of the game instead of\n" +
            "replacing the original ones, one per line.\n\n" +
            "Example:\n\n" +
            "boot.HIP\n" +
            "hb\\hb01.HIP\n" +
            "hb\\hb01.HOP");
    }

    private void buttonMergeHipsInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip("Enter your mod's HIP and HOP files which should be merged into the\n" +
            "running copy of the game instead of replacing the original ones, one per line.\n" +
            "Note that assets are simply copied into the destination archive, replacing any\n" +
            "existing assets, and more complex operations performed by Industrial Park's HIP\n" +
            "importer (such as merging Sound Info assets) is not done here.\n\n" +
            "Example:\n\n" +
            "boot.HIP\n" +
            "hb\\hb01.HIP\n" +
            "hb\\hb01.HOP");
    }

    private void buttonRemoveFilesInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip("Enter the folders or files present in the original game\n" +
            "which should be deleted from the mod, one per line.\n\n" +
            "Example:\n\n" +
            "boot.HIP\n" +
            "hb\\hb01.HIP\n" +
            "hb\\hb01.HOP");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        ShowToolTip(
            "Enter the game's configuration INI key-value pairs for this mod,\n" +
            "in the form of <key>=<value>, one per line.\n" +
            "You can add comments after #s.\n" +
            "You only need to enter the lines needed by your mod.\n\n" +
            "Example:\n\n" +
            "BOOT=HB00\n" +
            "ShowMenuOnBoot=0 # This is a comment\n" +
            "G.BubbleBowl=1\n" +
            "#another comment");
    }

    private void buttonDolPatchesInfo_Click(object sender, EventArgs e)
    {
        ShowToolTip(
            "Enter patches to be applied to the game's DOL file, in the form of\n" +
            "<offset> <value>, both 4-byte hexadecimal numbers, one per line.\n" +
            "You can add comments after #s.\n" +
            "AR codes do not work as DOL patches.\n\n" +
            "Example:\n\n" +
            "00287D10 53494D50\n" +
            "00287DB0 54455854 # This is a comment\n" +
            "#another comment");
    }

    private void richTextBoxDolPatches_TextChanged(object sender, EventArgs e)
    {
        richTextBoxDolPatches.BackColor = DolPatchesValid() ? defaultBackgroundColor : Color.Red;
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
}