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
            this.richTextBoxArCodes = new System.Windows.Forms.RichTextBox();
            this.richTextBoxGeckoCodes = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageModData = new System.Windows.Forms.TabPage();
            this.groupBoxUpdatedAt = new System.Windows.Forms.GroupBox();
            this.dateTimePickerUpdatedAt = new System.Windows.Forms.DateTimePicker();
            this.groupBoxCreatedAt = new System.Windows.Forms.GroupBox();
            this.dateTimePickerCreatedAt = new System.Windows.Forms.DateTimePicker();
            this.tabPageRemoveFiles = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxRemoveFiles = new System.Windows.Forms.RichTextBox();
            this.tabPageArCodes = new System.Windows.Forms.TabPage();
            this.tabPageGeckoCodes = new System.Windows.Forms.TabPage();
            this.groupBoxGame.SuspendLayout();
            this.groupBoxModName.SuspendLayout();
            this.groupBoxAuthor.SuspendLayout();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxModId.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageModData.SuspendLayout();
            this.groupBoxUpdatedAt.SuspendLayout();
            this.groupBoxCreatedAt.SuspendLayout();
            this.tabPageRemoveFiles.SuspendLayout();
            this.tabPageArCodes.SuspendLayout();
            this.tabPageGeckoCodes.SuspendLayout();
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
            // richTextBoxArCodes
            // 
            this.richTextBoxArCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxArCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxArCodes.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxArCodes.Name = "richTextBoxArCodes";
            this.richTextBoxArCodes.Size = new System.Drawing.Size(336, 449);
            this.richTextBoxArCodes.TabIndex = 0;
            this.richTextBoxArCodes.Text = "";
            // 
            // richTextBoxGeckoCodes
            // 
            this.richTextBoxGeckoCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxGeckoCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxGeckoCodes.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxGeckoCodes.Name = "richTextBoxGeckoCodes";
            this.richTextBoxGeckoCodes.Size = new System.Drawing.Size(342, 455);
            this.richTextBoxGeckoCodes.TabIndex = 1;
            this.richTextBoxGeckoCodes.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageModData);
            this.tabControl1.Controls.Add(this.tabPageRemoveFiles);
            this.tabControl1.Controls.Add(this.tabPageArCodes);
            this.tabControl1.Controls.Add(this.tabPageGeckoCodes);
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(350, 483);
            this.tabControl1.TabIndex = 8;
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
            this.dateTimePickerUpdatedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
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
            this.dateTimePickerCreatedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerCreatedAt.Location = new System.Drawing.Point(6, 22);
            this.dateTimePickerCreatedAt.Name = "dateTimePickerCreatedAt";
            this.dateTimePickerCreatedAt.Size = new System.Drawing.Size(316, 23);
            this.dateTimePickerCreatedAt.TabIndex = 7;
            // 
            // tabPageRemoveFiles
            // 
            this.tabPageRemoveFiles.Controls.Add(this.label1);
            this.tabPageRemoveFiles.Controls.Add(this.richTextBoxRemoveFiles);
            this.tabPageRemoveFiles.Location = new System.Drawing.Point(4, 24);
            this.tabPageRemoveFiles.Name = "tabPageRemoveFiles";
            this.tabPageRemoveFiles.Size = new System.Drawing.Size(342, 455);
            this.tabPageRemoveFiles.TabIndex = 3;
            this.tabPageRemoveFiles.Text = "Remove Files";
            this.tabPageRemoveFiles.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter the folders or files present in the original game which\r\nshould be deleted " +
    "from the mod, one per line.";
            // 
            // richTextBoxRemoveFiles
            // 
            this.richTextBoxRemoveFiles.Location = new System.Drawing.Point(0, 33);
            this.richTextBoxRemoveFiles.Name = "richTextBoxRemoveFiles";
            this.richTextBoxRemoveFiles.Size = new System.Drawing.Size(340, 419);
            this.richTextBoxRemoveFiles.TabIndex = 0;
            this.richTextBoxRemoveFiles.Text = "";
            // 
            // tabPageArCodes
            // 
            this.tabPageArCodes.Controls.Add(this.richTextBoxArCodes);
            this.tabPageArCodes.Location = new System.Drawing.Point(4, 24);
            this.tabPageArCodes.Name = "tabPageArCodes";
            this.tabPageArCodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArCodes.Size = new System.Drawing.Size(342, 455);
            this.tabPageArCodes.TabIndex = 1;
            this.tabPageArCodes.Text = "AR Codes";
            this.tabPageArCodes.UseVisualStyleBackColor = true;
            // 
            // tabPageGeckoCodes
            // 
            this.tabPageGeckoCodes.Controls.Add(this.richTextBoxGeckoCodes);
            this.tabPageGeckoCodes.Location = new System.Drawing.Point(4, 24);
            this.tabPageGeckoCodes.Name = "tabPageGeckoCodes";
            this.tabPageGeckoCodes.Size = new System.Drawing.Size(342, 455);
            this.tabPageGeckoCodes.TabIndex = 2;
            this.tabPageGeckoCodes.Text = "Gecko Codes";
            this.tabPageGeckoCodes.UseVisualStyleBackColor = true;
            // 
            // CreateMod
            // 
            this.AcceptButton = this.buttonCreateMod;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 527);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreateMod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateMod";
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
            this.tabPageRemoveFiles.ResumeLayout(false);
            this.tabPageRemoveFiles.PerformLayout();
            this.tabPageArCodes.ResumeLayout(false);
            this.tabPageGeckoCodes.ResumeLayout(false);
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