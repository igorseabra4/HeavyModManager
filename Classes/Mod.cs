using HeavyModManager.Enum;
using HeavyModManager.Functions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

public class Mod
{
    [JsonInclude]
    public Game Game { get; private set; }
    [JsonInclude]
    public string ModName { get; private set; }
    [JsonInclude]
    public string Author { get; private set; }
    [JsonInclude]
    public string Description { get; private set; }
    [JsonInclude]
    public string ModId { get; private set; }
    [JsonInclude]
    public string ArCodes { get; private set; }
    [JsonInclude]
    public string GeckoCodes { get; private set; }
    [JsonInclude]
    public string RemoveFiles { get; private set; }
    [JsonInclude]
    public DateTime CreatedAt { get; private set; }
    [JsonInclude]
    public DateTime UpdatedAt { get; private set; }

    [JsonConstructor]
    private Mod()
    {
        Game = Game.Null;
        ModName = "";
        Author = "";
        Description = "";
        ModId = "";
        ArCodes = "";
        GeckoCodes = "";
        RemoveFiles = "";
        CreatedAt = DateTime.Now.ToUniversalTime().Date;
        UpdatedAt = DateTime.Now.ToUniversalTime().Date;
    }

    public Mod(Game game, string modName, string author, string description, string modId, string arCodes, string geckoCodes, string removeFiles, DateTime createdAt, DateTime updatedAt)
    {
        Game = game;
        ModName = modName;
        Author = author;
        Description = description;
        ModId = modId;
        ArCodes = arCodes;
        GeckoCodes = geckoCodes;
        RemoveFiles = removeFiles;
        CreatedAt = createdAt.ToUniversalTime().Date;
        UpdatedAt = updatedAt.ToUniversalTime().Date;
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