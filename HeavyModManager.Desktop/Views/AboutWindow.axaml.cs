using Avalonia.Controls;
using HeavyModManager.Core.Classes;
using HeavyModManager.Core.Platform;

namespace HeavyModManager.Desktop.Views;

public partial class AboutWindow : Window
{
    public AboutWindow()
    {
        InitializeComponent();

        var version = ModManagerVersion.GetCurrent().Version;
        TextBlockTitle.Text = $"Heavy Mod Manager {version}";

        ButtonGithub.Click += (s, e) => PlatformService.Instance.OpenUrl("https://github.com/igorseabra4/HeavyModManager");
        ButtonDiscord.Click += (s, e) => PlatformService.Instance.OpenUrl("https://discord.gg/9eAE6UB");
        ButtonWiki.Click += (s, e) => PlatformService.Instance.OpenUrl("https://heavyironmodding.org/wiki/Heavy_Mod_Manager");
        ButtonClose.Click += (s, e) => Close();
    }
}
