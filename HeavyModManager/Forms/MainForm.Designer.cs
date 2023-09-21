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
        listViewMods = new ListView();
        columnName = new ColumnHeader();
        columnAuthor = new ColumnHeader();
        columnCreatedDate = new ColumnHeader();
        columnUpdatedDate = new ColumnHeader();
        buttonRefreshModList = new Button();
        buttonMoveDown = new Button();
        buttonMoveUp = new Button();
        buttonAddMod = new Button();
        buttonRunGame = new Button();
        buttonApplyMods = new Button();
        menuStrip1 = new MenuStrip();
        manageToolStripMenuItem = new ToolStripMenuItem();
        createModToolStripMenuItem = new ToolStripMenuItem();
        editModToolStripMenuItem = new ToolStripMenuItem();
        openModFolderToolStripMenuItem = new ToolStripMenuItem();
        zipModToolStripMenuItem = new ToolStripMenuItem();
        deleteModToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        chooseDolphinPathToolStripMenuItem = new ToolStripMenuItem();
        developerModeToolStripMenuItem = new ToolStripMenuItem();
        checkForUpdatesOnStartupToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        changeIconToolStripMenuItem = new ToolStripMenuItem();
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
        groupBoxGame.Size = new Size(698, 51);
        groupBoxGame.TabIndex = 1;
        groupBoxGame.TabStop = false;
        groupBoxGame.Text = "Choose Game";
        // 
        // buttonCreateBackup
        // 
        buttonCreateBackup.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCreateBackup.Enabled = false;
        buttonCreateBackup.Location = new Point(582, 22);
        buttonCreateBackup.Name = "buttonCreateBackup";
        buttonCreateBackup.Size = new Size(110, 23);
        buttonCreateBackup.TabIndex = 3;
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
        comboBoxGame.Size = new Size(570, 23);
        comboBoxGame.TabIndex = 2;
        comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
        // 
        // groupBoxMods
        // 
        groupBoxMods.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxMods.Controls.Add(listViewMods);
        groupBoxMods.Controls.Add(buttonRefreshModList);
        groupBoxMods.Controls.Add(buttonMoveDown);
        groupBoxMods.Controls.Add(buttonMoveUp);
        groupBoxMods.Controls.Add(buttonAddMod);
        groupBoxMods.Enabled = false;
        groupBoxMods.Location = new Point(12, 84);
        groupBoxMods.Name = "groupBoxMods";
        groupBoxMods.Size = new Size(452, 294);
        groupBoxMods.TabIndex = 4;
        groupBoxMods.TabStop = false;
        groupBoxMods.Text = "Mods";
        // 
        // listViewMods
        // 
        listViewMods.AllowColumnReorder = true;
        listViewMods.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listViewMods.CheckBoxes = true;
        listViewMods.Columns.AddRange(new ColumnHeader[] { columnName, columnAuthor, columnCreatedDate, columnUpdatedDate });
        listViewMods.Location = new Point(6, 22);
        listViewMods.Name = "listViewMods";
        listViewMods.Size = new Size(440, 238);
        listViewMods.TabIndex = 16;
        listViewMods.UseCompatibleStateImageBehavior = false;
        listViewMods.View = View.Details;
        listViewMods.ItemCheck += listViewMods_ItemCheck;
        listViewMods.SelectedIndexChanged += listViewMods_SelectedIndexChanged;
        listViewMods.KeyDown += listViewMods_KeyDown;
        // 
        // columnName
        // 
        columnName.Text = "Mod";
        columnName.Width = 212;
        // 
        // columnAuthor
        // 
        columnAuthor.Text = "Author";
        columnAuthor.Width = 84;
        // 
        // columnCreatedDate
        // 
        columnCreatedDate.Text = "Created";
        columnCreatedDate.Width = 70;
        // 
        // columnUpdatedDate
        // 
        columnUpdatedDate.Text = "Updated";
        columnUpdatedDate.Width = 70;
        // 
        // buttonRefreshModList
        // 
        buttonRefreshModList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonRefreshModList.Location = new Point(66, 264);
        buttonRefreshModList.Name = "buttonRefreshModList";
        buttonRefreshModList.Size = new Size(96, 23);
        buttonRefreshModList.TabIndex = 8;
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
        buttonMoveDown.TabIndex = 7;
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
        buttonMoveUp.TabIndex = 6;
        buttonMoveUp.Text = "▲";
        buttonMoveUp.UseVisualStyleBackColor = true;
        buttonMoveUp.Click += buttonMoveUp_Click;
        // 
        // buttonAddMod
        // 
        buttonAddMod.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonAddMod.Location = new Point(366, 264);
        buttonAddMod.Name = "buttonAddMod";
        buttonAddMod.Size = new Size(80, 24);
        buttonAddMod.TabIndex = 9;
        buttonAddMod.Text = "Install Mods";
        buttonAddMod.UseVisualStyleBackColor = true;
        buttonAddMod.Click += buttonAddMod_Click;
        // 
        // buttonRunGame
        // 
        buttonRunGame.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonRunGame.Enabled = false;
        buttonRunGame.Location = new Point(565, 348);
        buttonRunGame.Name = "buttonRunGame";
        buttonRunGame.Size = new Size(145, 24);
        buttonRunGame.TabIndex = 14;
        buttonRunGame.Text = "Apply + Launch Game";
        buttonRunGame.UseVisualStyleBackColor = true;
        buttonRunGame.Click += buttonRunGame_Click;
        // 
        // buttonApplyMods
        // 
        buttonApplyMods.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonApplyMods.Enabled = false;
        buttonApplyMods.Location = new Point(470, 348);
        buttonApplyMods.Name = "buttonApplyMods";
        buttonApplyMods.Size = new Size(89, 23);
        buttonApplyMods.TabIndex = 13;
        buttonApplyMods.Text = "Apply Mods";
        buttonApplyMods.UseVisualStyleBackColor = true;
        buttonApplyMods.Click += buttonApplyMods_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.Dock = DockStyle.None;
        menuStrip1.Items.AddRange(new ToolStripItem[] { manageToolStripMenuItem, settingsToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(131, 24);
        menuStrip1.TabIndex = 7;
        menuStrip1.Text = "menuStrip1";
        // 
        // manageToolStripMenuItem
        // 
        manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createModToolStripMenuItem, editModToolStripMenuItem, openModFolderToolStripMenuItem, zipModToolStripMenuItem, deleteModToolStripMenuItem });
        manageToolStripMenuItem.Name = "manageToolStripMenuItem";
        manageToolStripMenuItem.Size = new Size(62, 20);
        manageToolStripMenuItem.Text = "&Manage";
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
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chooseDolphinPathToolStripMenuItem, developerModeToolStripMenuItem, checkForUpdatesOnStartupToolStripMenuItem, toolStripSeparator2, aboutToolStripMenuItem, changeIconToolStripMenuItem });
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(61, 20);
        settingsToolStripMenuItem.Text = "Settings";
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
        checkForUpdatesOnStartupToolStripMenuItem.Text = "&Check For Updates on Startup";
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
        // changeIconToolStripMenuItem
        // 
        changeIconToolStripMenuItem.Name = "changeIconToolStripMenuItem";
        changeIconToolStripMenuItem.Size = new Size(231, 22);
        changeIconToolStripMenuItem.Text = "Change Icon";
        changeIconToolStripMenuItem.Click += changeIconToolStripMenuItem_Click;
        // 
        // labelModInfo
        // 
        labelModInfo.Location = new Point(0, 0);
        labelModInfo.Name = "labelModInfo";
        labelModInfo.Size = new Size(182, 168);
        labelModInfo.TabIndex = 12;
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
        panelLabelModInfo.TabIndex = 11;
        // 
        // groupBoxModInfo
        // 
        groupBoxModInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        groupBoxModInfo.Controls.Add(panelLabelModInfo);
        groupBoxModInfo.Location = new Point(470, 84);
        groupBoxModInfo.Name = "groupBoxModInfo";
        groupBoxModInfo.Size = new Size(240, 258);
        groupBoxModInfo.TabIndex = 10;
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
        labelDolphin.TabIndex = 15;
        labelDolphin.Text = "Dolphin Label";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(722, 435);
        Controls.Add(labelDolphin);
        Controls.Add(groupBoxModInfo);
        Controls.Add(buttonApplyMods);
        Controls.Add(buttonRunGame);
        Controls.Add(groupBoxMods);
        Controls.Add(groupBoxGame);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        MinimumSize = new Size(540, 250);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Heavy Mod Manager";
        FormClosing += MainForm_FormClosing;
        Shown += MainForm_Shown;
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
    private ToolStripMenuItem manageToolStripMenuItem;
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
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripMenuItem chooseDolphinPathToolStripMenuItem;
    private ToolStripMenuItem developerModeToolStripMenuItem;
    private ToolStripMenuItem checkForUpdatesOnStartupToolStripMenuItem;
    private Button buttonRefreshModList;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem openModFolderToolStripMenuItem;
    private ToolStripMenuItem changeIconToolStripMenuItem;
    private ListView listViewMods;
    private ColumnHeader columnName;
    private ColumnHeader columnAuthor;
    private ColumnHeader columnCreatedDate;
    private ColumnHeader columnUpdatedDate;
}