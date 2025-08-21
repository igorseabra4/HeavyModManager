using System.Runtime.InteropServices;

namespace HeavyModManager;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        static void BringExistingInstanceToFront(string windowTitle)
        {
            IntPtr hWnd = FindWindow(null, windowTitle);
            if (hWnd != IntPtr.Zero)
            {
                SetForegroundWindow(hWnd);
            }
        }

        bool createdNew;
        using (Mutex mutex = new Mutex(true, "HeavyModManager_SingleInstance", out createdNew))
        {
            if (!createdNew)
            {
                BringExistingInstanceToFront("Heavy Mod Manager");
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}