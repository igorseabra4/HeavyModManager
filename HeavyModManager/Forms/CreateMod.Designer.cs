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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateMod));
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
        groupBoxIpsPatch = new GroupBox();
        textBoxIpsPatch = new TextBox();
        buttonOpenIpsFile = new Button();
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
        groupBoxIpsPatch.SuspendLayout();
        SuspendLayout();
        // 
        // buttonCreateMod
        // 
        resources.ApplyResources(buttonCreateMod, "buttonCreateMod");
        buttonCreateMod.Name = "buttonCreateMod";
        buttonCreateMod.UseVisualStyleBackColor = true;
        buttonCreateMod.Click += buttonCreateMod_Click;
        // 
        // buttonCancel
        // 
        resources.ApplyResources(buttonCancel, "buttonCancel");
        buttonCancel.Name = "buttonCancel";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // tabControl1
        // 
        resources.ApplyResources(tabControl1, "tabControl1");
        tabControl1.Controls.Add(tabPageModData);
        tabControl1.Controls.Add(tabPageSettings);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        // 
        // tabPageModData
        // 
        tabPageModData.Controls.Add(flowLayoutPanelPage1);
        resources.ApplyResources(tabPageModData, "tabPageModData");
        tabPageModData.Name = "tabPageModData";
        tabPageModData.UseVisualStyleBackColor = true;
        // 
        // flowLayoutPanelPage1
        // 
        resources.ApplyResources(flowLayoutPanelPage1, "flowLayoutPanelPage1");
        flowLayoutPanelPage1.Controls.Add(groupBoxGame);
        flowLayoutPanelPage1.Controls.Add(groupBoxModName);
        flowLayoutPanelPage1.Controls.Add(groupBoxAuthor);
        flowLayoutPanelPage1.Controls.Add(groupBoxDescription);
        flowLayoutPanelPage1.Controls.Add(groupBoxCreatedAt);
        flowLayoutPanelPage1.Controls.Add(groupBoxUpdatedAt);
        flowLayoutPanelPage1.Controls.Add(groupBoxModId);
        flowLayoutPanelPage1.Name = "flowLayoutPanelPage1";
        flowLayoutPanelPage1.Resize += flowLayoutPanelPage1_Resize;
        // 
        // groupBoxGame
        // 
        groupBoxGame.Controls.Add(comboBoxGame);
        resources.ApplyResources(groupBoxGame, "groupBoxGame");
        groupBoxGame.Name = "groupBoxGame";
        groupBoxGame.TabStop = false;
        // 
        // comboBoxGame
        // 
        resources.ApplyResources(comboBoxGame, "comboBoxGame");
        comboBoxGame.FormattingEnabled = true;
        comboBoxGame.Name = "comboBoxGame";
        comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
        // 
        // groupBoxModName
        // 
        groupBoxModName.Controls.Add(textBoxModName);
        resources.ApplyResources(groupBoxModName, "groupBoxModName");
        groupBoxModName.Name = "groupBoxModName";
        groupBoxModName.TabStop = false;
        // 
        // textBoxModName
        // 
        resources.ApplyResources(textBoxModName, "textBoxModName");
        textBoxModName.Name = "textBoxModName";
        textBoxModName.TextChanged += textBoxModName_TextChanged;
        // 
        // groupBoxAuthor
        // 
        groupBoxAuthor.Controls.Add(textBoxAuthor);
        resources.ApplyResources(groupBoxAuthor, "groupBoxAuthor");
        groupBoxAuthor.Name = "groupBoxAuthor";
        groupBoxAuthor.TabStop = false;
        // 
        // textBoxAuthor
        // 
        resources.ApplyResources(textBoxAuthor, "textBoxAuthor");
        textBoxAuthor.Name = "textBoxAuthor";
        textBoxAuthor.TextChanged += textBoxAuthor_TextChanged;
        // 
        // groupBoxDescription
        // 
        groupBoxDescription.Controls.Add(richTextBoxDescription);
        resources.ApplyResources(groupBoxDescription, "groupBoxDescription");
        groupBoxDescription.Name = "groupBoxDescription";
        groupBoxDescription.TabStop = false;
        // 
        // richTextBoxDescription
        // 
        resources.ApplyResources(richTextBoxDescription, "richTextBoxDescription");
        richTextBoxDescription.Name = "richTextBoxDescription";
        // 
        // groupBoxCreatedAt
        // 
        groupBoxCreatedAt.Controls.Add(dateTimePickerCreatedAt);
        resources.ApplyResources(groupBoxCreatedAt, "groupBoxCreatedAt");
        groupBoxCreatedAt.Name = "groupBoxCreatedAt";
        groupBoxCreatedAt.TabStop = false;
        // 
        // dateTimePickerCreatedAt
        // 
        resources.ApplyResources(dateTimePickerCreatedAt, "dateTimePickerCreatedAt");
        dateTimePickerCreatedAt.Name = "dateTimePickerCreatedAt";
        // 
        // groupBoxUpdatedAt
        // 
        groupBoxUpdatedAt.Controls.Add(dateTimePickerUpdatedAt);
        resources.ApplyResources(groupBoxUpdatedAt, "groupBoxUpdatedAt");
        groupBoxUpdatedAt.Name = "groupBoxUpdatedAt";
        groupBoxUpdatedAt.TabStop = false;
        // 
        // dateTimePickerUpdatedAt
        // 
        resources.ApplyResources(dateTimePickerUpdatedAt, "dateTimePickerUpdatedAt");
        dateTimePickerUpdatedAt.Name = "dateTimePickerUpdatedAt";
        // 
        // groupBoxModId
        // 
        groupBoxModId.Controls.Add(buttonModIdInfo);
        groupBoxModId.Controls.Add(textBoxModId);
        resources.ApplyResources(groupBoxModId, "groupBoxModId");
        groupBoxModId.Name = "groupBoxModId";
        groupBoxModId.TabStop = false;
        // 
        // buttonModIdInfo
        // 
        resources.ApplyResources(buttonModIdInfo, "buttonModIdInfo");
        buttonModIdInfo.Name = "buttonModIdInfo";
        buttonModIdInfo.UseVisualStyleBackColor = true;
        buttonModIdInfo.Click += buttonModIdInfo_Click;
        // 
        // textBoxModId
        // 
        resources.ApplyResources(textBoxModId, "textBoxModId");
        textBoxModId.Name = "textBoxModId";
        textBoxModId.TextChanged += textBoxModId_TextChanged;
        // 
        // tabPageSettings
        // 
        tabPageSettings.Controls.Add(flowLayoutPanelPage2);
        resources.ApplyResources(tabPageSettings, "tabPageSettings");
        tabPageSettings.Name = "tabPageSettings";
        tabPageSettings.UseVisualStyleBackColor = true;
        // 
        // flowLayoutPanelPage2
        // 
        resources.ApplyResources(flowLayoutPanelPage2, "flowLayoutPanelPage2");
        flowLayoutPanelPage2.Controls.Add(groupBoxGameId);
        flowLayoutPanelPage2.Controls.Add(groupBoxIniValues);
        flowLayoutPanelPage2.Controls.Add(groupBoxMergeHips);
        flowLayoutPanelPage2.Controls.Add(groupBoxRemoveFiles);
        flowLayoutPanelPage2.Controls.Add(groupBoxDolPatches);
        flowLayoutPanelPage2.Controls.Add(groupBoxIpsPatch);
        flowLayoutPanelPage2.Controls.Add(groupBoxArCodes);
        flowLayoutPanelPage2.Controls.Add(groupBoxGeckoCodes);
        flowLayoutPanelPage2.Name = "flowLayoutPanelPage2";
        flowLayoutPanelPage2.Resize += flowLayoutPanelPage2_Resize;
        // 
        // groupBoxGameId
        // 
        groupBoxGameId.Controls.Add(buttonGameIdInfo);
        groupBoxGameId.Controls.Add(labelDefaultGameId);
        groupBoxGameId.Controls.Add(textBoxGameId);
        resources.ApplyResources(groupBoxGameId, "groupBoxGameId");
        groupBoxGameId.Name = "groupBoxGameId";
        groupBoxGameId.TabStop = false;
        // 
        // buttonGameIdInfo
        // 
        resources.ApplyResources(buttonGameIdInfo, "buttonGameIdInfo");
        buttonGameIdInfo.Name = "buttonGameIdInfo";
        buttonGameIdInfo.UseVisualStyleBackColor = true;
        buttonGameIdInfo.Click += buttonGameIdInfo_Click;
        // 
        // labelDefaultGameId
        // 
        resources.ApplyResources(labelDefaultGameId, "labelDefaultGameId");
        labelDefaultGameId.Name = "labelDefaultGameId";
        // 
        // textBoxGameId
        // 
        resources.ApplyResources(textBoxGameId, "textBoxGameId");
        textBoxGameId.Name = "textBoxGameId";
        textBoxGameId.TextChanged += textBoxGameId_TextChanged;
        // 
        // groupBoxIniValues
        // 
        groupBoxIniValues.Controls.Add(buttonIniImport);
        groupBoxIniValues.Controls.Add(buttonIniValuesInfo);
        groupBoxIniValues.Controls.Add(richTextBoxINIValues);
        resources.ApplyResources(groupBoxIniValues, "groupBoxIniValues");
        groupBoxIniValues.Name = "groupBoxIniValues";
        groupBoxIniValues.TabStop = false;
        // 
        // buttonIniImport
        // 
        resources.ApplyResources(buttonIniImport, "buttonIniImport");
        buttonIniImport.Name = "buttonIniImport";
        buttonIniImport.UseVisualStyleBackColor = true;
        buttonIniImport.Click += buttonIniImport_Click;
        // 
        // buttonIniValuesInfo
        // 
        resources.ApplyResources(buttonIniValuesInfo, "buttonIniValuesInfo");
        buttonIniValuesInfo.Name = "buttonIniValuesInfo";
        buttonIniValuesInfo.UseVisualStyleBackColor = true;
        buttonIniValuesInfo.Click += buttonIniValuesInfo_Click;
        // 
        // richTextBoxINIValues
        // 
        resources.ApplyResources(richTextBoxINIValues, "richTextBoxINIValues");
        richTextBoxINIValues.Name = "richTextBoxINIValues";
        richTextBoxINIValues.TextChanged += richTextBoxINIValues_TextChanged;
        // 
        // groupBoxMergeHips
        // 
        groupBoxMergeHips.Controls.Add(buttonMergeHipsInfo);
        groupBoxMergeHips.Controls.Add(richTextBoxMergeHips);
        resources.ApplyResources(groupBoxMergeHips, "groupBoxMergeHips");
        groupBoxMergeHips.Name = "groupBoxMergeHips";
        groupBoxMergeHips.TabStop = false;
        // 
        // buttonMergeHipsInfo
        // 
        resources.ApplyResources(buttonMergeHipsInfo, "buttonMergeHipsInfo");
        buttonMergeHipsInfo.Name = "buttonMergeHipsInfo";
        buttonMergeHipsInfo.UseVisualStyleBackColor = true;
        buttonMergeHipsInfo.Click += buttonMergeHipsInfo_Click;
        // 
        // richTextBoxMergeHips
        // 
        resources.ApplyResources(richTextBoxMergeHips, "richTextBoxMergeHips");
        richTextBoxMergeHips.Name = "richTextBoxMergeHips";
        // 
        // groupBoxRemoveFiles
        // 
        groupBoxRemoveFiles.Controls.Add(buttonRemoveFilesInfo);
        groupBoxRemoveFiles.Controls.Add(richTextBoxRemoveFiles);
        resources.ApplyResources(groupBoxRemoveFiles, "groupBoxRemoveFiles");
        groupBoxRemoveFiles.Name = "groupBoxRemoveFiles";
        groupBoxRemoveFiles.TabStop = false;
        // 
        // buttonRemoveFilesInfo
        // 
        resources.ApplyResources(buttonRemoveFilesInfo, "buttonRemoveFilesInfo");
        buttonRemoveFilesInfo.Name = "buttonRemoveFilesInfo";
        buttonRemoveFilesInfo.UseVisualStyleBackColor = true;
        buttonRemoveFilesInfo.Click += buttonRemoveFilesInfo_Click;
        // 
        // richTextBoxRemoveFiles
        // 
        resources.ApplyResources(richTextBoxRemoveFiles, "richTextBoxRemoveFiles");
        richTextBoxRemoveFiles.Name = "richTextBoxRemoveFiles";
        // 
        // groupBoxDolPatches
        // 
        groupBoxDolPatches.Controls.Add(buttonDolPatchesInfo);
        groupBoxDolPatches.Controls.Add(richTextBoxDolPatches);
        resources.ApplyResources(groupBoxDolPatches, "groupBoxDolPatches");
        groupBoxDolPatches.Name = "groupBoxDolPatches";
        groupBoxDolPatches.TabStop = false;
        // 
        // buttonDolPatchesInfo
        // 
        resources.ApplyResources(buttonDolPatchesInfo, "buttonDolPatchesInfo");
        buttonDolPatchesInfo.Name = "buttonDolPatchesInfo";
        buttonDolPatchesInfo.UseVisualStyleBackColor = true;
        buttonDolPatchesInfo.Click += buttonDolPatchesInfo_Click;
        // 
        // richTextBoxDolPatches
        // 
        resources.ApplyResources(richTextBoxDolPatches, "richTextBoxDolPatches");
        richTextBoxDolPatches.Name = "richTextBoxDolPatches";
        richTextBoxDolPatches.TextChanged += richTextBoxDolPatches_TextChanged;
        // 
        // groupBoxArCodes
        // 
        groupBoxArCodes.Controls.Add(buttonArCodesInfo);
        groupBoxArCodes.Controls.Add(richTextBoxArCodes);
        resources.ApplyResources(groupBoxArCodes, "groupBoxArCodes");
        groupBoxArCodes.Name = "groupBoxArCodes";
        groupBoxArCodes.TabStop = false;
        // 
        // buttonArCodesInfo
        // 
        resources.ApplyResources(buttonArCodesInfo, "buttonArCodesInfo");
        buttonArCodesInfo.Name = "buttonArCodesInfo";
        buttonArCodesInfo.UseVisualStyleBackColor = true;
        buttonArCodesInfo.Click += buttonArCodesInfo_Click;
        // 
        // richTextBoxArCodes
        // 
        resources.ApplyResources(richTextBoxArCodes, "richTextBoxArCodes");
        richTextBoxArCodes.Name = "richTextBoxArCodes";
        richTextBoxArCodes.TextChanged += richTextBoxArCodes_TextChanged;
        // 
        // groupBoxGeckoCodes
        // 
        groupBoxGeckoCodes.Controls.Add(buttonGeckoCodesInfo);
        groupBoxGeckoCodes.Controls.Add(richTextBoxGeckoCodes);
        resources.ApplyResources(groupBoxGeckoCodes, "groupBoxGeckoCodes");
        groupBoxGeckoCodes.Name = "groupBoxGeckoCodes";
        groupBoxGeckoCodes.TabStop = false;
        // 
        // buttonGeckoCodesInfo
        // 
        resources.ApplyResources(buttonGeckoCodesInfo, "buttonGeckoCodesInfo");
        buttonGeckoCodesInfo.Name = "buttonGeckoCodesInfo";
        buttonGeckoCodesInfo.UseVisualStyleBackColor = true;
        buttonGeckoCodesInfo.Click += buttonGeckoCodesInfo_Click;
        // 
        // richTextBoxGeckoCodes
        // 
        resources.ApplyResources(richTextBoxGeckoCodes, "richTextBoxGeckoCodes");
        richTextBoxGeckoCodes.Name = "richTextBoxGeckoCodes";
        richTextBoxGeckoCodes.TextChanged += richTextBoxGeckoCodes_TextChanged;
        // 
        // groupBoxIpsPatch
        // 
        groupBoxIpsPatch.Controls.Add(buttonOpenIpsFile);
        groupBoxIpsPatch.Controls.Add(textBoxIpsPatch);
        resources.ApplyResources(groupBoxIpsPatch, "groupBoxIpsPatch");
        groupBoxIpsPatch.Name = "groupBoxIpsPatch";
        groupBoxIpsPatch.TabStop = false;
        // 
        // textBoxIpsPatch
        // 
        resources.ApplyResources(textBoxIpsPatch, "textBoxIpsPatch");
        textBoxIpsPatch.Name = "textBoxIpsPatch";
        // 
        // buttonOpenIpsFile
        // 
        resources.ApplyResources(buttonOpenIpsFile, "buttonOpenIpsFile");
        buttonOpenIpsFile.Name = "buttonOpenIpsFile";
        buttonOpenIpsFile.UseVisualStyleBackColor = true;
        buttonOpenIpsFile.Click += buttonOpenIpsFile_Click;
        // 
        // CreateMod
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        Controls.Add(tabControl1);
        Controls.Add(buttonCancel);
        Controls.Add(buttonCreateMod);
        Name = "CreateMod";
        ShowIcon = false;
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
        groupBoxIpsPatch.ResumeLayout(false);
        groupBoxIpsPatch.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
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
    private GroupBox groupBoxIpsPatch;
    private Button buttonOpenIpsFile;
    private TextBox textBoxIpsPatch;
}