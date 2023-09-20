namespace HeavyModManager.Forms.Other
{
    public enum HeavyModManagerIcon
    {
        Red,
        Rainbow,
    }

    public static class IconManager
    {
        public static HeavyModManagerIcon CurrentIcon;

        public static void SetIcon(Form form)
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            form.Icon = (Icon)resources.GetObject(CurrentIcon == HeavyModManagerIcon.Red ? "icon_small" : "icon_rainbow_small");
        }

        public static void ChangeIcon()
        {
            CurrentIcon = CurrentIcon == HeavyModManagerIcon.Red ? HeavyModManagerIcon.Rainbow : HeavyModManagerIcon.Red;
        }
    }
}
