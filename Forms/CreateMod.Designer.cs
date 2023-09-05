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
            this.groupBoxGame = new System.Windows.Forms.GroupBox();
            this.comboBoxGame = new System.Windows.Forms.ComboBox();
            this.groupBoxModName = new System.Windows.Forms.GroupBox();
            this.textBoxModName = new System.Windows.Forms.TextBox();
            this.groupBoxAuthor = new System.Windows.Forms.GroupBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonCreateMod = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxModId = new System.Windows.Forms.GroupBox();
            this.labelModIdInfo = new System.Windows.Forms.Label();
            this.textBoxModId = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageModData = new System.Windows.Forms.TabPage();
            this.groupBoxUpdatedAt = new System.Windows.Forms.GroupBox();
            this.dateTimePickerUpdatedAt = new System.Windows.Forms.DateTimePicker();
            this.groupBoxCreatedAt = new System.Windows.Forms.GroupBox();
            this.dateTimePickerCreatedAt = new System.Windows.Forms.DateTimePicker();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxGameId = new System.Windows.Forms.GroupBox();
            this.buttonGameIdInfo = new System.Windows.Forms.Button();
            this.labelDefaultGameId = new System.Windows.Forms.Label();
            this.textBoxGameId = new System.Windows.Forms.TextBox();
            this.groupBoxIniValues = new System.Windows.Forms.GroupBox();
            this.buttonIniValuesInfo = new System.Windows.Forms.Button();
            this.richTextBoxINIValues = new System.Windows.Forms.RichTextBox();
            this.groupBoxMergeHips = new System.Windows.Forms.GroupBox();
            this.buttonMergeHipsInfo = new System.Windows.Forms.Button();
            this.richTextBoxMergeHips = new System.Windows.Forms.RichTextBox();
            this.groupBoxRemoveFiles = new System.Windows.Forms.GroupBox();
            this.buttonRemoveFilesInfo = new System.Windows.Forms.Button();
            this.richTextBoxRemoveFiles = new System.Windows.Forms.RichTextBox();
            this.groupBoxDolPatches = new System.Windows.Forms.GroupBox();
            this.buttonDolPatchesInfo = new System.Windows.Forms.Button();
            this.richTextBoxDolPatches = new System.Windows.Forms.RichTextBox();
            this.groupBoxGame.SuspendLayout();
            this.groupBoxModName.SuspendLayout();
            this.groupBoxAuthor.SuspendLayout();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxModId.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageModData.SuspendLayout();
            this.groupBoxUpdatedAt.SuspendLayout();
            this.groupBoxCreatedAt.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxGameId.SuspendLayout();
            this.groupBoxIniValues.SuspendLayout();
            this.groupBoxMergeHips.SuspendLayout();
            this.groupBoxRemoveFiles.SuspendLayout();
            this.groupBoxDolPatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGame
            // 
            this.groupBoxGame.Controls.Add(this.comboBoxGame);
            this.groupBoxGame.Location = new System.Drawing.Point(6, 6);
            this.groupBoxGame.Name = "groupBoxGame";
            this.groupBoxGame.Size = new System.Drawing.Size(328, 51);
            this.groupBoxGame.TabIndex = 1;
            this.groupBoxGame.TabStop = false;
            this.groupBoxGame.Text = "Choose Game";
            // 
            // comboBoxGame
            // 
            this.comboBoxGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGame.FormattingEnabled = true;
            this.comboBoxGame.Location = new System.Drawing.Point(6, 22);
            this.comboBoxGame.Name = "comboBoxGame";
            this.comboBoxGame.Size = new System.Drawing.Size(316, 23);
            this.comboBoxGame.TabIndex = 1;
            this.comboBoxGame.SelectedIndexChanged += new System.EventHandler(this.comboBoxGame_SelectedIndexChanged);
            // 
            // groupBoxModName
            // 
            this.groupBoxModName.Controls.Add(this.textBoxModName);
            this.groupBoxModName.Location = new System.Drawing.Point(6, 63);
            this.groupBoxModName.Name = "groupBoxModName";
            this.groupBoxModName.Size = new System.Drawing.Size(328, 51);
            this.groupBoxModName.TabIndex = 2;
            this.groupBoxModName.TabStop = false;
            this.groupBoxModName.Text = "Mod Name";
            // 
            // textBoxModName
            // 
            this.textBoxModName.Location = new System.Drawing.Point(6, 22);
            this.textBoxModName.Name = "textBoxModName";
            this.textBoxModName.Size = new System.Drawing.Size(316, 23);
            this.textBoxModName.TabIndex = 3;
            this.textBoxModName.TextChanged += new System.EventHandler(this.textBoxModName_TextChanged);
            // 
            // groupBoxAuthor
            // 
            this.groupBoxAuthor.Controls.Add(this.textBoxAuthor);
            this.groupBoxAuthor.Location = new System.Drawing.Point(6, 120);
            this.groupBoxAuthor.Name = "groupBoxAuthor";
            this.groupBoxAuthor.Size = new System.Drawing.Size(328, 51);
            this.groupBoxAuthor.TabIndex = 4;
            this.groupBoxAuthor.TabStop = false;
            this.groupBoxAuthor.Text = "Mod Author";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(6, 22);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(316, 23);
            this.textBoxAuthor.TabIndex = 3;
            this.textBoxAuthor.TextChanged += new System.EventHandler(this.textBoxAuthor_TextChanged);
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.textBoxDescription);
            this.groupBoxDescription.Location = new System.Drawing.Point(6, 177);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(328, 51);
            this.groupBoxDescription.TabIndex = 5;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Mod Description";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(6, 22);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(316, 23);
            this.textBoxDescription.TabIndex = 3;
            // 
            // buttonCreateMod
            // 
            this.buttonCreateMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateMod.Enabled = false;
            this.buttonCreateMod.Location = new System.Drawing.Point(186, 495);
            this.buttonCreateMod.Name = "buttonCreateMod";
            this.buttonCreateMod.Size = new System.Drawing.Size(161, 23);
            this.buttonCreateMod.TabIndex = 6;
            this.buttonCreateMod.Text = "Create Mod";
            this.buttonCreateMod.UseVisualStyleBackColor = true;
            this.buttonCreateMod.Click += new System.EventHandler(this.buttonCreateMod_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(19, 495);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(161, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxModId
            // 
            this.groupBoxModId.Controls.Add(this.labelModIdInfo);
            this.groupBoxModId.Controls.Add(this.textBoxModId);
            this.groupBoxModId.Location = new System.Drawing.Point(6, 348);
            this.groupBoxModId.Name = "groupBoxModId";
            this.groupBoxModId.Size = new System.Drawing.Size(328, 102);
            this.groupBoxModId.TabIndex = 6;
            this.groupBoxModId.TabStop = false;
            this.groupBoxModId.Text = "Mod ID";
            // 
            // labelModIdInfo
            // 
            this.labelModIdInfo.AutoSize = true;
            this.labelModIdInfo.Location = new System.Drawing.Point(6, 48);
            this.labelModIdInfo.Name = "labelModIdInfo";
            this.labelModIdInfo.Size = new System.Drawing.Size(295, 45);
            this.labelModIdInfo.TabIndex = 4;
            this.labelModIdInfo.Text = "Feel free to enter your own custom ID for the mod, but\r\nmake sure that no other m" +
    "od, by any other author or\r\nfor any other game, will have the same ID as yours!";
            // 
            // textBoxModId
            // 
            this.textBoxModId.Location = new System.Drawing.Point(6, 22);
            this.textBoxModId.Name = "textBoxModId";
            this.textBoxModId.Size = new System.Drawing.Size(316, 23);
            this.textBoxModId.TabIndex = 3;
            this.textBoxModId.TextChanged += new System.EventHandler(this.textBoxModId_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageModData);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(350, 483);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageModData
            // 
            this.tabPageModData.Controls.Add(this.groupBoxUpdatedAt);
            this.tabPageModData.Controls.Add(this.groupBoxCreatedAt);
            this.tabPageModData.Controls.Add(this.groupBoxGame);
            this.tabPageModData.Controls.Add(this.groupBoxModName);
            this.tabPageModData.Controls.Add(this.groupBoxAuthor);
            this.tabPageModData.Controls.Add(this.groupBoxModId);
            this.tabPageModData.Controls.Add(this.groupBoxDescription);
            this.tabPageModData.Location = new System.Drawing.Point(4, 24);
            this.tabPageModData.Name = "tabPageModData";
            this.tabPageModData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModData.Size = new System.Drawing.Size(342, 455);
            this.tabPageModData.TabIndex = 0;
            this.tabPageModData.Text = "Mod Data";
            this.tabPageModData.UseVisualStyleBackColor = true;
            // 
            // groupBoxUpdatedAt
            // 
            this.groupBoxUpdatedAt.Controls.Add(this.dateTimePickerUpdatedAt);
            this.groupBoxUpdatedAt.Location = new System.Drawing.Point(6, 291);
            this.groupBoxUpdatedAt.Name = "groupBoxUpdatedAt";
            this.groupBoxUpdatedAt.Size = new System.Drawing.Size(328, 51);
            this.groupBoxUpdatedAt.TabIndex = 7;
            this.groupBoxUpdatedAt.TabStop = false;
            this.groupBoxUpdatedAt.Text = "Updated At";
            // 
            // dateTimePickerUpdatedAt
            // 
            this.dateTimePickerUpdatedAt.Location = new System.Drawing.Point(6, 22);
            this.dateTimePickerUpdatedAt.Name = "dateTimePickerUpdatedAt";
            this.dateTimePickerUpdatedAt.Size = new System.Drawing.Size(316, 23);
            this.dateTimePickerUpdatedAt.TabIndex = 7;
            // 
            // groupBoxCreatedAt
            // 
            this.groupBoxCreatedAt.Controls.Add(this.dateTimePickerCreatedAt);
            this.groupBoxCreatedAt.Location = new System.Drawing.Point(6, 234);
            this.groupBoxCreatedAt.Name = "groupBoxCreatedAt";
            this.groupBoxCreatedAt.Size = new System.Drawing.Size(328, 51);
            this.groupBoxCreatedAt.TabIndex = 6;
            this.groupBoxCreatedAt.TabStop = false;
            this.groupBoxCreatedAt.Text = "Created At";
            // 
            // dateTimePickerCreatedAt
            // 
            this.dateTimePickerCreatedAt.Location = new System.Drawing.Point(6, 22);
            this.dateTimePickerCreatedAt.Name = "dateTimePickerCreatedAt";
            this.dateTimePickerCreatedAt.Size = new System.Drawing.Size(316, 23);
            this.dateTimePickerCreatedAt.TabIndex = 7;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.flowLayoutPanel1);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(342, 455);
            this.tabPageSettings.TabIndex = 3;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBoxGameId);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxIniValues);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxMergeHips);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxRemoveFiles);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxDolPatches);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(342, 455);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBoxGameId
            // 
            this.groupBoxGameId.Controls.Add(this.buttonGameIdInfo);
            this.groupBoxGameId.Controls.Add(this.labelDefaultGameId);
            this.groupBoxGameId.Controls.Add(this.textBoxGameId);
            this.groupBoxGameId.Location = new System.Drawing.Point(3, 3);
            this.groupBoxGameId.Name = "groupBoxGameId";
            this.groupBoxGameId.Size = new System.Drawing.Size(319, 69);
            this.groupBoxGameId.TabIndex = 8;
            this.groupBoxGameId.TabStop = false;
            this.groupBoxGameId.Text = "Save File Game ID";
            // 
            // buttonGameIdInfo
            // 
            this.buttonGameIdInfo.Location = new System.Drawing.Point(268, 22);
            this.buttonGameIdInfo.Name = "buttonGameIdInfo";
            this.buttonGameIdInfo.Size = new System.Drawing.Size(45, 23);
            this.buttonGameIdInfo.TabIndex = 8;
            this.buttonGameIdInfo.Text = "Info";
            this.buttonGameIdInfo.UseVisualStyleBackColor = true;
            this.buttonGameIdInfo.Click += new System.EventHandler(this.buttonGameIdInfo_Click);
            // 
            // labelDefaultGameId
            // 
            this.labelDefaultGameId.AutoSize = true;
            this.labelDefaultGameId.Location = new System.Drawing.Point(6, 48);
            this.labelDefaultGameId.Name = "labelDefaultGameId";
            this.labelDefaultGameId.Size = new System.Drawing.Size(95, 15);
            this.labelDefaultGameId.TabIndex = 5;
            this.labelDefaultGameId.Text = "Default game ID:";
            // 
            // textBoxGameId
            // 
            this.textBoxGameId.Location = new System.Drawing.Point(6, 22);
            this.textBoxGameId.Name = "textBoxGameId";
            this.textBoxGameId.Size = new System.Drawing.Size(256, 23);
            this.textBoxGameId.TabIndex = 3;
            // 
            // groupBoxIniValues
            // 
            this.groupBoxIniValues.Controls.Add(this.buttonIniValuesInfo);
            this.groupBoxIniValues.Controls.Add(this.richTextBoxINIValues);
            this.groupBoxIniValues.Location = new System.Drawing.Point(3, 78);
            this.groupBoxIniValues.Name = "groupBoxIniValues";
            this.groupBoxIniValues.Size = new System.Drawing.Size(319, 172);
            this.groupBoxIniValues.TabIndex = 9;
            this.groupBoxIniValues.TabStop = false;
            this.groupBoxIniValues.Text = "INI Values";
            // 
            // buttonIniValuesInfo
            // 
            this.buttonIniValuesInfo.Location = new System.Drawing.Point(268, -1);
            this.buttonIniValuesInfo.Name = "buttonIniValuesInfo";
            this.buttonIniValuesInfo.Size = new System.Drawing.Size(45, 23);
            this.buttonIniValuesInfo.TabIndex = 13;
            this.buttonIniValuesInfo.Text = "Info";
            this.buttonIniValuesInfo.UseVisualStyleBackColor = true;
            this.buttonIniValuesInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBoxINIValues
            // 
            this.richTextBoxINIValues.Location = new System.Drawing.Point(6, 22);
            this.richTextBoxINIValues.Name = "richTextBoxINIValues";
            this.richTextBoxINIValues.Size = new System.Drawing.Size(307, 144);
            this.richTextBoxINIValues.TabIndex = 12;
            this.richTextBoxINIValues.Text = "";
            // 
            // groupBoxMergeHips
            // 
            this.groupBoxMergeHips.Controls.Add(this.buttonMergeHipsInfo);
            this.groupBoxMergeHips.Controls.Add(this.richTextBoxMergeHips);
            this.groupBoxMergeHips.Location = new System.Drawing.Point(3, 256);
            this.groupBoxMergeHips.Name = "groupBoxMergeHips";
            this.groupBoxMergeHips.Size = new System.Drawing.Size(319, 172);
            this.groupBoxMergeHips.TabIndex = 10;
            this.groupBoxMergeHips.TabStop = false;
            this.groupBoxMergeHips.Text = "Merge HIP Files";
            // 
            // buttonMergeHipsInfo
            // 
            this.buttonMergeHipsInfo.Location = new System.Drawing.Point(268, -1);
            this.buttonMergeHipsInfo.Name = "buttonMergeHipsInfo";
            this.buttonMergeHipsInfo.Size = new System.Drawing.Size(45, 23);
            this.buttonMergeHipsInfo.TabIndex = 10;
            this.buttonMergeHipsInfo.Text = "Info";
            this.buttonMergeHipsInfo.UseVisualStyleBackColor = true;
            this.buttonMergeHipsInfo.Click += new System.EventHandler(this.buttonMergeHipsInfo_Click);
            // 
            // richTextBoxMergeHips
            // 
            this.richTextBoxMergeHips.Location = new System.Drawing.Point(6, 22);
            this.richTextBoxMergeHips.Name = "richTextBoxMergeHips";
            this.richTextBoxMergeHips.Size = new System.Drawing.Size(307, 144);
            this.richTextBoxMergeHips.TabIndex = 7;
            this.richTextBoxMergeHips.Text = "";
            // 
            // groupBoxRemoveFiles
            // 
            this.groupBoxRemoveFiles.Controls.Add(this.buttonRemoveFilesInfo);
            this.groupBoxRemoveFiles.Controls.Add(this.richTextBoxRemoveFiles);
            this.groupBoxRemoveFiles.Location = new System.Drawing.Point(3, 434);
            this.groupBoxRemoveFiles.Name = "groupBoxRemoveFiles";
            this.groupBoxRemoveFiles.Size = new System.Drawing.Size(319, 172);
            this.groupBoxRemoveFiles.TabIndex = 12;
            this.groupBoxRemoveFiles.TabStop = false;
            this.groupBoxRemoveFiles.Text = "Remove Files";
            // 
            // buttonRemoveFilesInfo
            // 
            this.buttonRemoveFilesInfo.Location = new System.Drawing.Point(268, -1);
            this.buttonRemoveFilesInfo.Name = "buttonRemoveFilesInfo";
            this.buttonRemoveFilesInfo.Size = new System.Drawing.Size(45, 23);
            this.buttonRemoveFilesInfo.TabIndex = 10;
            this.buttonRemoveFilesInfo.Text = "Info";
            this.buttonRemoveFilesInfo.UseVisualStyleBackColor = true;
            this.buttonRemoveFilesInfo.Click += new System.EventHandler(this.buttonRemoveFilesInfo_Click);
            // 
            // richTextBoxRemoveFiles
            // 
            this.richTextBoxRemoveFiles.Location = new System.Drawing.Point(6, 22);
            this.richTextBoxRemoveFiles.Name = "richTextBoxRemoveFiles";
            this.richTextBoxRemoveFiles.Size = new System.Drawing.Size(307, 144);
            this.richTextBoxRemoveFiles.TabIndex = 10;
            this.richTextBoxRemoveFiles.Text = "";
            // 
            // groupBoxDolPatches
            // 
            this.groupBoxDolPatches.Controls.Add(this.buttonDolPatchesInfo);
            this.groupBoxDolPatches.Controls.Add(this.richTextBoxDolPatches);
            this.groupBoxDolPatches.Location = new System.Drawing.Point(3, 612);
            this.groupBoxDolPatches.Name = "groupBoxDolPatches";
            this.groupBoxDolPatches.Size = new System.Drawing.Size(319, 172);
            this.groupBoxDolPatches.TabIndex = 14;
            this.groupBoxDolPatches.TabStop = false;
            this.groupBoxDolPatches.Text = "DOL Patches";
            // 
            // buttonDolPatchesInfo
            // 
            this.buttonDolPatchesInfo.Location = new System.Drawing.Point(268, -1);
            this.buttonDolPatchesInfo.Name = "buttonDolPatchesInfo";
            this.buttonDolPatchesInfo.Size = new System.Drawing.Size(45, 23);
            this.buttonDolPatchesInfo.TabIndex = 13;
            this.buttonDolPatchesInfo.Text = "Info";
            this.buttonDolPatchesInfo.UseVisualStyleBackColor = true;
            this.buttonDolPatchesInfo.Click += new System.EventHandler(this.buttonDolPatchesInfo_Click);
            // 
            // richTextBoxDolPatches
            // 
            this.richTextBoxDolPatches.Location = new System.Drawing.Point(6, 22);
            this.richTextBoxDolPatches.Name = "richTextBoxDolPatches";
            this.richTextBoxDolPatches.Size = new System.Drawing.Size(307, 144);
            this.richTextBoxDolPatches.TabIndex = 12;
            this.richTextBoxDolPatches.Text = "";
            // 
            // CreateMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 527);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreateMod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateMod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Mod";
            this.groupBoxGame.ResumeLayout(false);
            this.groupBoxModName.ResumeLayout(false);
            this.groupBoxModName.PerformLayout();
            this.groupBoxAuthor.ResumeLayout(false);
            this.groupBoxAuthor.PerformLayout();
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.groupBoxModId.ResumeLayout(false);
            this.groupBoxModId.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageModData.ResumeLayout(false);
            this.groupBoxUpdatedAt.ResumeLayout(false);
            this.groupBoxCreatedAt.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBoxGameId.ResumeLayout(false);
            this.groupBoxGameId.PerformLayout();
            this.groupBoxIniValues.ResumeLayout(false);
            this.groupBoxMergeHips.ResumeLayout(false);
            this.groupBoxRemoveFiles.ResumeLayout(false);
            this.groupBoxDolPatches.ResumeLayout(false);
            this.ResumeLayout(false);

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