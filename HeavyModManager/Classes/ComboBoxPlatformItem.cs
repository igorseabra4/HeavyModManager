using HeavyModManager.Enum;
using HeavyModManager.Functions;

namespace HeavyModManager.Classes;

/// <summary>
/// Represents a Heavy Iron game as it appears in a combo box.
/// </summary>
public class ComboBoxPlatformItem
{

    /// <summary>
    /// Initializes a new instance of the <see cref="ComboBoxPlatformItem"/> class.
    /// </summary>
    /// <param name="game">The game</param>
    public ComboBoxPlatformItem(GamePlatform platform)
    {
        Platform = platform;
    }

    /// <summary>
    /// The game platform.
    /// </summary>
    public GamePlatform Platform { get; set; }

    /// <summary>
    /// Returns the long name of the game.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => ModManager.PlatformToStringFull(Platform);
}
