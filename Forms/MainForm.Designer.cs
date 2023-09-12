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
        groupBoxGame = new GroupBox();
        buttonCreateBackup = new Button();
        comboBoxGame = new ComboBox();
        groupBoxMods = new GroupBox();
        buttonRefreshModList = new Button();
        buttonMoveDown = new Button();
        buttonMoveUp = new Button();
        listMods = new CheckedListBox();
        buttonAddMod = new Button();
        buttonRunGame = new Button();
        buttonApplyMods = new Button();
        menuStrip1 = new MenuStrip();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        createModToolStripMenuItem = new ToolStripMenuItem();
        editModToolStripMenuItem = new ToolStripMenuItem();
        openModFolderToolStripMenuItem = new ToolStripMenuItem();
        zipModToolStripMenuItem = new ToolStripMenuItem();
        deleteModToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem1 = new ToolStripMenuItem();
        chooseDolphinPathToolStripMenuItem = new ToolStripMenuItem();
        developerModeToolStripMenuItem = new ToolStripMenuItem();
        checkForUpdatesOnStartupToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        labelModInfo = new Label();
        panelLabelModInfo = new Panel();
        groupBoxModInfo = new GroupBox();
        labelDolphin = new Label();
        groupBoxGame.SuspendLayout();
        groupBoxMods.SuspendLayout();
        menuStrip1.SuspendLayout();
        panelLabelModInfo.SuspendLayout();
        groupBoxModInfo.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxGame
        // 
        groupBoxGame.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxGame.Controls.Add(buttonCreateBackup);
        groupBoxGame.Controls.Add(comboBoxGame);
        groupBoxGame.Location = new Point(12, 27);
        groupBoxGame.Name = "groupBoxGame";
        groupBoxGame.Size = new Size(568, 51);
        groupBoxGame.TabIndex = 0;
        groupBoxGame.TabStop = false;
        groupBoxGame.Text = "Choose Game";
        // 
        // buttonCreateBackup
        // 
        buttonCreateBackup.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCreateBackup.Enabled = false;
        buttonCreateBackup.Location = new Point(452, 22);
        buttonCreateBackup.Name = "buttonCreateBackup";
        buttonCreateBackup.Size = new Size(110, 23);
        buttonCreateBackup.TabIndex = 2;
        buttonCreateBackup.Text = "Create Backup";
        buttonCreateBackup.UseVisualStyleBackColor = true;
        buttonCreateBackup.Click += buttonRestoreBackup_Click;
        // 
        // comboBoxGame
        // 
        comboBoxGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        comboBoxGame.FormattingEnabled = true;
        comboBoxGame.Location = new Point(6, 22);
        comboBoxGame.Name = "comboBoxGame";
        comboBoxGame.Size = new Size(440, 23);
        comboBoxGame.TabIndex = 1;
        comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
        // 
        // groupBoxMods
        // 
        groupBoxMods.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxMods.Controls.Add(buttonRefreshModList);
        groupBoxMods.Controls.Add(buttonMoveDown);
        groupBoxMods.Controls.Add(buttonMoveUp);
        groupBoxMods.Controls.Add(listMods);
        groupBoxMods.Controls.Add(buttonAddMod);
        groupBoxMods.Enabled = false;
        groupBoxMods.Location = new Point(12, 84);
        groupBoxMods.Name = "groupBoxMods";
        groupBoxMods.Size = new Size(322, 294);
        groupBoxMods.TabIndex = 2;
        groupBoxMods.TabStop = false;
        groupBoxMods.Text = "Mods";
        // 
        // buttonRefreshModList
        // 
        buttonRefreshModList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonRefreshModList.Location = new Point(66, 264);
        buttonRefreshModList.Name = "buttonRefreshModList";
        buttonRefreshModList.Size = new Size(96, 23);
        buttonRefreshModList.TabIndex = 4;
        buttonRefreshModList.Text = "Refresh Mods";
        buttonRefreshModList.UseVisualStyleBackColor = true;
        buttonRefreshModList.Click += buttonRefreshModList_Click;
        // 
        // buttonMoveDown
        // 
        buttonMoveDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonMoveDown.Location = new Point(36, 264);
        buttonMoveDown.Name = "buttonMoveDown";
        buttonMoveDown.Size = new Size(24, 24);
        buttonMoveDown.TabIndex = 3;
        buttonMoveDown.Text = "▼";
        buttonMoveDown.UseVisualStyleBackColor = true;
        buttonMoveDown.Click += buttonMoveDown_Click;
        // 
        // buttonMoveUp
        // 
        buttonMoveUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonMoveUp.Location = new Point(6, 264);
        buttonMoveUp.Name = "buttonMoveUp";
        buttonMoveUp.Size = new Size(24, 24);
        buttonMoveUp.TabIndex = 2;
        buttonMoveUp.Text = "▲";
        buttonMoveUp.UseVisualStyleBackColor = true;
        buttonMoveUp.Click += buttonMoveUp_Click;
        // 
        // listMods
        // 
        listMods.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listMods.FormattingEnabled = true;
        listMods.Location = new Point(6, 22);
        listMods.Name = "listMods";
        listMods.Size = new Size(310, 238);
        listMods.TabIndex = 1;
        listMods.ItemCheck += listMods_ItemCheck;
        listMods.SelectedIndexChanged += listMods_SelectedIndexChanged;
        listMods.KeyDown += listMods_KeyDown;
        // 
        // buttonAddMod
        // 
        buttonAddMod.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonAddMod.Location = new Point(236, 264);
        buttonAddMod.Name = "buttonAddMod";
        buttonAddMod.Size = new Size(80, 24);
        buttonAddMod.TabIndex = 5;
        buttonAddMod.Text = "Install Mod";
        buttonAddMod.UseVisualStyleBackColor = true;
        buttonAddMod.Click += buttonAddMod_Click;
        // 
        // buttonRunGame
        // 
        buttonRunGame.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonRunGame.Enabled = false;
        buttonRunGame.Location = new Point(435, 348);
        buttonRunGame.Name = "buttonRunGame";
        buttonRunGame.Size = new Size(145, 24);
        buttonRunGame.TabIndex = 5;
        buttonRunGame.Text = "Apply + Launch Game";
        buttonRunGame.UseVisualStyleBackColor = true;
        buttonRunGame.Click += buttonRunGame_Click;
        // 
        // buttonApplyMods
        // 
        buttonApplyMods.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonApplyMods.Enabled = false;
        buttonApplyMods.Location = new Point(340, 348);
        buttonApplyMods.Name = "buttonApplyMods";
        buttonApplyMods.Size = new Size(89, 23);
        buttonApplyMods.TabIndex = 4;
        buttonApplyMods.Text = "Apply Mods";
        buttonApplyMods.UseVisualStyleBackColor = true;
        buttonApplyMods.Click += buttonApplyMods_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.Dock = DockStyle.None;
        menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, settingsToolStripMenuItem1 });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(131, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createModToolStripMenuItem, editModToolStripMenuItem, openModFolderToolStripMenuItem, zipModToolStripMenuItem, deleteModToolStripMenuItem });
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(62, 20);
        settingsToolStripMenuItem.Text = "&Manage";
        // 
        // createModToolStripMenuItem
        // 
        createModToolStripMenuItem.Name = "createModToolStripMenuItem";
        createModToolStripMenuItem.Size = new Size(176, 22);
        createModToolStripMenuItem.Text = "&Create Mod...";
        createModToolStripMenuItem.Click += createModToolStripMenuItem_Click;
        // 
        // editModToolStripMenuItem
        // 
        editModToolStripMenuItem.Enabled = false;
        editModToolStripMenuItem.Name = "editModToolStripMenuItem";
        editModToolStripMenuItem.Size = new Size(176, 22);
        editModToolStripMenuItem.Text = "&Edit Mod...";
        editModToolStripMenuItem.Click += editModToolStripMenuItem_Click;
        // 
        // openModFolderToolStripMenuItem
        // 
        openModFolderToolStripMenuItem.Enabled = false;
        openModFolderToolStripMenuItem.Name = "openModFolderToolStripMenuItem";
        openModFolderToolStripMenuItem.Size = new Size(176, 22);
        openModFolderToolStripMenuItem.Text = "&Open Mod Folder...";
        openModFolderToolStripMenuItem.Click += openModFolderToolStripMenuItem_Click;
        // 
        // zipModToolStripMenuItem
        // 
        zipModToolStripMenuItem.Enabled = false;
        zipModToolStripMenuItem.Name = "zipModToolStripMenuItem";
        zipModToolStripMenuItem.Size = new Size(176, 22);
        zipModToolStripMenuItem.Text = "&Zip Mod...";
        zipModToolStripMenuItem.Click += zipModToolStripMenuItem_Click;
        // 
        // deleteModToolStripMenuItem
        // 
        deleteModToolStripMenuItem.Enabled = false;
        deleteModToolStripMenuItem.Name = "deleteModToolStripMenuItem";
        deleteModToolStripMenuItem.Size = new Size(176, 22);
        deleteModToolStripMenuItem.Text = "&Delete Mod...";
        deleteModToolStripMenuItem.Click += deleteModToolStripMenuItem_Click;
        // 
        // settingsToolStripMenuItem1
        // 
        settingsToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { chooseDolphinPathToolStripMenuItem, developerModeToolStripMenuItem, checkForUpdatesOnStartupToolStripMenuItem, toolStripSeparator2, aboutToolStripMenuItem });
        settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
        settingsToolStripMenuItem1.Size = new Size(61, 20);
        settingsToolStripMenuItem1.Text = "&Settings";
        // 
        // chooseDolphinPathToolStripMenuItem
        // 
        chooseDolphinPathToolStripMenuItem.Name = "chooseDolphinPathToolStripMenuItem";
        chooseDolphinPathToolStripMenuItem.Size = new Size(231, 22);
        chooseDolphinPathToolStripMenuItem.Text = "&Choose Dolphin Path...";
        chooseDolphinPathToolStripMenuItem.Click += chooseDolphinPathToolStripMenuItem_Click;
        // 
        // developerModeToolStripMenuItem
        // 
        developerModeToolStripMenuItem.Name = "developerModeToolStripMenuItem";
        developerModeToolStripMenuItem.Size = new Size(231, 22);
        developerModeToolStripMenuItem.Text = "&Developer Mode";
        developerModeToolStripMenuItem.Click += developerModeToolStripMenuItem_Click;
        // 
        // checkForUpdatesOnStartupToolStripMenuItem
        // 
        checkForUpdatesOnStartupToolStripMenuItem.Name = "checkForUpdatesOnStartupToolStripMenuItem";
        checkForUpdatesOnStartupToolStripMenuItem.Size = new Size(231, 22);
        checkForUpdatesOnStartupToolStripMenuItem.Text = "Check For &Updates on Startup";
        checkForUpdatesOnStartupToolStripMenuItem.Click += checkForUpdatesOnStartupToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(228, 6);
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(231, 22);
        aboutToolStripMenuItem.Text = "&About...";
        aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
        // 
        // labelModInfo
        // 
        labelModInfo.Location = new Point(0, 0);
        labelModInfo.Name = "labelModInfo";
        labelModInfo.Size = new Size(182, 168);
        labelModInfo.TabIndex = 8;
        labelModInfo.Text = "Mod Info";
        // 
        // panelLabelModInfo
        // 
        panelLabelModInfo.AutoScroll = true;
        panelLabelModInfo.Controls.Add(labelModInfo);
        panelLabelModInfo.Dock = DockStyle.Fill;
        panelLabelModInfo.Location = new Point(3, 19);
        panelLabelModInfo.Name = "panelLabelModInfo";
        panelLabelModInfo.Size = new Size(234, 236);
        panelLabelModInfo.TabIndex = 9;
        // 
        // groupBoxModInfo
        // 
        groupBoxModInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        groupBoxModInfo.Controls.Add(panelLabelModInfo);
        groupBoxModInfo.Location = new Point(340, 84);
        groupBoxModInfo.Name = "groupBoxModInfo";
        groupBoxModInfo.Size = new Size(240, 258);
        groupBoxModInfo.TabIndex = 3;
        groupBoxModInfo.TabStop = false;
        groupBoxModInfo.Text = "Mod Info";
        // 
        // labelDolphin
        // 
        labelDolphin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        labelDolphin.AutoSize = true;
        labelDolphin.Location = new Point(12, 381);
        labelDolphin.Name = "labelDolphin";
        labelDolphin.Size = new Size(80, 15);
        labelDolphin.TabIndex = 7;
        labelDolphin.Text = "Dolphin Label";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(592, 415);
        Controls.Add(labelDolphin);
        Controls.Add(groupBoxModInfo);
        Controls.Add(buttonApplyMods);
        Controls.Add(buttonRunGame);
        Controls.Add(groupBoxMods);
        Controls.Add(groupBoxGame);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        MaximizeBox = false;
        MinimumSize = new Size(540, 250);
        Name = "MainForm";
        ShowIcon = false;
        Text = "Heavy Mod Manager";
        FormClosing += MainForm_FormClosing;
        groupBoxGame.ResumeLayout(false);
        groupBoxMods.ResumeLayout(false);
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        panelLabelModInfo.ResumeLayout(false);
        groupBoxModInfo.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
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
    private ToolStripMenuItem openModFolderToolStripMenuItem;
}