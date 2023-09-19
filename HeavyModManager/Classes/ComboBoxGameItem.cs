using HeavyModManager.Enum;
using HeavyModManager.Functions;

namespace HeavyModManager.Classes;

/// <summary>
/// Represents a Heavy Iron game as it appears in a combo box.
/// </summary>
public class ComboBoxGameItem
{  

    /// <summary>
    /// Initializes a new instance of the <see cref="ComboBoxGameItem"/> class.
    /// </summary>
    /// <param name="game">The game</param>
    public ComboBoxGameItem(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// The Heavy Iron game.
    /// </summary>
    public Game Game { get; set; }

    /// <summary>
    /// Returns the long name of the game.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => ModManager.GameToStringFull(Game);
}