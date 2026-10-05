using Avalonia.Controls;
using Avalonia.Threading;
using System;

namespace HeavyModManager.Desktop.Views;

public partial class ProgressWindow : Window, IProgress<int>
{
    public ProgressWindow()
    {
        InitializeComponent();
    }

    public void SetStatus(string status)
    {
        Dispatcher.UIThread.Post(() =>
        {
            TextBlockStatus.Text = status;
        });
    }

    public void Report(int value)
    {
        Dispatcher.UIThread.Post(() =>
        {
            ProgressBarTask.Value = Math.Clamp(value, 0, 100);
            TextBlockPercent.Text = $"{value}%";
        });
    }

    public void SetIndeterminate(bool indeterminate)
    {
        Dispatcher.UIThread.Post(() =>
        {
            ProgressBarTask.IsIndeterminate = indeterminate;
            TextBlockPercent.Text = "";
        });
    }

    public new void Close()
    {
        if (Dispatcher.UIThread.CheckAccess())
            base.Close();
        else
            Dispatcher.UIThread.Post(base.Close);
    }
}
