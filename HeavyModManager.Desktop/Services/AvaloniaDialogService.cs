using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using HeavyModManager.Core.Services;
using HeavyModManager.Desktop.Views;
using System.Threading.Tasks;

namespace HeavyModManager.Desktop.Services;

public class AvaloniaDialogService : IDialogService
{
    private Avalonia.Controls.Window? GetMainWindow()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            return desktop.MainWindow;
        }
        return null;
    }

    public async Task ShowInfoAsync(string title, string message)
    {
        await Dispatcher.UIThread.InvokeAsync(async () =>
        {
            var win = GetMainWindow();
            if (win != null)
                await MessageDialog.ShowAsync(win, title, message);
        });
    }

    public async Task ShowErrorAsync(string title, string message)
    {
        await Dispatcher.UIThread.InvokeAsync(async () =>
        {
            var win = GetMainWindow();
            if (win != null)
                await MessageDialog.ShowAsync(win, title, message);
        });
    }

    public async Task ShowWarningAsync(string title, string message)
    {
        await Dispatcher.UIThread.InvokeAsync(async () =>
        {
            var win = GetMainWindow();
            if (win != null)
                await MessageDialog.ShowAsync(win, title, message);
        });
    }

    public async Task<bool> ShowConfirmAsync(string title, string message)
    {
        return await Dispatcher.UIThread.InvokeAsync(async () =>
        {
            var win = GetMainWindow();
            if (win != null)
                return await MessageDialog.ShowConfirmAsync(win, title, message);
            return true;
        });
    }
}
