using HeavyModManager.Core.Enum;
using HeavyModManager.Core.Functions;

namespace HeavyModManager.Core.Classes;

/// <summary>
/// Represents a Heavy Iron game as it appears in a combo box.
/// </summary>
public class ComboBoxGameItem
{  
    public ComboBoxGameItem(Game game)
    {
        Game = game;
    }

    public Game Game { get; set; }

    public override string ToString() => ModManager.GameToStringFull(Game);
}
