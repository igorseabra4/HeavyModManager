using HeavyModManager.Enum;
using HeavyModManager.Functions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

public class Mod
{
    [JsonInclude]
    public Game Game { get; set; } = Game.Null;
    [JsonInclude]
    public string ModName { get; set; } = "";
    [JsonInclude]
    public string Author { get; set; } = "";
    [JsonInclude]
    public string Description { get; set; } = "";
    [JsonInclude]
    public string ModId { get; set; } = "";
    [JsonInclude]
    public string GameId { get; set; } = "";
    [JsonInclude]
    public string INIReplacements { get; set; } = "";
    [JsonInclude]
    public string MergeFiles { get; set; } = "";
    [JsonInclude]
    public string RemoveFiles { get; set; } = "";
    [JsonInclude]
    public string DOLPatches { get; set; } = "";
    [JsonInclude]
    public string ArCodes { get; set; } = "";
    [JsonInclude]
    public string GeckoCodes { get; set; } = "";
    [JsonInclude]
    public DateTime CreatedAt { get; set; }
    [JsonInclude]
    public DateTime UpdatedAt { get; set; }

    [JsonConstructor]
    public Mod()
    {
        CreatedAt = DateTime.Now.ToUniversalTime().Date;
        UpdatedAt = DateTime.Now.ToUniversalTime().Date;
    }

    public override string ToString()
    {
        return ModName;
    }

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
}