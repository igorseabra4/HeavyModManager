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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        form.Icon = (Icon)resources.GetObject(GetIconName());
    }

    public static void ChangeIcon()
    {
        CurrentIcon++;
        if (!System.Enum.IsDefined(typeof(HeavyModManagerIcon), CurrentIcon))
            CurrentIcon = 0;
    }

    public static string GetIconName() => CurrentIcon switch
    {
        HeavyModManagerIcon.Red => "icon_small",
        HeavyModManagerIcon.Rainbow => "icon_rainbow_small",
        HeavyModManagerIcon.Sock => "sock",
        HeavyModManagerIcon.ShinyObject => "shiny_object",
        _ => "",
    };
}
