namespace HeavyModManager.Core.Platform;

public interface IPlatformService
{
    bool IsMacOS { get; }
    bool IsWindows { get; }
    bool IsLinux { get; }

    string DefaultDolphinExecutablePath { get; }
    string DefaultDolphinFolderPath { get; }

    string GetDolphinSysPath(string dolphinPath);
    void LaunchDolphin(string dolphinPath, string gameDolPath);
    void CloseDolphin();

    void OpenFolder(string folderPath);
    void OpenFile(string filePath);
    void OpenUrl(string url);

    void CopyDirectory(string sourceDir, string destDir, bool overwrite = true);
    string NormalizePath(string path);
}
