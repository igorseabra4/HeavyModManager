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
        tabControl1 = new TabControl();
        tabPageModData = new TabPage();
        groupBoxUpdatedAt = new GroupBox();
        dateTimePickerUpdatedAt = new DateTimePicker();
        groupBoxCreatedAt = new GroupBox();
        dateTimePickerCreatedAt = new DateTimePicker();
        tabPageSettings = new TabPage();
        flowLayoutPanel1 = new FlowLayoutPanel();
        groupBoxGameId = new GroupBox();
        buttonGameIdInfo = new Button();
        labelDefaultGameId = new Label();
        textBoxGameId = new TextBox();
        groupBoxIniValues = new GroupBox();
        buttonIniValuesInfo = new Button();
        richTextBoxINIValues = new RichTextBox();
        groupBoxMergeHips = new GroupBox();
        buttonMergeHipsInfo = new Button();
        richTextBoxMergeHips = new RichTextBox();
        groupBoxRemoveFiles = new GroupBox();
        buttonRemoveFilesInfo = new Button();
        richTextBoxRemoveFiles = new RichTextBox();
        groupBoxDolPatches = new GroupBox();
        buttonDolPatchesInfo = new Button();
        richTextBoxDolPatches = new RichTextBox();
        groupBoxGame.SuspendLayout();
        groupBoxModName.SuspendLayout();
        groupBoxAuthor.SuspendLayout();
        groupBoxDescription.SuspendLayout();
        groupBoxModId.SuspendLayout();
        tabControl1.SuspendLayout();
        tabPageModData.SuspendLayout();
        groupBoxUpdatedAt.SuspendLayout();
        groupBoxCreatedAt.SuspendLayout();
        tabPageSettings.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        groupBoxGameId.SuspendLayout();
        groupBoxIniValues.SuspendLayout();
        groupBoxMergeHips.SuspendLayout();
        groupBoxRemoveFiles.SuspendLayout();
        groupBoxDolPatches.SuspendLayout();
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
        comboBoxGame.TabIndex = 2;
        comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
        // 
        // groupBoxModName
        // 
        groupBoxModName.Controls.Add(textBoxModName);
        groupBoxModName.Location = new Point(6, 63);
        groupBoxModName.Name = "groupBoxModName";
        groupBoxModName.Size = new Size(328, 51);
        groupBoxModName.TabIndex = 3;
        groupBoxModName.TabStop = false;
        groupBoxModName.Text = "Mod Name";
        // 
        // textBoxModName
        // 
        textBoxModName.Location = new Point(6, 22);
        textBoxModName.Name = "textBoxModName";
        textBoxModName.Size = new Size(316, 23);
        textBoxModName.TabIndex = 4;
        textBoxModName.TextChanged += textBoxModName_TextChanged;
        // 
        // groupBoxAuthor
        // 
        groupBoxAuthor.Controls.Add(textBoxAuthor);
        groupBoxAuthor.Location = new Point(6, 120);
        groupBoxAuthor.Name = "groupBoxAuthor";
        groupBoxAuthor.Size = new Size(328, 51);
        groupBoxAuthor.TabIndex = 5;
        groupBoxAuthor.TabStop = false;
        groupBoxAuthor.Text = "Mod Author";
        // 
        // textBoxAuthor
        // 
        textBoxAuthor.Location = new Point(6, 22);
        textBoxAuthor.Name = "textBoxAuthor";
        textBoxAuthor.Size = new Size(316, 23);
        textBoxAuthor.TabIndex = 6;
        textBoxAuthor.TextChanged += textBoxAuthor_TextChanged;
        // 
        // groupBoxDescription
        // 
        groupBoxDescription.Controls.Add(textBoxDescription);
        groupBoxDescription.Location = new Point(6, 177);
        groupBoxDescription.Name = "groupBoxDescription";
        groupBoxDescription.Size = new Size(328, 51);
        groupBoxDescription.TabIndex = 7;
        groupBoxDescription.TabStop = false;
        groupBoxDescription.Text = "Mod Description";
        // 
        // textBoxDescription
        // 
        textBoxDescription.Location = new Point(6, 22);
        textBoxDescription.Name = "textBoxDescription";
        textBoxDescription.Size = new Size(316, 23);
        textBoxDescription.TabIndex = 8;
        // 
        // buttonCreateMod
        // 
        buttonCreateMod.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCreateMod.Enabled = false;
        buttonCreateMod.Location = new Point(186, 495);
        buttonCreateMod.Name = "buttonCreateMod";
        buttonCreateMod.Size = new Size(161, 23);
        buttonCreateMod.TabIndex = 72;
        buttonCreateMod.Text = "Create Mod";
        buttonCreateMod.UseVisualStyleBackColor = true;
        buttonCreateMod.Click += buttonCreateMod_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Location = new Point(19, 495);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(161, 23);
        buttonCancel.TabIndex = 71;
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
        groupBoxModId.TabIndex = 13;
        groupBoxModId.TabStop = false;
        groupBoxModId.Text = "Mod ID";
        // 
        // labelModIdInfo
        // 
        labelModIdInfo.AutoSize = true;
        labelModIdInfo.Location = new Point(6, 48);
        labelModIdInfo.Name = "labelModIdInfo";
        labelModIdInfo.Size = new Size(295, 45);
        labelModIdInfo.TabIndex = 15;
        labelModIdInfo.Text = "Feel free to enter your own custom ID for the mod, but\r\nmake sure that no other mod, by any other author or\r\nfor any other game, will have the same ID as yours!";
        // 
        // textBoxModId
        // 
        textBoxModId.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
        textBoxModId.Location = new Point(6, 22);
        textBoxModId.Name = "textBoxModId";
        textBoxModId.Size = new Size(316, 22);
        textBoxModId.TabIndex = 14;
        textBoxModId.TextChanged += textBoxModId_TextChanged;
        // 
        // tabControl1
        // 
        tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tabControl1.Controls.Add(tabPageModData);
        tabControl1.Controls.Add(tabPageSettings);
        tabControl1.Location = new Point(9, 9);
        tabControl1.Margin = new Padding(0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(350, 483);
        tabControl1.TabIndex = 0;
        tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
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
        groupBoxUpdatedAt.TabIndex = 11;
        groupBoxUpdatedAt.TabStop = false;
        groupBoxUpdatedAt.Text = "Updated At";
        // 
        // dateTimePickerUpdatedAt
        // 
        dateTimePickerUpdatedAt.Location = new Point(6, 22);
        dateTimePickerUpdatedAt.Name = "dateTimePickerUpdatedAt";
        dateTimePickerUpdatedAt.Size = new Size(316, 23);
        dateTimePickerUpdatedAt.TabIndex = 12;
        // 
        // groupBoxCreatedAt
        // 
        groupBoxCreatedAt.Controls.Add(dateTimePickerCreatedAt);
        groupBoxCreatedAt.Location = new Point(6, 234);
        groupBoxCreatedAt.Name = "groupBoxCreatedAt";
        groupBoxCreatedAt.Size = new Size(328, 51);
        groupBoxCreatedAt.TabIndex = 9;
        groupBoxCreatedAt.TabStop = false;
        groupBoxCreatedAt.Text = "Created At";
        // 
        // dateTimePickerCreatedAt
        // 
        dateTimePickerCreatedAt.Location = new Point(6, 22);
        dateTimePickerCreatedAt.Name = "dateTimePickerCreatedAt";
        dateTimePickerCreatedAt.Size = new Size(316, 23);
        dateTimePickerCreatedAt.TabIndex = 10;
        // 
        // tabPageSettings
        // 
        tabPageSettings.Controls.Add(flowLayoutPanel1);
        tabPageSettings.Location = new Point(4, 24);
        tabPageSettings.Name = "tabPageSettings";
        tabPageSettings.Size = new Size(342, 455);
        tabPageSettings.TabIndex = 3;
        tabPageSettings.Text = "Settings";
        tabPageSettings.UseVisualStyleBackColor = true;
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.AutoScroll = true;
        flowLayoutPanel1.Controls.Add(groupBoxGameId);
        flowLayoutPanel1.Controls.Add(groupBoxIniValues);
        flowLayoutPanel1.Controls.Add(groupBoxMergeHips);
        flowLayoutPanel1.Controls.Add(groupBoxRemoveFiles);
        flowLayoutPanel1.Controls.Add(groupBoxDolPatches);
        flowLayoutPanel1.Dock = DockStyle.Fill;
        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel1.Location = new Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(342, 455);
        flowLayoutPanel1.TabIndex = 16;
        flowLayoutPanel1.WrapContents = false;
        // 
        // groupBoxGameId
        // 
        groupBoxGameId.Controls.Add(buttonGameIdInfo);
        groupBoxGameId.Controls.Add(labelDefaultGameId);
        groupBoxGameId.Controls.Add(textBoxGameId);
        groupBoxGameId.Location = new Point(3, 3);
        groupBoxGameId.Name = "groupBoxGameId";
        groupBoxGameId.Size = new Size(319, 69);
        groupBoxGameId.TabIndex = 17;
        groupBoxGameId.TabStop = false;
        groupBoxGameId.Text = "Save File Game ID";
        // 
        // buttonGameIdInfo
        // 
        buttonGameIdInfo.Location = new Point(268, 22);
        buttonGameIdInfo.Name = "buttonGameIdInfo";
        buttonGameIdInfo.Size = new Size(45, 23);
        buttonGameIdInfo.TabIndex = 19;
        buttonGameIdInfo.Text = "Info";
        buttonGameIdInfo.UseVisualStyleBackColor = true;
        buttonGameIdInfo.Click += buttonGameIdInfo_Click;
        // 
        // labelDefaultGameId
        // 
        labelDefaultGameId.AutoSize = true;
        labelDefaultGameId.Location = new Point(6, 48);
        labelDefaultGameId.Name = "labelDefaultGameId";
        labelDefaultGameId.Size = new Size(95, 15);
        labelDefaultGameId.TabIndex = 20;
        labelDefaultGameId.Text = "Default game ID:";
        // 
        // textBoxGameId
        // 
        textBoxGameId.Location = new Point(6, 22);
        textBoxGameId.Name = "textBoxGameId";
        textBoxGameId.Size = new Size(256, 23);
        textBoxGameId.TabIndex = 18;
        // 
        // groupBoxIniValues
        // 
        groupBoxIniValues.Controls.Add(buttonIniValuesInfo);
        groupBoxIniValues.Controls.Add(richTextBoxINIValues);
        groupBoxIniValues.Location = new Point(3, 78);
        groupBoxIniValues.Name = "groupBoxIniValues";
        groupBoxIniValues.Size = new Size(319, 172);
        groupBoxIniValues.TabIndex = 21;
        groupBoxIniValues.TabStop = false;
        groupBoxIniValues.Text = "INI Values";
        // 
        // buttonIniValuesInfo
        // 
        buttonIniValuesInfo.Location = new Point(268, -1);
        buttonIniValuesInfo.Name = "buttonIniValuesInfo";
        buttonIniValuesInfo.Size = new Size(45, 23);
        buttonIniValuesInfo.TabIndex = 22;
        buttonIniValuesInfo.Text = "Info";
        buttonIniValuesInfo.UseVisualStyleBackColor = true;
        buttonIniValuesInfo.Click += button1_Click;
        // 
        // richTextBoxINIValues
        // 
        richTextBoxINIValues.Location = new Point(6, 22);
        richTextBoxINIValues.Name = "richTextBoxINIValues";
        richTextBoxINIValues.Size = new Size(307, 144);
        richTextBoxINIValues.TabIndex = 23;
        richTextBoxINIValues.Text = "";
        // 
        // groupBoxMergeHips
        // 
        groupBoxMergeHips.Controls.Add(buttonMergeHipsInfo);
        groupBoxMergeHips.Controls.Add(richTextBoxMergeHips);
        groupBoxMergeHips.Location = new Point(3, 256);
        groupBoxMergeHips.Name = "groupBoxMergeHips";
        groupBoxMergeHips.Size = new Size(319, 172);
        groupBoxMergeHips.TabIndex = 24;
        groupBoxMergeHips.TabStop = false;
        groupBoxMergeHips.Text = "Merge HIP Files";
        // 
        // buttonMergeHipsInfo
        // 
        buttonMergeHipsInfo.Location = new Point(268, -1);
        buttonMergeHipsInfo.Name = "buttonMergeHipsInfo";
        buttonMergeHipsInfo.Size = new Size(45, 23);
        buttonMergeHipsInfo.TabIndex = 25;
        buttonMergeHipsInfo.Text = "Info";
        buttonMergeHipsInfo.UseVisualStyleBackColor = true;
        buttonMergeHipsInfo.Click += buttonMergeHipsInfo_Click;
        // 
        // richTextBoxMergeHips
        // 
        richTextBoxMergeHips.Location = new Point(6, 22);
        richTextBoxMergeHips.Name = "richTextBoxMergeHips";
        richTextBoxMergeHips.Size = new Size(307, 144);
        richTextBoxMergeHips.TabIndex = 26;
        richTextBoxMergeHips.Text = "";
        // 
        // groupBoxRemoveFiles
        // 
        groupBoxRemoveFiles.Controls.Add(buttonRemoveFilesInfo);
        groupBoxRemoveFiles.Controls.Add(richTextBoxRemoveFiles);
        groupBoxRemoveFiles.Location = new Point(3, 434);
        groupBoxRemoveFiles.Name = "groupBoxRemoveFiles";
        groupBoxRemoveFiles.Size = new Size(319, 172);
        groupBoxRemoveFiles.TabIndex = 27;
        groupBoxRemoveFiles.TabStop = false;
        groupBoxRemoveFiles.Text = "Remove Files";
        // 
        // buttonRemoveFilesInfo
        // 
        buttonRemoveFilesInfo.Location = new Point(268, -1);
        buttonRemoveFilesInfo.Name = "buttonRemoveFilesInfo";
        buttonRemoveFilesInfo.Size = new Size(45, 23);
        buttonRemoveFilesInfo.TabIndex = 28;
        buttonRemoveFilesInfo.Text = "Info";
        buttonRemoveFilesInfo.UseVisualStyleBackColor = true;
        buttonRemoveFilesInfo.Click += buttonRemoveFilesInfo_Click;
        // 
        // richTextBoxRemoveFiles
        // 
        richTextBoxRemoveFiles.Location = new Point(6, 22);
        richTextBoxRemoveFiles.Name = "richTextBoxRemoveFiles";
        richTextBoxRemoveFiles.Size = new Size(307, 144);
        richTextBoxRemoveFiles.TabIndex = 29;
        richTextBoxRemoveFiles.Text = "";
        // 
        // groupBoxDolPatches
        // 
        groupBoxDolPatches.Controls.Add(buttonDolPatchesInfo);
        groupBoxDolPatches.Controls.Add(richTextBoxDolPatches);
        groupBoxDolPatches.Location = new Point(3, 612);
        groupBoxDolPatches.Name = "groupBoxDolPatches";
        groupBoxDolPatches.Size = new Size(319, 172);
        groupBoxDolPatches.TabIndex = 30;
        groupBoxDolPatches.TabStop = false;
        groupBoxDolPatches.Text = "DOL Patches";
        // 
        // buttonDolPatchesInfo
        // 
        buttonDolPatchesInfo.Location = new Point(268, -1);
        buttonDolPatchesInfo.Name = "buttonDolPatchesInfo";
        buttonDolPatchesInfo.Size = new Size(45, 23);
        buttonDolPatchesInfo.TabIndex = 31;
        buttonDolPatchesInfo.Text = "Info";
        buttonDolPatchesInfo.UseVisualStyleBackColor = true;
        buttonDolPatchesInfo.Click += buttonDolPatchesInfo_Click;
        // 
        // richTextBoxDolPatches
        // 
        richTextBoxDolPatches.Location = new Point(6, 22);
        richTextBoxDolPatches.Name = "richTextBoxDolPatches";
        richTextBoxDolPatches.Size = new Size(307, 144);
        richTextBoxDolPatches.TabIndex = 32;
        richTextBoxDolPatches.Text = "";
        richTextBoxDolPatches.TextChanged += richTextBoxDolPatches_TextChanged;
        // 
        // CreateMod
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(368, 527);
        Controls.Add(tabControl1);
        Controls.Add(buttonCancel);
        Controls.Add(buttonCreateMod);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "CreateMod";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
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
        tabPageSettings.ResumeLayout(false);
        flowLayoutPanel1.ResumeLayout(false);
        groupBoxGameId.ResumeLayout(false);
        groupBoxGameId.PerformLayout();
        groupBoxIniValues.ResumeLayout(false);
        groupBoxMergeHips.ResumeLayout(false);
        groupBoxRemoveFiles.ResumeLayout(false);
        groupBoxDolPatches.ResumeLayout(false);
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
    private TabControl tabControl1;
    private TabPage tabPageModData;
    private DateTimePicker dateTimePickerCreatedAt;
    private GroupBox groupBoxCreatedAt;
    private GroupBox groupBoxUpdatedAt;
    private DateTimePicker dateTimePickerUpdatedAt;
    private TabPage tabPageSettings;
    private FlowLayoutPanel flowLayoutPanel1;
    private GroupBox groupBoxGameId;
    private Button buttonGameIdInfo;
    private Label labelDefaultGameId;
    private TextBox textBoxGameId;
    private GroupBox groupBoxIniValues;
    private GroupBox groupBoxMergeHips;
    private Button buttonMergeHipsInfo;
    private RichTextBox richTextBoxMergeHips;
    private GroupBox groupBoxRemoveFiles;
    private Button buttonRemoveFilesInfo;
    private RichTextBox richTextBoxRemoveFiles;
    private RichTextBox richTextBoxINIValues;
    private Button buttonIniValuesInfo;
    private GroupBox groupBoxDolPatches;
    private Button buttonDolPatchesInfo;
    private RichTextBox richTextBoxDolPatches;
}