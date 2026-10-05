using Avalonia.Controls;
using System.Threading.Tasks;

namespace HeavyModManager.Desktop.Views;

public partial class MessageDialog : Window
{
    private bool _result = false;

    public MessageDialog()
    {
        InitializeComponent();
        ButtonOk.Click += (s, e) =>
        {
            _result = true;
            Close();
        };
        ButtonCancel.Click += (s, e) =>
        {
            _result = false;
            Close();
        };
    }

    public static async Task ShowAsync(Window owner, string title, string message)
    {
        if (!Avalonia.Threading.Dispatcher.UIThread.CheckAccess())
        {
            await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => ShowAsync(owner, title, message));
            return;
        }

        var dlg = new MessageDialog
        {
            Title = title
        };
        dlg.TextBlockMessage.Text = message;
        await dlg.ShowDialog(owner);
    }

    public static async Task<bool> ShowConfirmAsync(Window owner, string title, string message, string okText = "Yes", string cancelText = "No")
    {
        if (!Avalonia.Threading.Dispatcher.UIThread.CheckAccess())
        {
            return await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => ShowConfirmAsync(owner, title, message, okText, cancelText));
        }

        var dlg = new MessageDialog
        {
            Title = title
        };
        dlg.TextBlockMessage.Text = message;
        dlg.ButtonCancel.IsVisible = true;
        dlg.ButtonCancel.Content = cancelText;
        dlg.ButtonOk.Content = okText;
        await dlg.ShowDialog(owner);
        return dlg._result;
    }
}
