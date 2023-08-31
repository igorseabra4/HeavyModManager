using HeavyModManager.Enum;
using HeavyModManager.Functions;

namespace HeavyModManager.Classes;

public class ComboBoxGameItem
{
    private Game game;

    public ComboBoxGameItem(Game game)
    {
        this.game = game;
    }

    public Game Game => game;

    public override string ToString() => ModManager.GameToStringFull(game);
}