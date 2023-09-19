using HeavyModManager.Enum;
using HeavyModManager.Functions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

/// <summary>
/// Represents a mod for a Heavy Iron game.
/// </summary>
public class Mod
{
    /// <summary>
    /// The Heavy Iron game.
    /// </summary>
    [JsonInclude]
    public Game Game { get; set; } = Game.Null;

    /// <summary>
    /// The name of the mod.
    /// </summary>
    [JsonInclude]
    public string ModName { get; set; } = "";

    /// <summary>
    /// The mod author.
    /// </summary>
    [JsonInclude]
    public string Author { get; set; } = "";

    /// <summary>
    /// The mod description.
    /// </summary>
    [JsonInclude]
    public string Description { get; set; } = "";

    /// <summary>
    /// The mod ID.
    /// <para>
    /// By default, this is generated from the game, mod name and author.
    /// </para>
    /// </summary>
    [JsonInclude]
    public string ModId { get; set; } = "";

    [JsonInclude]
    public string GameId { get; set; } = "";

    [JsonInclude]
    public string INIReplacements { get; set; } = "";

    [JsonInclude]
    public string MergeFiles { get; set; } = "";

    /// <summary>
    /// Game files to remove when the mod is installed, if any.
    /// </summary>
    [JsonInclude]
    public string RemoveFiles { get; set; } = "";

    [JsonInclude]
    public string DOLPatches { get; set; } = "";

    /// <summary>
    /// The Action Replay codes the mod uses, if any.
    /// </summary>
    [JsonInclude]
    public string ArCodes { get; set; } = "";

    /// <summary>
    /// The Gecko codes the mod uses, if any.
    /// </summary>
    [JsonInclude]
    public string GeckoCodes { get; set; } = "";

    /// <summary>
    /// The date and time the mod was created.
    /// </summary>
    [JsonInclude]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date and time the mod was last updated.
    /// </summary>
    [JsonInclude]
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Mod"/> class.
    /// </summary>
    [JsonConstructor]
    public Mod()
    {
        CreatedAt = DateTime.Now.ToUniversalTime().Date;
        UpdatedAt = DateTime.Now.ToUniversalTime().Date;
    }

    /// <summary>
    /// Returns a string that represents the mod.
    /// </summary>
    /// <returns>The mod name</returns>
    public override string ToString()
    {
        return ModName;
    }

    /// <summary>
    /// Writes the mod to a JSON file.
    /// </summary>
    /// <param name="isEditing"></param>
    public void SaveModJson(bool isEditing)
    {
        // Temporary
        ArCodes = "";
        GeckoCodes = "";

        var modPath = ModManager.GetModPath(ModId);

        if (!Directory.Exists(modPath))
            Directory.CreateDirectory(modPath);

        var modJsonPath = ModManager.GetModJsonPath(ModId);
        File.WriteAllText(modJsonPath, JsonSerializer.Serialize(this));

        if (!isEditing)
        {
            var files = Path.Combine(modPath, "files");
            if (!Directory.Exists(files))
                Directory.CreateDirectory(files);

            MessageBox.Show("Mod created at " + modPath);
            System.Diagnostics.Process.Start("explorer.exe", modPath);
        }
    }

    public void Apply()
    {
        TempMergeFiles = MergeFiles.Split('\n').Select(p => p.ToLower());

        RemoveRemoveFiles();

        var modFilesPath = ModManager.GetModFilesPath(ModId);
        CopyDirectory(modFilesPath, modFilesPath);

        ApplyDolPatches();
    }

    private void RemoveRemoveFiles()
    {
        if (!string.IsNullOrWhiteSpace(RemoveFiles))
            foreach (var path in RemoveFiles.Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(path))
                    continue;

                var file = Path.Combine(ModManager.GameGameFilesPath, path);
                if (Directory.Exists(file))
                    Directory.Delete(file, true);
                else if (File.Exists(file))
                    File.Delete(file);
            }
    }

    [JsonIgnore]
    private IEnumerable<string> TempMergeFiles;

    private void CopyDirectory(string root, string path)
    {
        if (Directory.Exists(path))
        {
            foreach (var directory in Directory.GetDirectories(path))
                CopyDirectory(root, directory);

            foreach (var file in Directory.GetFiles(path))
            {
                var relativePath = Path.GetRelativePath(root, file);
                var destinationFilePath = Path.Combine(ModManager.GameGameFilesPath, relativePath);

                if (TempMergeFiles.Contains(relativePath.ToLower()))
                {
                    HipManager.MergeInto(file, destinationFilePath);
                }
                else
                {
                    File.Copy(file, destinationFilePath, true);
                }
            }
        }
    }

    private void ApplyDolPatches()
    {
        if (!string.IsNullOrWhiteSpace(DOLPatches))
        {
            var patches = DOLPatches
                .Split('\n')
                .Select(l => l.Split('#')[0].Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => l.Split(' '))
                .Select(vals => (Convert.ToUInt32(vals[0], 16), BitConverter.GetBytes(Convert.ToUInt32(vals[1], 16))))
                .ToArray();

            var dol = File.ReadAllBytes(ModManager.GameDolPath);

            foreach (var p in patches)
                for (int i = 0; i < 4; i++)
                    if (p.Item1 + i < dol.Length)
                        dol[p.Item1 + i] = p.Item2[i];

            File.WriteAllBytes(ModManager.GameDolPath, dol);
        }
    }
}