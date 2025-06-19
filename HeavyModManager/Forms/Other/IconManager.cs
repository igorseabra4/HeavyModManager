namespace HeavyModManager.Forms.Other;

public enum HeavyModManagerIcon
{
    Red,
    Rainbow,
    Sock,
    ShinyObject
}

public static class IconManager
{
    public static HeavyModManagerIcon CurrentIcon;

    public static void SetIcon(Form form)
    {
        form.Icon = GetIcon();
    }

    public static void ChangeIcon()
    {
        CurrentIcon++;
        if (!System.Enum.IsDefined(typeof(HeavyModManagerIcon), CurrentIcon))
            CurrentIcon = 0;
    }

    public static Icon? GetIcon() => CurrentIcon switch
    {
        HeavyModManagerIcon.Red => GlobalResources.icon_small,
        HeavyModManagerIcon.Rainbow => GlobalResources.icon_rainbow_small,
        HeavyModManagerIcon.Sock => GlobalResources.sock,
        HeavyModManagerIcon.ShinyObject => GlobalResources.shiny_object,
        _ => null,
    };
}
