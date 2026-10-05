using Avalonia;
using System;
using System.Threading;

namespace HeavyModManager.Desktop;

internal class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        bool createdNew;
        using var mutex = new Mutex(true, "HeavyModManager_Desktop_SingleInstance", out createdNew);
        if (!createdNew)
        {
            // Another instance is already running
            return;
        }

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
