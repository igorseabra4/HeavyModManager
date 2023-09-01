namespace HeavyModManager;

partial class MainForm
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
            this.buttonCreateBackup = new System.Windows.Forms.Button();
            this.comboBoxGame = new System.Windows.Forms.ComboBox();
            this.groupBoxMods = new System.Windows.Forms.GroupBox();
            this.buttonRefreshModList = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.listMods = new System.Windows.Forms.CheckedListBox();
            this.buttonAddMod = new System.Windows.Forms.Button();
            this.buttonRunGame = new System.Windows.Forms.Button();
            this.buttonApplyMods = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zipModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseDolphinPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelModInfo = new System.Windows.Forms.Label();
            this.panelLabelModInfo = new System.Windows.Forms.Panel();
            this.groupBoxModInfo = new System.Windows.Forms.GroupBox();
            this.labelDolphin = new System.Windows.Forms.Label();
            this.groupBoxGame.SuspendLayout();
            this.groupBoxMods.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelLabelModInfo.SuspendLayout();
            this.groupBoxModInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGame
            // 
            this.groupBoxGame.Controls.Add(this.buttonCreateBackup);
            this.groupBoxGame.Controls.Add(this.comboBoxGame);
            this.groupBoxGame.Location = new System.Drawing.Point(12, 27);
            this.groupBoxGame.Name = "groupBoxGame";
            this.groupBoxGame.Size = new System.Drawing.Size(568, 51);
            this.groupBoxGame.TabIndex = 0;
            this.groupBoxGame.TabStop = false;
            this.groupBoxGame.Text = "Choose Game";
            // 
            // buttonCreateBackup
            // 
            this.buttonCreateBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateBackup.Enabled = false;
            this.buttonCreateBackup.Location = new System.Drawing.Point(452, 22);
            this.buttonCreateBackup.Name = "buttonCreateBackup";
            this.buttonCreateBackup.Size = new System.Drawing.Size(110, 23);
            this.buttonCreateBackup.TabIndex = 10;
            this.buttonCreateBackup.Text = "Create Backup";
            this.buttonCreateBackup.UseVisualStyleBackColor = true;
            this.buttonCreateBackup.Click += new System.EventHandler(this.buttonRestoreBackup_Click);
            // 
            // comboBoxGame
            // 
            this.comboBoxGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGame.FormattingEnabled = true;
            this.comboBoxGame.Location = new System.Drawing.Point(6, 22);
            this.comboBoxGame.Name = "comboBoxGame";
            this.comboBoxGame.Size = new System.Drawing.Size(440, 23);
            this.comboBoxGame.TabIndex = 1;
            this.comboBoxGame.SelectedIndexChanged += new System.EventHandler(this.comboBoxGame_SelectedIndexChanged);
            // 
            // groupBoxMods
            // 
            this.groupBoxMods.Controls.Add(this.buttonRefreshModList);
            this.groupBoxMods.Controls.Add(this.buttonMoveDown);
            this.groupBoxMods.Controls.Add(this.buttonMoveUp);
            this.groupBoxMods.Controls.Add(this.listMods);
            this.groupBoxMods.Controls.Add(this.buttonAddMod);
            this.groupBoxMods.Enabled = false;
            this.groupBoxMods.Location = new System.Drawing.Point(12, 84);
            this.groupBoxMods.Name = "groupBoxMods";
            this.groupBoxMods.Size = new System.Drawing.Size(322, 294);
            this.groupBoxMods.TabIndex = 2;
            this.groupBoxMods.TabStop = false;
            this.groupBoxMods.Text = "Mods";
            // 
            // buttonRefreshModList
            // 
            this.buttonRefreshModList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefreshModList.Location = new System.Drawing.Point(66, 264);
            this.buttonRefreshModList.Name = "buttonRefreshModList";
            this.buttonRefreshModList.Size = new System.Drawing.Size(96, 23);
            this.buttonRefreshModList.TabIndex = 9;
            this.buttonRefreshModList.Text = "Refresh Mods";
            this.buttonRefreshModList.UseVisualStyleBackColor = true;
            this.buttonRefreshModList.Click += new System.EventHandler(this.buttonRefreshModList_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveDown.Location = new System.Drawing.Point(36, 264);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveDown.TabIndex = 7;
            this.buttonMoveDown.Text = "▼";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveUp.Location = new System.Drawing.Point(6, 264);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveUp.TabIndex = 8;
            this.buttonMoveUp.Text = "▲";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // listMods
            // 
            this.listMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMods.FormattingEnabled = true;
            this.listMods.Location = new System.Drawing.Point(6, 22);
            this.listMods.Name = "listMods";
            this.listMods.Size = new System.Drawing.Size(310, 238);
            this.listMods.TabIndex = 6;
            this.listMods.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listMods_ItemCheck);
            this.listMods.SelectedIndexChanged += new System.EventHandler(this.listMods_SelectedIndexChanged);
            // 
            // buttonAddMod
            // 
            this.buttonAddMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddMod.Location = new System.Drawing.Point(236, 264);
            this.buttonAddMod.Name = "buttonAddMod";
            this.buttonAddMod.Size = new System.Drawing.Size(80, 24);
            this.buttonAddMod.TabIndex = 4;
            this.buttonAddMod.Text = "Install Mod";
            this.buttonAddMod.UseVisualStyleBackColor = true;
            this.buttonAddMod.Click += new System.EventHandler(this.buttonAddMod_Click);
            // 
            // buttonRunGame
            // 
            this.buttonRunGame.Enabled = false;
            this.buttonRunGame.Location = new System.Drawing.Point(435, 348);
            this.buttonRunGame.Name = "buttonRunGame";
            this.buttonRunGame.Size = new System.Drawing.Size(145, 24);
            this.buttonRunGame.TabIndex = 5;
            this.buttonRunGame.Text = "Apply + Launch Game";
            this.buttonRunGame.UseVisualStyleBackColor = true;
            this.buttonRunGame.Click += new System.EventHandler(this.buttonRunGame_Click);
            // 
            // buttonApplyMods
            // 
            this.buttonApplyMods.Enabled = false;
            this.buttonApplyMods.Location = new System.Drawing.Point(340, 348);
            this.buttonApplyMods.Name = "buttonApplyMods";
            this.buttonApplyMods.Size = new System.Drawing.Size(89, 23);
            this.buttonApplyMods.TabIndex = 6;
            this.buttonApplyMods.Text = "Apply Mods";
            this.buttonApplyMods.UseVisualStyleBackColor = true;
            this.buttonApplyMods.Click += new System.EventHandler(this.buttonApplyMods_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.settingsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createModToolStripMenuItem,
            this.editModToolStripMenuItem,
            this.zipModToolStripMenuItem,
            this.deleteModToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.settingsToolStripMenuItem.Text = "Manage";
            // 
            // createModToolStripMenuItem
            // 
            this.createModToolStripMenuItem.Name = "createModToolStripMenuItem";
            this.createModToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.createModToolStripMenuItem.Text = "Create Mod...";
            this.createModToolStripMenuItem.Click += new System.EventHandler(this.createModToolStripMenuItem_Click);
            // 
            // editModToolStripMenuItem
            // 
            this.editModToolStripMenuItem.Enabled = false;
            this.editModToolStripMenuItem.Name = "editModToolStripMenuItem";
            this.editModToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.editModToolStripMenuItem.Text = "Edit Mod...";
            this.editModToolStripMenuItem.Click += new System.EventHandler(this.editModToolStripMenuItem_Click);
            // 
            // zipModToolStripMenuItem
            // 
            this.zipModToolStripMenuItem.Enabled = false;
            this.zipModToolStripMenuItem.Name = "zipModToolStripMenuItem";
            this.zipModToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.zipModToolStripMenuItem.Text = "Zip Mod...";
            this.zipModToolStripMenuItem.Click += new System.EventHandler(this.zipModToolStripMenuItem_Click);
            // 
            // deleteModToolStripMenuItem
            // 
            this.deleteModToolStripMenuItem.Enabled = false;
            this.deleteModToolStripMenuItem.Name = "deleteModToolStripMenuItem";
            this.deleteModToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.deleteModToolStripMenuItem.Text = "Delete Mod...";
            this.deleteModToolStripMenuItem.Click += new System.EventHandler(this.deleteModToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseDolphinPathToolStripMenuItem,
            this.developerModeToolStripMenuItem,
            this.checkForUpdatesOnStartupToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem1.Text = "Settings";
            // 
            // chooseDolphinPathToolStripMenuItem
            // 
            this.chooseDolphinPathToolStripMenuItem.Name = "chooseDolphinPathToolStripMenuItem";
            this.chooseDolphinPathToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.chooseDolphinPathToolStripMenuItem.Text = "Choose Dolphin Path...";
            this.chooseDolphinPathToolStripMenuItem.Click += new System.EventHandler(this.chooseDolphinPathToolStripMenuItem_Click);
            // 
            // developerModeToolStripMenuItem
            // 
            this.developerModeToolStripMenuItem.Name = "developerModeToolStripMenuItem";
            this.developerModeToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.developerModeToolStripMenuItem.Text = "Developer Mode";
            this.developerModeToolStripMenuItem.Click += new System.EventHandler(this.developerModeToolStripMenuItem_Click);
            // 
            // checkForUpdatesOnStartupToolStripMenuItem
            // 
            this.checkForUpdatesOnStartupToolStripMenuItem.Name = "checkForUpdatesOnStartupToolStripMenuItem";
            this.checkForUpdatesOnStartupToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.checkForUpdatesOnStartupToolStripMenuItem.Text = "Check For Updates on Startup";
            this.checkForUpdatesOnStartupToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesOnStartupToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(228, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // labelModInfo
            // 
            this.labelModInfo.Location = new System.Drawing.Point(0, 0);
            this.labelModInfo.Name = "labelModInfo";
            this.labelModInfo.Size = new System.Drawing.Size(182, 168);
            this.labelModInfo.TabIndex = 8;
            this.labelModInfo.Text = "Mod Info";
            // 
            // panelLabelModInfo
            // 
            this.panelLabelModInfo.AutoScroll = true;
            this.panelLabelModInfo.Controls.Add(this.labelModInfo);
            this.panelLabelModInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLabelModInfo.Location = new System.Drawing.Point(3, 19);
            this.panelLabelModInfo.Name = "panelLabelModInfo";
            this.panelLabelModInfo.Size = new System.Drawing.Size(234, 236);
            this.panelLabelModInfo.TabIndex = 9;
            // 
            // groupBoxModInfo
            // 
            this.groupBoxModInfo.Controls.Add(this.panelLabelModInfo);
            this.groupBoxModInfo.Location = new System.Drawing.Point(340, 84);
            this.groupBoxModInfo.Name = "groupBoxModInfo";
            this.groupBoxModInfo.Size = new System.Drawing.Size(240, 258);
            this.groupBoxModInfo.TabIndex = 10;
            this.groupBoxModInfo.TabStop = false;
            this.groupBoxModInfo.Text = "Mod Info";
            // 
            // labelDolphin
            // 
            this.labelDolphin.AutoSize = true;
            this.labelDolphin.Location = new System.Drawing.Point(12, 381);
            this.labelDolphin.Name = "labelDolphin";
            this.labelDolphin.Size = new System.Drawing.Size(80, 15);
            this.labelDolphin.TabIndex = 11;
            this.labelDolphin.Text = "Dolphin Label";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 415);
            this.Controls.Add(this.labelDolphin);
            this.Controls.Add(this.groupBoxModInfo);
            this.Controls.Add(this.buttonApplyMods);
            this.Controls.Add(this.buttonRunGame);
            this.Controls.Add(this.groupBoxMods);
            this.Controls.Add(this.groupBoxGame);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Heavy Mod Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBoxGame.ResumeLayout(false);
            this.groupBoxMods.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelLabelModInfo.ResumeLayout(false);
            this.groupBoxModInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private GroupBox groupBoxGame;
    private ComboBox comboBoxGame;
    private GroupBox groupBoxMods;
    private Button buttonAddMod;
    private Button buttonRunGame;
    private Button buttonApplyMods;
    private MenuStrip menuStrip1;
    private CheckedListBox listMods;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private Button buttonMoveDown;
    private Button buttonMoveUp;
    private Label labelModInfo;
    private Panel panelLabelModInfo;
    private Button buttonCreateBackup;
    private GroupBox groupBoxModInfo;
    private Label labelDolphin;
    private ToolStripMenuItem deleteModToolStripMenuItem;
    private ToolStripMenuItem createModToolStripMenuItem;
    private ToolStripMenuItem editModToolStripMenuItem;
    private ToolStripMenuItem zipModToolStripMenuItem;
    private ToolStripMenuItem settingsToolStripMenuItem1;
    private ToolStripMenuItem chooseDolphinPathToolStripMenuItem;
    private ToolStripMenuItem developerModeToolStripMenuItem;
    private ToolStripMenuItem checkForUpdatesOnStartupToolStripMenuItem;
    private Button buttonRefreshModList;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem aboutToolStripMenuItem;
}