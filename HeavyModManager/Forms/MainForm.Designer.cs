﻿namespace HeavyModManager;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
        buttonRunGameDev = new Button();
        buttonRestoreBackupDev = new Button();
        menuStrip1 = new MenuStrip();
        manageToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        chooseDolphinPathToolStripMenuItem = new ToolStripMenuItem();
        chooseDolphinUserFolderPathToolStripMenuItem = new ToolStripMenuItem();
        developerModeToolStripMenuItem = new ToolStripMenuItem();
        checkForUpdatesOnStartupToolStripMenuItem = new ToolStripMenuItem();
        checkForUpdatesNowToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        changeIconToolStripMenuItem = new ToolStripMenuItem();
        languageToolStripMenuItem = new ToolStripMenuItem();
        englishToolStripMenuItem = new ToolStripMenuItem();
        germanToolStripMenuItem = new ToolStripMenuItem();
        portugueseToolStripMenuItem = new ToolStripMenuItem();
        labelModInfo = new Label();
        panelLabelModInfo = new Panel();
        groupBoxModInfo = new GroupBox();
        labelDolphin = new Label();
        buttonRunGame = new Button();
        groupBoxGame.SuspendLayout();
        groupBoxMods.SuspendLayout();
        menuStrip1.SuspendLayout();
        panelLabelModInfo.SuspendLayout();
        groupBoxModInfo.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxGame
        // 
        resources.ApplyResources(groupBoxGame, "groupBoxGame");
        groupBoxGame.Controls.Add(buttonCreateBackup);
        groupBoxGame.Controls.Add(comboBoxGame);
        groupBoxGame.Name = "groupBoxGame";
        groupBoxGame.TabStop = false;
        // 
        // buttonCreateBackup
        // 
        resources.ApplyResources(buttonCreateBackup, "buttonCreateBackup");
        buttonCreateBackup.Name = "buttonCreateBackup";
        buttonCreateBackup.UseVisualStyleBackColor = true;
        buttonCreateBackup.Click += buttonRestoreBackup_Click;
        // 
        // comboBoxGame
        // 
        resources.ApplyResources(comboBoxGame, "comboBoxGame");
        comboBoxGame.FormattingEnabled = true;
        comboBoxGame.Name = "comboBoxGame";
        comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
        // 
        // groupBoxMods
        // 
        resources.ApplyResources(groupBoxMods, "groupBoxMods");
        groupBoxMods.Controls.Add(listViewMods);
        groupBoxMods.Controls.Add(buttonRefreshModList);
        groupBoxMods.Controls.Add(buttonMoveDown);
        groupBoxMods.Controls.Add(buttonMoveUp);
        groupBoxMods.Controls.Add(buttonAddMod);
        groupBoxMods.Name = "groupBoxMods";
        groupBoxMods.TabStop = false;
        // 
        // listViewMods
        // 
        listViewMods.AllowColumnReorder = true;
        resources.ApplyResources(listViewMods, "listViewMods");
        listViewMods.CheckBoxes = true;
        listViewMods.Columns.AddRange(new ColumnHeader[] { columnName, columnAuthor, columnCreatedDate, columnUpdatedDate });
        listViewMods.Name = "listViewMods";
        listViewMods.UseCompatibleStateImageBehavior = false;
        listViewMods.View = View.Details;
        listViewMods.ItemCheck += listViewMods_ItemCheck;
        listViewMods.SelectedIndexChanged += listViewMods_SelectedIndexChanged;
        listViewMods.KeyDown += listViewMods_KeyDown;
        listViewMods.MouseClick += listViewMods_MouseClick;
        // 
        // columnName
        // 
        resources.ApplyResources(columnName, "columnName");
        // 
        // columnAuthor
        // 
        resources.ApplyResources(columnAuthor, "columnAuthor");
        // 
        // columnCreatedDate
        // 
        resources.ApplyResources(columnCreatedDate, "columnCreatedDate");
        // 
        // columnUpdatedDate
        // 
        resources.ApplyResources(columnUpdatedDate, "columnUpdatedDate");
        // 
        // buttonRefreshModList
        // 
        resources.ApplyResources(buttonRefreshModList, "buttonRefreshModList");
        buttonRefreshModList.Name = "buttonRefreshModList";
        buttonRefreshModList.UseVisualStyleBackColor = true;
        buttonRefreshModList.Click += buttonRefreshModList_Click;
        // 
        // buttonMoveDown
        // 
        resources.ApplyResources(buttonMoveDown, "buttonMoveDown");
        buttonMoveDown.Name = "buttonMoveDown";
        buttonMoveDown.UseVisualStyleBackColor = true;
        buttonMoveDown.Click += buttonMoveDown_Click;
        // 
        // buttonMoveUp
        // 
        resources.ApplyResources(buttonMoveUp, "buttonMoveUp");
        buttonMoveUp.Name = "buttonMoveUp";
        buttonMoveUp.UseVisualStyleBackColor = true;
        buttonMoveUp.Click += buttonMoveUp_Click;
        // 
        // buttonAddMod
        // 
        resources.ApplyResources(buttonAddMod, "buttonAddMod");
        buttonAddMod.Name = "buttonAddMod";
        buttonAddMod.UseVisualStyleBackColor = true;
        buttonAddMod.Click += buttonAddMod_Click;
        // 
        // buttonRunGameDev
        // 
        resources.ApplyResources(buttonRunGameDev, "buttonRunGameDev");
        buttonRunGameDev.Name = "buttonRunGameDev";
        buttonRunGameDev.UseVisualStyleBackColor = true;
        buttonRunGameDev.Click += buttonRunGameDev_Click;
        // 
        // buttonRestoreBackupDev
        // 
        resources.ApplyResources(buttonRestoreBackupDev, "buttonRestoreBackupDev");
        buttonRestoreBackupDev.Name = "buttonRestoreBackupDev";
        buttonRestoreBackupDev.UseVisualStyleBackColor = true;
        buttonRestoreBackupDev.Click += buttonRestoreBackupDev_Click;
        // 
        // menuStrip1
        // 
        resources.ApplyResources(menuStrip1, "menuStrip1");
        menuStrip1.Items.AddRange(new ToolStripItem[] { manageToolStripMenuItem, settingsToolStripMenuItem });
        menuStrip1.Name = "menuStrip1";
        // 
        // manageToolStripMenuItem
        // 
        manageToolStripMenuItem.Name = "manageToolStripMenuItem";
        resources.ApplyResources(manageToolStripMenuItem, "manageToolStripMenuItem");
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chooseDolphinPathToolStripMenuItem, chooseDolphinUserFolderPathToolStripMenuItem, developerModeToolStripMenuItem, checkForUpdatesOnStartupToolStripMenuItem, checkForUpdatesNowToolStripMenuItem, toolStripSeparator2, aboutToolStripMenuItem, changeIconToolStripMenuItem, languageToolStripMenuItem });
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
        // 
        // chooseDolphinPathToolStripMenuItem
        // 
        chooseDolphinPathToolStripMenuItem.Name = "chooseDolphinPathToolStripMenuItem";
        resources.ApplyResources(chooseDolphinPathToolStripMenuItem, "chooseDolphinPathToolStripMenuItem");
        chooseDolphinPathToolStripMenuItem.Click += chooseDolphinPathToolStripMenuItem_Click;
        // 
        // chooseDolphinUserFolderPathToolStripMenuItem
        // 
        chooseDolphinUserFolderPathToolStripMenuItem.Name = "chooseDolphinUserFolderPathToolStripMenuItem";
        resources.ApplyResources(chooseDolphinUserFolderPathToolStripMenuItem, "chooseDolphinUserFolderPathToolStripMenuItem");
        chooseDolphinUserFolderPathToolStripMenuItem.Click += chooseDolphinUserFolderPathToolStripMenuItem_Click;
        // 
        // developerModeToolStripMenuItem
        // 
        developerModeToolStripMenuItem.Name = "developerModeToolStripMenuItem";
        resources.ApplyResources(developerModeToolStripMenuItem, "developerModeToolStripMenuItem");
        developerModeToolStripMenuItem.Click += developerModeToolStripMenuItem_Click;
        // 
        // checkForUpdatesOnStartupToolStripMenuItem
        // 
        checkForUpdatesOnStartupToolStripMenuItem.Name = "checkForUpdatesOnStartupToolStripMenuItem";
        resources.ApplyResources(checkForUpdatesOnStartupToolStripMenuItem, "checkForUpdatesOnStartupToolStripMenuItem");
        checkForUpdatesOnStartupToolStripMenuItem.Click += checkForUpdatesOnStartupToolStripMenuItem_Click;
        // 
        // checkForUpdatesNowToolStripMenuItem
        // 
        checkForUpdatesNowToolStripMenuItem.Name = "checkForUpdatesNowToolStripMenuItem";
        resources.ApplyResources(checkForUpdatesNowToolStripMenuItem, "checkForUpdatesNowToolStripMenuItem");
        checkForUpdatesNowToolStripMenuItem.Click += checkForUpdatesNowToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        resources.ApplyResources(aboutToolStripMenuItem, "aboutToolStripMenuItem");
        aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
        // 
        // changeIconToolStripMenuItem
        // 
        changeIconToolStripMenuItem.Name = "changeIconToolStripMenuItem";
        resources.ApplyResources(changeIconToolStripMenuItem, "changeIconToolStripMenuItem");
        changeIconToolStripMenuItem.Click += changeIconToolStripMenuItem_Click;
        // 
        // languageToolStripMenuItem
        // 
        languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem, germanToolStripMenuItem, portugueseToolStripMenuItem });
        languageToolStripMenuItem.Name = "languageToolStripMenuItem";
        resources.ApplyResources(languageToolStripMenuItem, "languageToolStripMenuItem");
        // 
        // englishToolStripMenuItem
        // 
        englishToolStripMenuItem.Image = Properties.Resources.us;
        englishToolStripMenuItem.Name = "englishToolStripMenuItem";
        resources.ApplyResources(englishToolStripMenuItem, "englishToolStripMenuItem");
        englishToolStripMenuItem.Tag = "en";
        englishToolStripMenuItem.Click += changeLanguageToolStripMenuItem_Click;
        // 
        // germanToolStripMenuItem
        // 
        germanToolStripMenuItem.Image = Properties.Resources.de;
        germanToolStripMenuItem.Name = "germanToolStripMenuItem";
        resources.ApplyResources(germanToolStripMenuItem, "germanToolStripMenuItem");
        germanToolStripMenuItem.Tag = "de";
        germanToolStripMenuItem.Click += changeLanguageToolStripMenuItem_Click;
        // 
        // portugueseToolStripMenuItem
        // 
        resources.ApplyResources(portugueseToolStripMenuItem, "portugueseToolStripMenuItem");
        portugueseToolStripMenuItem.Name = "portugueseToolStripMenuItem";
        portugueseToolStripMenuItem.Tag = "pt";
        portugueseToolStripMenuItem.Click += changeLanguageToolStripMenuItem_Click;
        // 
        // labelModInfo
        // 
        resources.ApplyResources(labelModInfo, "labelModInfo");
        labelModInfo.Name = "labelModInfo";
        // 
        // panelLabelModInfo
        // 
        resources.ApplyResources(panelLabelModInfo, "panelLabelModInfo");
        panelLabelModInfo.Controls.Add(labelModInfo);
        panelLabelModInfo.Name = "panelLabelModInfo";
        // 
        // groupBoxModInfo
        // 
        resources.ApplyResources(groupBoxModInfo, "groupBoxModInfo");
        groupBoxModInfo.Controls.Add(panelLabelModInfo);
        groupBoxModInfo.Name = "groupBoxModInfo";
        groupBoxModInfo.TabStop = false;
        // 
        // labelDolphin
        // 
        resources.ApplyResources(labelDolphin, "labelDolphin");
        labelDolphin.Name = "labelDolphin";
        // 
        // buttonRunGame
        // 
        resources.ApplyResources(buttonRunGame, "buttonRunGame");
        buttonRunGame.Name = "buttonRunGame";
        buttonRunGame.UseVisualStyleBackColor = true;
        buttonRunGame.Click += buttonRunGame_Click;
        // 
        // MainForm
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(labelDolphin);
        Controls.Add(groupBoxModInfo);
        Controls.Add(buttonRestoreBackupDev);
        Controls.Add(buttonRunGameDev);
        Controls.Add(groupBoxMods);
        Controls.Add(groupBoxGame);
        Controls.Add(menuStrip1);
        Controls.Add(buttonRunGame);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
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
    private Button buttonRunGameDev;
    private Button buttonRestoreBackupDev;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem manageToolStripMenuItem;
    private Button buttonMoveDown;
    private Button buttonMoveUp;
    private Label labelModInfo;
    private Panel panelLabelModInfo;
    private Button buttonCreateBackup;
    private GroupBox groupBoxModInfo;
    private Label labelDolphin;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripMenuItem chooseDolphinPathToolStripMenuItem;
    private ToolStripMenuItem developerModeToolStripMenuItem;
    private ToolStripMenuItem checkForUpdatesOnStartupToolStripMenuItem;
    private Button buttonRefreshModList;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem changeIconToolStripMenuItem;
    private ListView listViewMods;
    private ColumnHeader columnName;
    private ColumnHeader columnAuthor;
    private ColumnHeader columnCreatedDate;
    private ColumnHeader columnUpdatedDate;
    private ToolStripMenuItem chooseDolphinUserFolderPathToolStripMenuItem;
    private ToolStripMenuItem languageToolStripMenuItem;
    private ToolStripMenuItem englishToolStripMenuItem;
    private ToolStripMenuItem germanToolStripMenuItem;
    private Button buttonRunGame;
    private ToolStripMenuItem portugueseToolStripMenuItem;
    private ToolStripMenuItem checkForUpdatesNowToolStripMenuItem;
}