using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HeavyModManager.Core.Platform;

public class PlatformService : IPlatformService
{
    private static IPlatformService? _instance;
    public static IPlatformService Instance => _instance ??= new PlatformService();

    public bool IsMacOS => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
    public bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    public bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    public string DefaultDolphinExecutablePath
    {
        get
        {
            if (IsMacOS)
            {
                string standardMacApp = "/Applications/Dolphin.app";
                if (Directory.Exists(standardMacApp))
                    return standardMacApp;

                string userMacApp = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Applications",
                    "Dolphin.app");
                if (Directory.Exists(userMacApp))
                    return userMacApp;

                return standardMacApp;
            }
            else if (IsWindows)
            {
                var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                return Path.Combine(programFiles, "Dolphin-x64", "Dolphin.exe");
            }
            else
            {
                return "/usr/bin/dolphin-emu";
            }
        }
    }

    public string DefaultDolphinFolderPath
    {
        get
        {
            if (IsMacOS)
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Library",
                    "Application Support",
                    "Dolphin");
            }
            else if (IsWindows)
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return Path.Combine(documents, "Dolphin Emulator");
            }
            else
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    ".local",
                    "share",
                    "dolphin-emu");
            }
        }
    }

    public string GetDolphinSysPath(string dolphinPath)
    {
        if (string.IsNullOrWhiteSpace(dolphinPath))
            return string.Empty;

        if (IsMacOS)
        {
            // If it's a .app bundle:
            if (dolphinPath.EndsWith(".app", StringComparison.OrdinalIgnoreCase) ||
                dolphinPath.EndsWith(".app/", StringComparison.OrdinalIgnoreCase))
            {
                string resourcesSys = Path.Combine(dolphinPath, "Contents", "Resources", "Sys");
                if (Directory.Exists(resourcesSys))
                    return resourcesSys;
            }

            // If pointing to the executable inside the bundle (Contents/MacOS/Dolphin)
            string? dir = Path.GetDirectoryName(dolphinPath);
            if (!string.IsNullOrEmpty(dir))
            {
                string bundleResourcesSys = Path.GetFullPath(Path.Combine(dir, "..", "Resources", "Sys"));
                if (Directory.Exists(bundleResourcesSys))
                    return bundleResourcesSys;

                string directSys = Path.Combine(dir, "Sys");
                if (Directory.Exists(directSys))
                    return directSys;
            }
        }

        string fallbackDir = Path.GetDirectoryName(dolphinPath) ?? string.Empty;
        return Path.Combine(fallbackDir, "Sys");
    }

    public void LaunchDolphin(string dolphinPath, string gameDolPath)
    {
        if (string.IsNullOrWhiteSpace(dolphinPath))
            throw new InvalidOperationException("Dolphin executable path is not set.");

        if (IsMacOS)
        {
            string executableToRun = dolphinPath;

            // If it's a macOS app bundle, locate the binary inside
            if (dolphinPath.EndsWith(".app", StringComparison.OrdinalIgnoreCase) ||
                dolphinPath.EndsWith(".app/", StringComparison.OrdinalIgnoreCase))
            {
                string macOsBinary = Path.Combine(dolphinPath, "Contents", "MacOS", "Dolphin");
                if (File.Exists(macOsBinary))
                {
                    executableToRun = macOsBinary;
                }
                else
                {
                    // Fallback to open -a
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "open",
                        Arguments = $"-a \"{dolphinPath}\" --args \"{gameDolPath}\"",
                        UseShellExecute = false
                    });
                    return;
                }
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = executableToRun,
                ArgumentList = { gameDolPath },
                UseShellExecute = false
            });
        }
        else
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = dolphinPath,
                ArgumentList = { gameDolPath },
                UseShellExecute = false
            });
        }
    }

    public void CloseDolphin()
    {
        string[] processNames = { "Dolphin", "dolphin-emu", "DolphinWx" };
        foreach (var name in processNames)
        {
            try
            {
                foreach (var p in Process.GetProcessesByName(name))
                {
                    if (!p.HasExited)
                    {
                        try { p.CloseMainWindow(); } catch { }
                    }
                }
            }
            catch
            {
                // Ignore process enumeration errors
            }
        }
    }

    public void OpenFolder(string folderPath)
    {
        if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            return;

        if (IsMacOS)
        {
            Process.Start("open", $"\"{folderPath}\"");
        }
        else if (IsWindows)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = folderPath,
                UseShellExecute = true
            });
        }
        else
        {
            Process.Start("xdg-open", $"\"{folderPath}\"");
        }
    }

    public void OpenFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            return;

        if (IsMacOS)
        {
            Process.Start("open", $"\"{filePath}\"");
        }
        else if (IsWindows)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }
        else
        {
            Process.Start("xdg-open", $"\"{filePath}\"");
        }
    }

    public void OpenUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return;

        if (IsMacOS)
        {
            Process.Start("open", url);
        }
        else if (IsWindows)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        else
        {
            Process.Start("xdg-open", url);
        }
    }

    public void CopyDirectory(string sourceDir, string destDir, bool overwrite = true)
    {
        var dir = new DirectoryInfo(sourceDir);
        if (!dir.Exists)
            throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

        Directory.CreateDirectory(destDir);

        foreach (FileInfo file in dir.GetFiles())
        {
            string targetFilePath = Path.Combine(destDir, file.Name);
            file.CopyTo(targetFilePath, overwrite);
        }

        foreach (DirectoryInfo subDir in dir.GetDirectories())
        {
            string newDestinationDir = Path.Combine(destDir, subDir.Name);
            CopyDirectory(subDir.FullName, newDestinationDir, overwrite);
        }
    }

    public string NormalizePath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return string.Empty;

        return path.Replace('\\', '/').Trim();
    }
}
