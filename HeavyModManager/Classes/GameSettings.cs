using System.Text.Json.Serialization;

namespace HeavyModManager.Classes;

public class GameSettings
{
    [JsonInclude]
    public List<string> Mods;
    [JsonInclude]
    public HashSet<string> ActiveMods;
    [JsonInclude]
    public bool Invalidated;

    [JsonConstructor]
    public GameSettings()
    {
        Mods = new List<string>();
        ActiveMods = new HashSet<string>();
        Invalidated = true;
    }

    public void AddMod(Mod mod)
    {
        if (!Mods.Contains(mod.ModId))
        {
            Mods.Add(mod.ModId);
            Invalidated = true;
        }
    }

    public void RemoveMod(string modId)
    {
        if (Mods.Contains(modId))
        {
            Mods.Remove(modId);
            ActiveMods.Remove(modId);
            Invalidated = true;
        }
    }

    public void ActivateMod(string modId)
    {
        ActiveMods.Add(modId);
        Invalidated = true;
    }

    public void DeactivateMod(string modId)
    {
        ActiveMods.Remove(modId);
        Invalidated = true;
    }
}