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
        buttonCreateMod = new Button();
        buttonCancel = new Button();
        tabControl1 = new TabControl();
        tabPageModData = new TabPage();
        flowLayoutPanelPage1 = new FlowLayoutPanel();
        groupBoxGame = new GroupBox();
        comboBoxGame = new ComboBox();
        groupBoxModName = new GroupBox();
        textBoxModName = new TextBox();
        groupBoxAuthor = new GroupBox();
        textBoxAuthor = new TextBox();
        groupBoxDescription = new GroupBox();
        richTextBoxDescription = new RichTextBox();
        groupBoxCreatedAt = new GroupBox();
        dateTimePickerCreatedAt = new DateTimePicker();
        groupBoxUpdatedAt = new GroupBox();
        dateTimePickerUpdatedAt = new DateTimePicker();
        groupBoxModId = new GroupBox();
        buttonModIdInfo = new Button();
        textBoxModId = new TextBox();
        tabPageSettings = new TabPage();
        flowLayoutPanelPage2 = new FlowLayoutPanel();
        groupBoxGameId = new GroupBox();
        buttonGameIdInfo = new Button();
        labelDefaultGameId = new Label();
        textBoxGameId = new TextBox();
        groupBoxIniValues = new GroupBox();
        buttonIniImport = new Button();
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
        groupBoxArCodes = new GroupBox();
        buttonArCodesInfo = new Button();
        richTextBoxArCodes = new RichTextBox();
        groupBoxGeckoCodes = new GroupBox();
        buttonGeckoCodesInfo = new Button();
        richTextBoxGeckoCodes = new RichTextBox();
        tabControl1.SuspendLayout();
        tabPageModData.SuspendLayout();
        flowLayoutPanelPage1.SuspendLayout();
        groupBoxGame.SuspendLayout();
        groupBoxModName.SuspendLayout();
        groupBoxAuthor.SuspendLayout();
        groupBoxDescription.SuspendLayout();
        groupBoxCreatedAt.SuspendLayout();
        groupBoxUpdatedAt.SuspendLayout();
        groupBoxModId.SuspendLayout();
        tabPageSettings.SuspendLayout();
        flowLayoutPanelPage2.SuspendLayout();
        groupBoxGameId.SuspendLayout();
        groupBoxIniValues.SuspendLayout();
        groupBoxMergeHips.SuspendLayout();
        groupBoxRemoveFiles.SuspendLayout();
        groupBoxDolPatches.SuspendLayout();
        groupBoxArCodes.SuspendLayout();
        groupBoxGeckoCodes.SuspendLayout();
        SuspendLayout();
        // 
        // buttonCreateMod
        // 
        buttonCreateMod.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCreateMod.Enabled = false;
        buttonCreateMod.Location = new Point(187, 560);
        buttonCreateMod.Name = "buttonCreateMod";
        buttonCreateMod.Size = new Size(169, 23);
        buttonCreateMod.TabIndex = 72;
        buttonCreateMod.Text = "Create Mod";
        buttonCreateMod.UseVisualStyleBackColor = true;
        buttonCreateMod.Click += buttonCreateMod_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonCancel.Location = new Point(12, 560);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(169, 23);
        buttonCancel.TabIndex = 71;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
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
        tabControl1.Size = new Size(350, 548);
        tabControl1.TabIndex = 0;
        tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        // 
        // tabPageModData
        // 
        tabPageModData.Controls.Add(flowLayoutPanelPage1);
        tabPageModData.Location = new Point(4, 24);
        tabPageModData.Name = "tabPageModData";
        tabPageModData.Size = new Size(342, 520);
        tabPageModData.TabIndex = 4;
        tabPageModData.Text = "Mod Metadata";
        tabPageModData.UseVisualStyleBackColor = true;
        // 
        // flowLayoutPanelPage1
        // 
        flowLayoutPanelPage1.AutoScroll = true;
        flowLayoutPanelPage1.Controls.Add(groupBoxGame);
        flowLayoutPanelPage1.Controls.Add(groupBoxModName);
        flowLayoutPanelPage1.Controls.Add(groupBoxAuthor);
        flowLayoutPanelPage1.Controls.Add(groupBoxDescription);
        flowLayoutPanelPage1.Controls.Add(groupBoxCreatedAt);
        flowLayoutPanelPage1.Controls.Add(groupBoxUpdatedAt);
        flowLayoutPanelPage1.Controls.Add(groupBoxModId);
        flowLayoutPanelPage1.Dock = DockStyle.Fill;
        flowLayoutPanelPage1.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanelPage1.Location = new Point(0, 0);
        flowLayoutPanelPage1.Name = "flowLayoutPanelPage1";
        flowLayoutPanelPage1.Size = new Size(342, 520);
        flowLayoutPanelPage1.TabIndex = 0;
        flowLayoutPanelPage1.WrapContents = false;
        flowLayoutPanelPage1.Resize += flowLayoutPanelPage1_Resize;
        // 
        // groupBoxGame
        // 
        groupBoxGame.Controls.Add(comboBoxGame);
        groupBoxGame.Location = new Point(3, 3);
        groupBoxGame.Name = "groupBoxGame";
        groupBoxGame.Size = new Size(319, 51);
        groupBoxGame.TabIndex = 1;
        groupBoxGame.TabStop = false;
        groupBoxGame.Text = "Game";
        // 
        // comboBoxGame
        // 
        comboBoxGame.Dock = DockStyle.Fill;
        comboBoxGame.FormattingEnabled = true;
        comboBoxGame.Location = new Point(3, 19);
        comboBoxGame.Name = "comboBoxGame";
        comboBoxGame.Size = new Size(313, 23);
        comboBoxGame.TabIndex = 2;
        comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
        // 
        // groupBoxModName
        // 
        groupBoxModName.Controls.Add(textBoxModName);
        groupBoxModName.Dock = DockStyle.Top;
        groupBoxModName.Location = new Point(3, 60);
        groupBoxModName.Name = "groupBoxModName";
        groupBoxModName.Size = new Size(319, 51);
        groupBoxModName.TabIndex = 3;
        groupBoxModName.TabStop = false;
        groupBoxModName.Text = "Mod Name";
        // 
        // textBoxModName
        // 
        textBoxModName.Dock = DockStyle.Fill;
        textBoxModName.Location = new Point(3, 19);
        textBoxModName.Name = "textBoxModName";
        textBoxModName.Size = new Size(313, 23);
        textBoxModName.TabIndex = 4;
        textBoxModName.TextChanged += textBoxModName_TextChanged;
        // 
        // groupBoxAuthor
        // 
        groupBoxAuthor.Controls.Add(textBoxAuthor);
        groupBoxAuthor.Dock = DockStyle.Top;
        groupBoxAuthor.Location = new Point(3, 117);
        groupBoxAuthor.Name = "groupBoxAuthor";
        groupBoxAuthor.Size = new Size(319, 51);
        groupBoxAuthor.TabIndex = 5;
        groupBoxAuthor.TabStop = false;
        groupBoxAuthor.Text = "Mod Author";
        // 
        // textBoxAuthor
        // 
        textBoxAuthor.Dock = DockStyle.Fill;
        textBoxAuthor.Location = new Point(3, 19);
        textBoxAuthor.Name = "textBoxAuthor";
        textBoxAuthor.Size = new Size(313, 23);
        textBoxAuthor.TabIndex = 6;
        textBoxAuthor.TextChanged += textBoxAuthor_TextChanged;
        // 
        // groupBoxDescription
        // 
        groupBoxDescription.Controls.Add(richTextBoxDescription);
        groupBoxDescription.Dock = DockStyle.Top;
        groupBoxDescription.Location = new Point(3, 174);
        groupBoxDescription.Name = "groupBoxDescription";
        groupBoxDescription.Size = new Size(319, 172);
        groupBoxDescription.TabIndex = 7;
        groupBoxDescription.TabStop = false;
        groupBoxDescription.Text = "Mod Description";
        // 
        // richTextBoxDescription
        // 
        richTextBoxDescription.Dock = DockStyle.Fill;
        richTextBoxDescription.Location = new Point(3, 19);
        richTextBoxDescription.Name = "richTextBoxDescription";
        richTextBoxDescription.Size = new Size(313, 150);
        richTextBoxDescription.TabIndex = 8;
        richTextBoxDescription.Text = "";
        // 
        // groupBoxCreatedAt
        // 
        groupBoxCreatedAt.Controls.Add(dateTimePickerCreatedAt);
        groupBoxCreatedAt.Dock = DockStyle.Top;
        groupBoxCreatedAt.Location = new Point(3, 352);
        groupBoxCreatedAt.Name = "groupBoxCreatedAt";
        groupBoxCreatedAt.Size = new Size(319, 51);
        groupBoxCreatedAt.TabIndex = 9;
        groupBoxCreatedAt.TabStop = false;
        groupBoxCreatedAt.Text = "Created At";
        // 
        // dateTimePickerCreatedAt
        // 
        dateTimePickerCreatedAt.Dock = DockStyle.Fill;
        dateTimePickerCreatedAt.Location = new Point(3, 19);
        dateTimePickerCreatedAt.Name = "dateTimePickerCreatedAt";
        dateTimePickerCreatedAt.Size = new Size(313, 23);
        dateTimePickerCreatedAt.TabIndex = 10;
        // 
        // groupBoxUpdatedAt
        // 
        groupBoxUpdatedAt.Controls.Add(dateTimePickerUpdatedAt);
        groupBoxUpdatedAt.Dock = DockStyle.Top;
        groupBoxUpdatedAt.Location = new Point(3, 409);
        groupBoxUpdatedAt.Name = "groupBoxUpdatedAt";
        groupBoxUpdatedAt.Size = new Size(319, 51);
        groupBoxUpdatedAt.TabIndex = 11;
        groupBoxUpdatedAt.TabStop = false;
        groupBoxUpdatedAt.Text = "Updated At";
        // 
        // dateTimePickerUpdatedAt
        // 
        dateTimePickerUpdatedAt.Dock = DockStyle.Fill;
        dateTimePickerUpdatedAt.Location = new Point(3, 19);
        dateTimePickerUpdatedAt.Name = "dateTimePickerUpdatedAt";
        dateTimePickerUpdatedAt.Size = new Size(313, 23);
        dateTimePickerUpdatedAt.TabIndex = 12;
        // 
        // groupBoxModId
        // 
        groupBoxModId.Controls.Add(buttonModIdInfo);
        groupBoxModId.Controls.Add(textBoxModId);
        groupBoxModId.Dock = DockStyle.Top;
        groupBoxModId.Location = new Point(3, 466);
        groupBoxModId.Name = "groupBoxModId";
        groupBoxModId.Size = new Size(319, 51);
        groupBoxModId.TabIndex = 13;
        groupBoxModId.TabStop = false;
        groupBoxModId.Text = "Mod ID";
        // 
        // buttonModIdInfo
        // 
        buttonModIdInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonModIdInfo.Location = new Point(268, -1);
        buttonModIdInfo.Name = "buttonModIdInfo";
        buttonModIdInfo.Size = new Size(45, 23);
        buttonModIdInfo.TabIndex = 14;
        buttonModIdInfo.Text = "Info";
        buttonModIdInfo.UseVisualStyleBackColor = true;
        buttonModIdInfo.Click += buttonModIdInfo_Click;
        // 
        // textBoxModId
        // 
        textBoxModId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxModId.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
        textBoxModId.Location = new Point(3, 19);
        textBoxModId.Name = "textBoxModId";
        textBoxModId.Size = new Size(310, 22);
        textBoxModId.TabIndex = 15;
        textBoxModId.TextChanged += textBoxModId_TextChanged;
        // 
        // tabPageSettings
        // 
        tabPageSettings.Controls.Add(flowLayoutPanelPage2);
        tabPageSettings.Location = new Point(4, 24);
        tabPageSettings.Name = "tabPageSettings";
        tabPageSettings.Size = new Size(342, 520);
        tabPageSettings.TabIndex = 3;
        tabPageSettings.Text = "Patches and Replacements";
        tabPageSettings.UseVisualStyleBackColor = true;
        // 
        // flowLayoutPanelPage2
        // 
        flowLayoutPanelPage2.AutoScroll = true;
        flowLayoutPanelPage2.Controls.Add(groupBoxGameId);
        flowLayoutPanelPage2.Controls.Add(groupBoxIniValues);
        flowLayoutPanelPage2.Controls.Add(groupBoxMergeHips);
        flowLayoutPanelPage2.Controls.Add(groupBoxRemoveFiles);
        flowLayoutPanelPage2.Controls.Add(groupBoxDolPatches);
        flowLayoutPanelPage2.Controls.Add(groupBoxArCodes);
        flowLayoutPanelPage2.Controls.Add(groupBoxGeckoCodes);
        flowLayoutPanelPage2.Dock = DockStyle.Fill;
        flowLayoutPanelPage2.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanelPage2.Location = new Point(0, 0);
        flowLayoutPanelPage2.Name = "flowLayoutPanelPage2";
        flowLayoutPanelPage2.Size = new Size(342, 520);
        flowLayoutPanelPage2.TabIndex = 16;
        flowLayoutPanelPage2.WrapContents = false;
        flowLayoutPanelPage2.Resize += flowLayoutPanelPage2_Resize;
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
        groupBoxGameId.Text = "Game ID (Save File)";
        // 
        // buttonGameIdInfo
        // 
        buttonGameIdInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
        textBoxGameId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxGameId.Location = new Point(6, 22);
        textBoxGameId.Name = "textBoxGameId";
        textBoxGameId.Size = new Size(256, 23);
        textBoxGameId.TabIndex = 18;
        textBoxGameId.TextChanged += textBoxGameId_TextChanged;
        // 
        // groupBoxIniValues
        // 
        groupBoxIniValues.Controls.Add(buttonIniImport);
        groupBoxIniValues.Controls.Add(buttonIniValuesInfo);
        groupBoxIniValues.Controls.Add(richTextBoxINIValues);
        groupBoxIniValues.Dock = DockStyle.Top;
        groupBoxIniValues.Location = new Point(3, 78);
        groupBoxIniValues.Name = "groupBoxIniValues";
        groupBoxIniValues.Size = new Size(319, 172);
        groupBoxIniValues.TabIndex = 21;
        groupBoxIniValues.TabStop = false;
        groupBoxIniValues.Text = "INI Values";
        // 
        // buttonIniImport
        // 
        buttonIniImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonIniImport.Location = new Point(208, -1);
        buttonIniImport.Name = "buttonIniImport";
        buttonIniImport.Size = new Size(54, 23);
        buttonIniImport.TabIndex = 24;
        buttonIniImport.Text = "Import";
        buttonIniImport.UseVisualStyleBackColor = true;
        buttonIniImport.Click += buttonIniImport_Click;
        // 
        // buttonIniValuesInfo
        // 
        buttonIniValuesInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonIniValuesInfo.Location = new Point(268, -1);
        buttonIniValuesInfo.Name = "buttonIniValuesInfo";
        buttonIniValuesInfo.Size = new Size(45, 23);
        buttonIniValuesInfo.TabIndex = 22;
        buttonIniValuesInfo.Text = "Info";
        buttonIniValuesInfo.UseVisualStyleBackColor = true;
        buttonIniValuesInfo.Click += buttonIniValuesInfo_Click;
        // 
        // richTextBoxINIValues
        // 
        richTextBoxINIValues.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        richTextBoxINIValues.Location = new Point(6, 22);
        richTextBoxINIValues.Name = "richTextBoxINIValues";
        richTextBoxINIValues.Size = new Size(307, 144);
        richTextBoxINIValues.TabIndex = 23;
        richTextBoxINIValues.Text = "";
        richTextBoxINIValues.TextChanged += richTextBoxINIValues_TextChanged;
        // 
        // groupBoxMergeHips
        // 
        groupBoxMergeHips.Controls.Add(buttonMergeHipsInfo);
        groupBoxMergeHips.Controls.Add(richTextBoxMergeHips);
        groupBoxMergeHips.Dock = DockStyle.Top;
        groupBoxMergeHips.Location = new Point(3, 256);
        groupBoxMergeHips.Name = "groupBoxMergeHips";
        groupBoxMergeHips.Size = new Size(319, 172);
        groupBoxMergeHips.TabIndex = 24;
        groupBoxMergeHips.TabStop = false;
        groupBoxMergeHips.Text = "Merge HIP Files";
        // 
        // buttonMergeHipsInfo
        // 
        buttonMergeHipsInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
        richTextBoxMergeHips.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
        groupBoxRemoveFiles.Dock = DockStyle.Top;
        groupBoxRemoveFiles.Location = new Point(3, 434);
        groupBoxRemoveFiles.Name = "groupBoxRemoveFiles";
        groupBoxRemoveFiles.Size = new Size(319, 172);
        groupBoxRemoveFiles.TabIndex = 27;
        groupBoxRemoveFiles.TabStop = false;
        groupBoxRemoveFiles.Text = "Remove Files";
        // 
        // buttonRemoveFilesInfo
        // 
        buttonRemoveFilesInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
        richTextBoxRemoveFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
        groupBoxDolPatches.Dock = DockStyle.Top;
        groupBoxDolPatches.Location = new Point(3, 612);
        groupBoxDolPatches.Name = "groupBoxDolPatches";
        groupBoxDolPatches.Size = new Size(319, 172);
        groupBoxDolPatches.TabIndex = 30;
        groupBoxDolPatches.TabStop = false;
        groupBoxDolPatches.Text = "DOL Patches";
        // 
        // buttonDolPatchesInfo
        // 
        buttonDolPatchesInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
        richTextBoxDolPatches.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        richTextBoxDolPatches.Location = new Point(6, 22);
        richTextBoxDolPatches.Name = "richTextBoxDolPatches";
        richTextBoxDolPatches.Size = new Size(307, 144);
        richTextBoxDolPatches.TabIndex = 32;
        richTextBoxDolPatches.Text = "";
        richTextBoxDolPatches.TextChanged += richTextBoxDolPatches_TextChanged;
        // 
        // groupBoxArCodes
        // 
        groupBoxArCodes.Controls.Add(buttonArCodesInfo);
        groupBoxArCodes.Controls.Add(richTextBoxArCodes);
        groupBoxArCodes.Dock = DockStyle.Top;
        groupBoxArCodes.Location = new Point(3, 790);
        groupBoxArCodes.Name = "groupBoxArCodes";
        groupBoxArCodes.Size = new Size(319, 172);
        groupBoxArCodes.TabIndex = 33;
        groupBoxArCodes.TabStop = false;
        groupBoxArCodes.Text = "AR Codes";
        // 
        // buttonArCodesInfo
        // 
        buttonArCodesInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonArCodesInfo.Location = new Point(268, -1);
        buttonArCodesInfo.Name = "buttonArCodesInfo";
        buttonArCodesInfo.Size = new Size(45, 23);
        buttonArCodesInfo.TabIndex = 34;
        buttonArCodesInfo.Text = "Info";
        buttonArCodesInfo.UseVisualStyleBackColor = true;
        buttonArCodesInfo.Click += buttonArCodesInfo_Click;
        // 
        // richTextBoxArCodes
        // 
        richTextBoxArCodes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        richTextBoxArCodes.Location = new Point(6, 22);
        richTextBoxArCodes.Name = "richTextBoxArCodes";
        richTextBoxArCodes.Size = new Size(307, 144);
        richTextBoxArCodes.TabIndex = 35;
        richTextBoxArCodes.Text = "";
        richTextBoxArCodes.TextChanged += richTextBoxArCodes_TextChanged;
        // 
        // groupBoxGeckoCodes
        // 
        groupBoxGeckoCodes.Controls.Add(buttonGeckoCodesInfo);
        groupBoxGeckoCodes.Controls.Add(richTextBoxGeckoCodes);
        groupBoxGeckoCodes.Dock = DockStyle.Top;
        groupBoxGeckoCodes.Location = new Point(3, 968);
        groupBoxGeckoCodes.Name = "groupBoxGeckoCodes";
        groupBoxGeckoCodes.Size = new Size(319, 172);
        groupBoxGeckoCodes.TabIndex = 36;
        groupBoxGeckoCodes.TabStop = false;
        groupBoxGeckoCodes.Text = "Gecko Codes";
        // 
        // buttonGeckoCodesInfo
        // 
        buttonGeckoCodesInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonGeckoCodesInfo.Location = new Point(268, -1);
        buttonGeckoCodesInfo.Name = "buttonGeckoCodesInfo";
        buttonGeckoCodesInfo.Size = new Size(45, 23);
        buttonGeckoCodesInfo.TabIndex = 37;
        buttonGeckoCodesInfo.Text = "Info";
        buttonGeckoCodesInfo.UseVisualStyleBackColor = true;
        buttonGeckoCodesInfo.Click += buttonGeckoCodesInfo_Click;
        // 
        // richTextBoxGeckoCodes
        // 
        richTextBoxGeckoCodes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        richTextBoxGeckoCodes.Location = new Point(6, 22);
        richTextBoxGeckoCodes.Name = "richTextBoxGeckoCodes";
        richTextBoxGeckoCodes.Size = new Size(307, 144);
        richTextBoxGeckoCodes.TabIndex = 38;
        richTextBoxGeckoCodes.Text = "";
        richTextBoxGeckoCodes.TextChanged += richTextBoxGeckoCodes_TextChanged;
        // 
        // CreateMod
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(368, 590);
        Controls.Add(tabControl1);
        Controls.Add(buttonCancel);
        Controls.Add(buttonCreateMod);
        Name = "CreateMod";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Create New Mod";
        tabControl1.ResumeLayout(false);
        tabPageModData.ResumeLayout(false);
        flowLayoutPanelPage1.ResumeLayout(false);
        groupBoxGame.ResumeLayout(false);
        groupBoxModName.ResumeLayout(false);
        groupBoxModName.PerformLayout();
        groupBoxAuthor.ResumeLayout(false);
        groupBoxAuthor.PerformLayout();
        groupBoxDescription.ResumeLayout(false);
        groupBoxCreatedAt.ResumeLayout(false);
        groupBoxUpdatedAt.ResumeLayout(false);
        groupBoxModId.ResumeLayout(false);
        groupBoxModId.PerformLayout();
        tabPageSettings.ResumeLayout(false);
        flowLayoutPanelPage2.ResumeLayout(false);
        groupBoxGameId.ResumeLayout(false);
        groupBoxGameId.PerformLayout();
        groupBoxIniValues.ResumeLayout(false);
        groupBoxMergeHips.ResumeLayout(false);
        groupBoxRemoveFiles.ResumeLayout(false);
        groupBoxDolPatches.ResumeLayout(false);
        groupBoxArCodes.ResumeLayout(false);
        groupBoxGeckoCodes.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private Button buttonCreateMod;
    private Button buttonCancel;
    private TabControl tabControl1;
    private TabPage tabPageModData;
    private TabPage tabPageSettings;
    private FlowLayoutPanel flowLayoutPanelPage2;
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
    private FlowLayoutPanel flowLayoutPanelPage1;
    private GroupBox groupBoxGame;
    private ComboBox comboBoxGame;
    private GroupBox groupBoxModName;
    private TextBox textBoxModName;
    private GroupBox groupBoxAuthor;
    private TextBox textBoxAuthor;
    private GroupBox groupBoxDescription;
    private RichTextBox richTextBoxDescription;
    private GroupBox groupBoxUpdatedAt;
    private DateTimePicker dateTimePickerUpdatedAt;
    private GroupBox groupBoxCreatedAt;
    private DateTimePicker dateTimePickerCreatedAt;
    private GroupBox groupBoxModId;
    private TextBox textBoxModId;
    private Button buttonModIdInfo;
    private Button buttonIniImport;
    private GroupBox groupBoxArCodes;
    private Button buttonArCodesInfo;
    private RichTextBox richTextBoxArCodes;
    private GroupBox groupBoxGeckoCodes;
    private Button buttonGeckoCodesInfo;
    private RichTextBox richTextBoxGeckoCodes;
}