namespace HeavyModManager.Forms;

partial class CreateMod
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        groupBoxGame = new GroupBox();
        comboBoxGame = new ComboBox();
        groupBoxModName = new GroupBox();
        textBoxModName = new TextBox();
        groupBoxAuthor = new GroupBox();
        textBoxAuthor = new TextBox();
        groupBoxDescription = new GroupBox();
        textBoxDescription = new TextBox();
        buttonCreateMod = new Button();
        buttonCancel = new Button();
        groupBoxModId = new GroupBox();
        labelModIdInfo = new Label();
        textBoxModId = new TextBox();
        richTextBoxArCodes = new RichTextBox();
        richTextBoxGeckoCodes = new RichTextBox();
        tabControl1 = new TabControl();
        tabPageModData = new TabPage();
        groupBoxUpdatedAt = new GroupBox();
        dateTimePickerUpdatedAt = new DateTimePicker();
        groupBoxCreatedAt = new GroupBox();
        dateTimePickerCreatedAt = new DateTimePicker();
        tabPageRemoveFiles = new TabPage();
        label1 = new Label();
        richTextBoxRemoveFiles = new RichTextBox();
        tabPageArCodes = new TabPage();
        tabPageGeckoCodes = new TabPage();
        groupBoxGame.SuspendLayout();
        groupBoxModName.SuspendLayout();
        groupBoxAuthor.SuspendLayout();
        groupBoxDescription.SuspendLayout();
        groupBoxModId.SuspendLayout();
        tabControl1.SuspendLayout();
        tabPageModData.SuspendLayout();
        groupBoxUpdatedAt.SuspendLayout();
        groupBoxCreatedAt.SuspendLayout();
        tabPageRemoveFiles.SuspendLayout();
        tabPageArCodes.SuspendLayout();
        tabPageGeckoCodes.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxGame
        // 
        groupBoxGame.Controls.Add(comboBoxGame);
        groupBoxGame.Location = new Point(6, 6);
        groupBoxGame.Name = "groupBoxGame";
        groupBoxGame.Size = new Size(328, 51);
        groupBoxGame.TabIndex = 1;
        groupBoxGame.TabStop = false;
        groupBoxGame.Text = "Choose Game";
        // 
        // comboBoxGame
        // 
        comboBoxGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        comboBoxGame.FormattingEnabled = true;
        comboBoxGame.Location = new Point(6, 22);
        comboBoxGame.Name = "comboBoxGame";
        comboBoxGame.Size = new Size(316, 23);
        comboBoxGame.TabIndex = 1;
        comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
        // 
        // groupBoxModName
        // 
        groupBoxModName.Controls.Add(textBoxModName);
        groupBoxModName.Location = new Point(6, 63);
        groupBoxModName.Name = "groupBoxModName";
        groupBoxModName.Size = new Size(328, 51);
        groupBoxModName.TabIndex = 2;
        groupBoxModName.TabStop = false;
        groupBoxModName.Text = "Mod Name";
        // 
        // textBoxModName
        // 
        textBoxModName.Location = new Point(6, 22);
        textBoxModName.Name = "textBoxModName";
        textBoxModName.Size = new Size(316, 23);
        textBoxModName.TabIndex = 3;
        textBoxModName.TextChanged += textBoxModName_TextChanged;
        // 
        // groupBoxAuthor
        // 
        groupBoxAuthor.Controls.Add(textBoxAuthor);
        groupBoxAuthor.Location = new Point(6, 120);
        groupBoxAuthor.Name = "groupBoxAuthor";
        groupBoxAuthor.Size = new Size(328, 51);
        groupBoxAuthor.TabIndex = 4;
        groupBoxAuthor.TabStop = false;
        groupBoxAuthor.Text = "Mod Author";
        // 
        // textBoxAuthor
        // 
        textBoxAuthor.Location = new Point(6, 22);
        textBoxAuthor.Name = "textBoxAuthor";
        textBoxAuthor.Size = new Size(316, 23);
        textBoxAuthor.TabIndex = 3;
        textBoxAuthor.TextChanged += textBoxAuthor_TextChanged;
        // 
        // groupBoxDescription
        // 
        groupBoxDescription.Controls.Add(textBoxDescription);
        groupBoxDescription.Location = new Point(6, 177);
        groupBoxDescription.Name = "groupBoxDescription";
        groupBoxDescription.Size = new Size(328, 51);
        groupBoxDescription.TabIndex = 5;
        groupBoxDescription.TabStop = false;
        groupBoxDescription.Text = "Mod Description";
        // 
        // textBoxDescription
        // 
        textBoxDescription.Location = new Point(6, 22);
        textBoxDescription.Name = "textBoxDescription";
        textBoxDescription.Size = new Size(316, 23);
        textBoxDescription.TabIndex = 3;
        // 
        // buttonCreateMod
        // 
        buttonCreateMod.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCreateMod.Enabled = false;
        buttonCreateMod.Location = new Point(163, 495);
        buttonCreateMod.Name = "buttonCreateMod";
        buttonCreateMod.Size = new Size(102, 23);
        buttonCreateMod.TabIndex = 6;
        buttonCreateMod.Text = "Create Mod";
        buttonCreateMod.UseVisualStyleBackColor = true;
        buttonCreateMod.Click += buttonCreateMod_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Location = new Point(271, 495);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(84, 23);
        buttonCancel.TabIndex = 7;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // groupBoxModId
        // 
        groupBoxModId.Controls.Add(labelModIdInfo);
        groupBoxModId.Controls.Add(textBoxModId);
        groupBoxModId.Location = new Point(6, 348);
        groupBoxModId.Name = "groupBoxModId";
        groupBoxModId.Size = new Size(328, 102);
        groupBoxModId.TabIndex = 6;
        groupBoxModId.TabStop = false;
        groupBoxModId.Text = "Mod ID";
        // 
        // labelModIdInfo
        // 
        labelModIdInfo.AutoSize = true;
        labelModIdInfo.Location = new Point(6, 48);
        labelModIdInfo.Name = "labelModIdInfo";
        labelModIdInfo.Size = new Size(295, 45);
        labelModIdInfo.TabIndex = 4;
        labelModIdInfo.Text = "Feel free to enter your own custom ID for the mod, but\r\nmake sure that no other mod, by any other author or\r\nfor any other game, will have the same ID as yours!";
        // 
        // textBoxModId
        // 
        textBoxModId.Location = new Point(6, 22);
        textBoxModId.Name = "textBoxModId";
        textBoxModId.Size = new Size(316, 23);
        textBoxModId.TabIndex = 3;
        textBoxModId.TextChanged += textBoxModId_TextChanged;
        // 
        // richTextBoxArCodes
        // 
        richTextBoxArCodes.BorderStyle = BorderStyle.FixedSingle;
        richTextBoxArCodes.Dock = DockStyle.Fill;
        richTextBoxArCodes.Location = new Point(3, 3);
        richTextBoxArCodes.Name = "richTextBoxArCodes";
        richTextBoxArCodes.Size = new Size(336, 449);
        richTextBoxArCodes.TabIndex = 0;
        richTextBoxArCodes.Text = "";
        // 
        // richTextBoxGeckoCodes
        // 
        richTextBoxGeckoCodes.BorderStyle = BorderStyle.FixedSingle;
        richTextBoxGeckoCodes.Dock = DockStyle.Fill;
        richTextBoxGeckoCodes.Location = new Point(0, 0);
        richTextBoxGeckoCodes.Name = "richTextBoxGeckoCodes";
        richTextBoxGeckoCodes.Size = new Size(342, 455);
        richTextBoxGeckoCodes.TabIndex = 1;
        richTextBoxGeckoCodes.Text = "";
        // 
        // tabControl1
        // 
        tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tabControl1.Controls.Add(tabPageModData);
        tabControl1.Controls.Add(tabPageRemoveFiles);
        tabControl1.Controls.Add(tabPageArCodes);
        tabControl1.Controls.Add(tabPageGeckoCodes);
        tabControl1.Location = new Point(9, 9);
        tabControl1.Margin = new Padding(0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(350, 483);
        tabControl1.TabIndex = 8;
        // 
        // tabPageModData
        // 
        tabPageModData.Controls.Add(groupBoxUpdatedAt);
        tabPageModData.Controls.Add(groupBoxCreatedAt);
        tabPageModData.Controls.Add(groupBoxGame);
        tabPageModData.Controls.Add(groupBoxModName);
        tabPageModData.Controls.Add(groupBoxAuthor);
        tabPageModData.Controls.Add(groupBoxModId);
        tabPageModData.Controls.Add(groupBoxDescription);
        tabPageModData.Location = new Point(4, 24);
        tabPageModData.Name = "tabPageModData";
        tabPageModData.Padding = new Padding(3);
        tabPageModData.Size = new Size(342, 455);
        tabPageModData.TabIndex = 0;
        tabPageModData.Text = "Mod Data";
        tabPageModData.UseVisualStyleBackColor = true;
        // 
        // groupBoxUpdatedAt
        // 
        groupBoxUpdatedAt.Controls.Add(dateTimePickerUpdatedAt);
        groupBoxUpdatedAt.Location = new Point(6, 291);
        groupBoxUpdatedAt.Name = "groupBoxUpdatedAt";
        groupBoxUpdatedAt.Size = new Size(328, 51);
        groupBoxUpdatedAt.TabIndex = 7;
        groupBoxUpdatedAt.TabStop = false;
        groupBoxUpdatedAt.Text = "Updated At";
        // 
        // dateTimePickerUpdatedAt
        // 
        dateTimePickerUpdatedAt.Location = new Point(6, 22);
        dateTimePickerUpdatedAt.Name = "dateTimePickerUpdatedAt";
        dateTimePickerUpdatedAt.Size = new Size(316, 23);
        dateTimePickerUpdatedAt.TabIndex = 7;
        // 
        // groupBoxCreatedAt
        // 
        groupBoxCreatedAt.Controls.Add(dateTimePickerCreatedAt);
        groupBoxCreatedAt.Location = new Point(6, 234);
        groupBoxCreatedAt.Name = "groupBoxCreatedAt";
        groupBoxCreatedAt.Size = new Size(328, 51);
        groupBoxCreatedAt.TabIndex = 6;
        groupBoxCreatedAt.TabStop = false;
        groupBoxCreatedAt.Text = "Created At";
        // 
        // dateTimePickerCreatedAt
        // 
        dateTimePickerCreatedAt.Location = new Point(6, 22);
        dateTimePickerCreatedAt.Name = "dateTimePickerCreatedAt";
        dateTimePickerCreatedAt.Size = new Size(316, 23);
        dateTimePickerCreatedAt.TabIndex = 7;
        // 
        // tabPageRemoveFiles
        // 
        tabPageRemoveFiles.Controls.Add(label1);
        tabPageRemoveFiles.Controls.Add(richTextBoxRemoveFiles);
        tabPageRemoveFiles.Location = new Point(4, 24);
        tabPageRemoveFiles.Name = "tabPageRemoveFiles";
        tabPageRemoveFiles.Size = new Size(342, 455);
        tabPageRemoveFiles.TabIndex = 3;
        tabPageRemoveFiles.Text = "Remove Files";
        tabPageRemoveFiles.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(3, 0);
        label1.Name = "label1";
        label1.Size = new Size(317, 30);
        label1.TabIndex = 5;
        label1.Text = "Enter the folders or files present in the original game which\r\nshould be deleted from the mod, one per line.";
        // 
        // richTextBoxRemoveFiles
        // 
        richTextBoxRemoveFiles.Location = new Point(0, 33);
        richTextBoxRemoveFiles.Name = "richTextBoxRemoveFiles";
        richTextBoxRemoveFiles.Size = new Size(340, 419);
        richTextBoxRemoveFiles.TabIndex = 0;
        richTextBoxRemoveFiles.Text = "";
        // 
        // tabPageArCodes
        // 
        tabPageArCodes.Controls.Add(richTextBoxArCodes);
        tabPageArCodes.Location = new Point(4, 24);
        tabPageArCodes.Name = "tabPageArCodes";
        tabPageArCodes.Padding = new Padding(3);
        tabPageArCodes.Size = new Size(342, 455);
        tabPageArCodes.TabIndex = 1;
        tabPageArCodes.Text = "AR Codes";
        tabPageArCodes.UseVisualStyleBackColor = true;
        // 
        // tabPageGeckoCodes
        // 
        tabPageGeckoCodes.Controls.Add(richTextBoxGeckoCodes);
        tabPageGeckoCodes.Location = new Point(4, 24);
        tabPageGeckoCodes.Name = "tabPageGeckoCodes";
        tabPageGeckoCodes.Size = new Size(342, 455);
        tabPageGeckoCodes.TabIndex = 2;
        tabPageGeckoCodes.Text = "Gecko Codes";
        tabPageGeckoCodes.UseVisualStyleBackColor = true;
        // 
        // CreateMod
        // 
        AcceptButton = buttonCreateMod;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        ClientSize = new Size(368, 527);
        Controls.Add(tabControl1);
        Controls.Add(buttonCancel);
        Controls.Add(buttonCreateMod);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "CreateMod";
        ShowIcon = false;
        Text = "Create New Mod";
        groupBoxGame.ResumeLayout(false);
        groupBoxModName.ResumeLayout(false);
        groupBoxModName.PerformLayout();
        groupBoxAuthor.ResumeLayout(false);
        groupBoxAuthor.PerformLayout();
        groupBoxDescription.ResumeLayout(false);
        groupBoxDescription.PerformLayout();
        groupBoxModId.ResumeLayout(false);
        groupBoxModId.PerformLayout();
        tabControl1.ResumeLayout(false);
        tabPageModData.ResumeLayout(false);
        groupBoxUpdatedAt.ResumeLayout(false);
        groupBoxCreatedAt.ResumeLayout(false);
        tabPageRemoveFiles.ResumeLayout(false);
        tabPageRemoveFiles.PerformLayout();
        tabPageArCodes.ResumeLayout(false);
        tabPageGeckoCodes.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBoxGame;
    private ComboBox comboBoxGame;
    private GroupBox groupBoxModName;
    private TextBox textBoxModName;
    private GroupBox groupBoxAuthor;
    private TextBox textBoxAuthor;
    private GroupBox groupBoxDescription;
    private TextBox textBoxDescription;
    private Button buttonCreateMod;
    private Button buttonCancel;
    private GroupBox groupBoxModId;
    private TextBox textBoxModId;
    private Label labelModIdInfo;
    private RichTextBox richTextBoxArCodes;
    private RichTextBox richTextBoxGeckoCodes;
    private TabControl tabControl1;
    private TabPage tabPageModData;
    private TabPage tabPageRemoveFiles;
    private TabPage tabPageArCodes;
    private TabPage tabPageGeckoCodes;
    private Label label1;
    private RichTextBox richTextBoxRemoveFiles;
    private DateTimePicker dateTimePickerCreatedAt;
    private GroupBox groupBoxCreatedAt;
    private GroupBox groupBoxUpdatedAt;
    private DateTimePicker dateTimePickerUpdatedAt;
}