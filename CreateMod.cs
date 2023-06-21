using NoCheese.Classes;
using NoCheese.Enum;

namespace NoCheese;

public partial class CreateMod : Form
{
    public CreateMod()
    {
        isEditing = false;

        InitializeComponent();

        foreach (Game game in ModManager.EvilEngineGames)
            comboBoxGame.Items.Add(new ComboBoxGameItem(game));

        dateTimePickerCreatedAt.Value = DateTime.Now;
        dateTimePickerUpdatedAt.Value = DateTime.Now;

        tabControl1.TabPages.RemoveAt(1);
        tabControl1.TabPages.RemoveAt(1);
        tabControl1.TabPages.RemoveAt(1);
    }

    private bool isEditing;
    private Game prevGame;

    public CreateMod(Mod mod)
    {
        isEditing = true;

        InitializeComponent();

        groupBoxGame.Enabled = false;
        comboBoxGame.Enabled = false;
        groupBoxModId.Enabled = false;

        prevGame = mod.Game;
        textBoxModName.Text = mod.ModName;
        textBoxAuthor.Text = mod.Author;
        textBoxDescription.Text = mod.Description;
        textBoxModId.Text = mod.ModId;
        richTextBoxArCodes.Text = mod.ArCodes;
        richTextBoxGeckoCodes.Text = mod.GeckoCodes;
        richTextBoxRemoveFiles.Text = mod.RemoveFiles;

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

        buttonCreateMod.Text = "Save";

        tabControl1.TabPages.RemoveAt(1);
        tabControl1.TabPages.RemoveAt(1);
        tabControl1.TabPages.RemoveAt(1);
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetCreateModEnabled();
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
            textBoxAuthor.Text.Length > 0 &&
            textBoxModName.Text.Length > 0 &&
            textBoxModId.Text.Length > 0;
    }

    private void ResetModId()
    {
        string modId = $"{ModManager.GameToString(((ComboBoxGameItem)comboBoxGame.SelectedItem).Game)}-{TreatString(textBoxAuthor.Text)}-{TreatString(textBoxModName.Text)}";
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

        var mod = new Mod(isEditing ? prevGame : ((ComboBoxGameItem)comboBoxGame.SelectedItem).Game,
            textBoxModName.Text,
            textBoxAuthor.Text,
            textBoxDescription.Text,
            textBoxModId.Text,
            richTextBoxArCodes.Text,
            richTextBoxGeckoCodes.Text,
            richTextBoxRemoveFiles.Text,
            dateTimePickerCreatedAt.Value,
            dateTimePickerUpdatedAt.Value);
        mod.SaveModJson(isEditing);
        Close();
    }

    private static readonly string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
    public static string TreatString(string text)
    {
        var result = "";
        foreach (var c in text)
            if (validChars.Contains(c))
                result += $"{c}".ToLower();
        return result;
    }

    //private void buttonSetCreatedNow_Click(object sender, EventArgs e)
    //{
    //    dateTimePickerCreatedAt.Value = DateTime.Now;
    //}

    //private void buttonSetUpdatedNow_Click(object sender, EventArgs e)
    //{
    //    dateTimePickerUpdatedAt.Value = DateTime.Now;
    //}
}