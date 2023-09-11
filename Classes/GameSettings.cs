using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

/// <summary>
/// The settings for a Heavy Iron game.
/// </summary>
public class GameSettings
{
    /// <summary>
    /// The list of available mods for the game.
    /// </summary>
    [JsonInclude]
    public List<string> Mods { get; private set; }

    /// <summary>
    /// The list of active mods for the game.
    /// </summary>
    [JsonInclude]
    public HashSet<string> ActiveMods { get; private set; }

    /// <summary>
    /// Whether the game settings are invalidated.
    /// </summary>
    [JsonInclude]
    public bool Invalidated { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSettings"/> class.
    /// </summary>
    [JsonConstructor]
    public GameSettings()
    {
        Mods = new List<string>();
        ActiveMods = new HashSet<string>();
        Invalidated = true;
    }

    /// <summary>
    /// Adds a mod to the game.
    /// </summary>
    /// <param name="mod"></param>
    public void AddMod(Mod mod)
    {
        if (!Mods.Contains(mod.ModId))
        {
            Mods.Add(mod.ModId);
            Invalidated = true;
        }
    }

    /// <summary>
    /// Removes a mod from the game.
    /// </summary>
    /// <param name="modId">The ID of the mod to remove</param>
    public void RemoveMod(string modId)
    {
        if (Mods.Contains(modId))
        {
            Mods.Remove(modId);
            ActiveMods.Remove(modId);
            Invalidated = true;
        }
    }

    /// <summary>
    /// Activates a mod for the game.
    /// </summary>
    /// <param name="modId">The ID of the mod to activate</param>
    public void ActivateMod(string modId)
    {
        ActiveMods.Add(modId);
        Invalidated = true;
    }

    /// <summary>
    /// Deactives a mod for the game.
    /// </summary>
    /// <param name="modId">The ID of the mod to deactivate</param>
    public void DeactivateMod(string modId)
    {
        ActiveMods.Remove(modId);
        Invalidated = true;
    }
}