namespace HeavyModManager.Core.Services;

/// <summary>
/// Service interface for decoupling user dialogs from business logic.
/// </summary>
public interface IDialogService
{
    Task ShowInfoAsync(string title, string message);
    Task ShowErrorAsync(string title, string message);
    Task ShowWarningAsync(string title, string message);
    Task<bool> ShowConfirmAsync(string title, string message);
}

/// <summary>
/// Default headless/console dialog service when running without a GUI.
/// </summary>
public class NullDialogService : IDialogService
{
    public Task ShowInfoAsync(string title, string message)
    {
        Console.WriteLine($"[INFO] {title}: {message}");
        return Task.CompletedTask;
    }

    public Task ShowErrorAsync(string title, string message)
    {
        Console.Error.WriteLine($"[ERROR] {title}: {message}");
        return Task.CompletedTask;
    }

    public Task ShowWarningAsync(string title, string message)
    {
        Console.WriteLine($"[WARN] {title}: {message}");
        return Task.CompletedTask;
    }

    public Task<bool> ShowConfirmAsync(string title, string message)
    {
        Console.WriteLine($"[CONFIRM] {title}: {message} (Y/N)");
        return Task.FromResult(true);
    }
}
