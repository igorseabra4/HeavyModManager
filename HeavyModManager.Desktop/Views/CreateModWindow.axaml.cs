using Avalonia.Controls;
using Avalonia.Platform.Storage;
using HeavyModManager.Core.Classes;
using HeavyModManager.Core.Enum;
using HeavyModManager.Core.Functions;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HeavyModManager.Desktop.Views;

public partial class CreateModWindow : Window
{
    private readonly bool _isEditing;
    private readonly Mod _mod;
    public Mod? ResultMod { get; private set; }

    public CreateModWindow() : this(null) { }

    public CreateModWindow(Mod? modToEdit)
    {
        InitializeComponent();

        _isEditing = modToEdit != null;
        _mod = modToEdit ?? new Mod();

        foreach (Game game in ModManager.EvilEngineGames)
        {
            ComboBoxTargetGame.Items.Add(new ComboBoxGameItem(game));
        }

        if (_isEditing)
        {
            Title = "Edit Mod";
            ButtonSave.Content = "Save Changes";

            for (int i = 0; i < ComboBoxTargetGame.Items.Count; i++)
            {
                if (ComboBoxTargetGame.Items[i] is ComboBoxGameItem item && item.Game == _mod.Game)
                {
                    ComboBoxTargetGame.SelectedIndex = i;
                    break;
                }
            }

            ComboBoxTargetGame.IsEnabled = false;
            TextBoxModId.IsEnabled = false;
            ButtonGenerateModId.IsEnabled = false;

            TextBoxModName.Text = _mod.ModName;
            TextBoxAuthor.Text = _mod.Author;
            TextBoxDescription.Text = _mod.Description;
            TextBoxModId.Text = _mod.ModId;

            TextBoxGameId.Text = _mod.GameId;
            TextBoxIniReplacements.Text = _mod.INIReplacements;
            TextBoxMergeFiles.Text = _mod.MergeFiles;
            TextBoxRemoveFiles.Text = _mod.RemoveFiles;
            TextBoxDolPatches.Text = _mod.DOLPatches;
            TextBoxArCodes.Text = _mod.ArCodes;
            TextBoxGeckoCodes.Text = _mod.GeckoCodes;
            if (!string.IsNullOrEmpty(_mod.IpsPatchBase64))
            {
                TextBoxIpsFile.Text = "[Embedded IPS Patch]";
            }
        }
        else
        {
            Title = "Create Mod";
            ButtonSave.Content = "Create Mod";

            if (ModManager.CurrentGame != Game.Null)
            {
                for (int i = 0; i < ComboBoxTargetGame.Items.Count; i++)
                {
                    if (ComboBoxTargetGame.Items[i] is ComboBoxGameItem item && item.Game == ModManager.CurrentGame)
                    {
                        ComboBoxTargetGame.SelectedIndex = i;
                        break;
                    }
                }
            }
            if (ComboBoxTargetGame.SelectedIndex < 0 && ComboBoxTargetGame.Items.Count > 0)
                ComboBoxTargetGame.SelectedIndex = 0;
        }

        ButtonGenerateModId.Click += (s, e) => GenerateModId();
        ButtonBrowseIps.Click += async (s, e) => await BrowseIpsFileAsync();
        ButtonCancel.Click += (s, e) => Close();
        ButtonSave.Click += async (s, e) => await SaveModAsync();
    }

    private void GenerateModId()
    {
        if (ComboBoxTargetGame.SelectedItem is not ComboBoxGameItem item)
            return;

        string gameStr = ModManager.GameToString(item.Game);
        string nameStr = Regex.Replace(TextBoxModName.Text ?? "", @"[^a-zA-Z0-9]", "_").ToLowerInvariant();
        string authorStr = Regex.Replace(TextBoxAuthor.Text ?? "", @"[^a-zA-Z0-9]", "_").ToLowerInvariant();

        TextBoxModId.Text = $"{gameStr}_{nameStr}_{authorStr}".Trim('_');
    }

    private async System.Threading.Tasks.Task BrowseIpsFileAsync()
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select IPS Patch File",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("IPS Patches") { Patterns = new[] { "*.ips" } },
                new FilePickerFileType("All Files") { Patterns = new[] { "*.*" } }
            }
        });

        if (files.Count > 0)
        {
            var localPath = files[0].Path.LocalPath;
            TextBoxIpsFile.Text = localPath;
            if (File.Exists(localPath))
            {
                _mod.IpsPatchBase64 = Convert.ToBase64String(await File.ReadAllBytesAsync(localPath));
            }
        }
    }

    private async System.Threading.Tasks.Task SaveModAsync()
    {
        if (string.IsNullOrWhiteSpace(TextBoxModName.Text))
        {
            await MessageDialog.ShowAsync(this, "Validation Error", "Please provide a name for the mod.");
            return;
        }

        if (string.IsNullOrWhiteSpace(TextBoxModId.Text))
        {
            GenerateModId();
            if (string.IsNullOrWhiteSpace(TextBoxModId.Text))
            {
                await MessageDialog.ShowAsync(this, "Validation Error", "Please enter a unique Mod ID.");
                return;
            }
        }

        if (ComboBoxTargetGame.SelectedItem is ComboBoxGameItem gameItem)
            _mod.Game = gameItem.Game;

        _mod.ModName = TextBoxModName.Text.Trim();
        _mod.Author = TextBoxAuthor.Text?.Trim() ?? "";
        _mod.Description = TextBoxDescription.Text ?? "";
        _mod.ModId = TextBoxModId.Text.Trim();

        _mod.GameId = TextBoxGameId.Text?.Trim() ?? "";
        _mod.INIReplacements = TextBoxIniReplacements.Text ?? "";
        _mod.MergeFiles = TextBoxMergeFiles.Text ?? "";
        _mod.RemoveFiles = TextBoxRemoveFiles.Text ?? "";
        _mod.DOLPatches = TextBoxDolPatches.Text ?? "";
        _mod.ArCodes = TextBoxArCodes.Text ?? "";
        _mod.GeckoCodes = TextBoxGeckoCodes.Text ?? "";
        _mod.UpdatedAt = DateTime.UtcNow.Date;

        try
        {
            _mod.SaveModJson(_isEditing);
            ResultMod = _mod;
            Close();
        }
        catch (Exception ex)
        {
            await MessageDialog.ShowAsync(this, "Error Saving Mod", $"Failed to save mod: {ex.Message}");
        }
    }
}
