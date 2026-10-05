using HeavyModManager.Core.Platform;
using Xunit;

namespace HeavyModManager.Core.Tests;

public class PlatformServiceTests
{
    [Fact]
    public void TestPlatformDetection()
    {
        var platform = PlatformService.Instance;
        Assert.NotNull(platform);

        // On macOS:
        if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
        {
            Assert.True(platform.IsMacOS);
            Assert.False(platform.IsWindows);
            Assert.Contains("Dolphin", platform.DefaultDolphinExecutablePath);
            Assert.Contains("Library/Application Support/Dolphin", platform.DefaultDolphinFolderPath);

            // Test Sys path resolution
            string sysPath = platform.GetDolphinSysPath("/Applications/Dolphin.app");
            Assert.Equal("/Applications/Dolphin.app/Contents/Resources/Sys", sysPath);
        }
    }

    [Fact]
    public void TestNormalizePath()
    {
        var platform = PlatformService.Instance;
        string winPath = "files\\sb.ini";
        Assert.Equal("files/sb.ini", platform.NormalizePath(winPath));
    }
}
