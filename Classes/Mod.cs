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
    public Game Game { get; private set; }

    /// <summary>
    /// The name of the mod.
    /// </summary>
    [JsonInclude]
    public string ModName { get; private set; }

    /// <summary>
    /// The mod author.
    /// </summary>
    [JsonInclude]
    public string Author { get; private set; }

    /// <summary>
    /// The mod description.
    /// </summary>
    [JsonInclude]
    public string Description { get; private set; }

    /// <summary>
    /// The mod ID.
    /// <para>
    /// By default, this is generated from the game, mod name and author.
    /// </para>
    /// </summary>
    [JsonInclude]
    public string ModId { get; private set; }

    /// <summary>
    /// The Action Replay codes the mod uses, if any.
    /// </summary>
    [JsonInclude]
    public string ArCodes { get; private set; }

    /// <summary>
    /// The Gecko codes the mod uses, if any.
    /// </summary>
    [JsonInclude]
    public string GeckoCodes { get; private set; }

    /// <summary>
    /// Game files to remove when the mod is installed, if any.
    /// </summary>
    [JsonInclude]
    public string RemoveFiles { get; private set; }

    /// <summary>
    /// The date and time the mod was created.
    /// </summary>
    [JsonInclude]
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// The date and time the mod was last updated.
    /// </summary>
    [JsonInclude]
    public DateTime UpdatedAt { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Mod"/> class.
    /// </summary>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="Mod"/> class.
    /// </summary>
    /// <param name="game">The Heavy Iron game</param>
    /// <param name="modName">The name of the mod</param>
    /// <param name="author">The mod author</param>
    /// <param name="description">The mod description</param>
    /// <param name="modId">The mod ID</param>
    /// <param name="arCodes">The mod's Action Replay codes</param>
    /// <param name="geckoCodes">The mod's Gecko codes</param>
    /// <param name="removeFiles">Files to be removed</param>
    /// <param name="createdAt">The date and time the mod was created</param>
    /// <param name="updatedAt">The date and time the mod was last updated</param>
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
}