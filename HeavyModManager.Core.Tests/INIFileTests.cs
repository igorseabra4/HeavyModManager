using HeavyModManager.Core.Classes;
using Xunit;

namespace HeavyModManager.Core.Tests;

public class INIFileTests
{
    [Fact]
    public void TestINIParseAndReplace()
    {
        string baseIni = "boot_scene=HB01\nScenePlayerMapping=HB01 SB\nThresholdPointsRange=0100 0200";
        var ini1 = INIFile.FromContents(baseIni);

        Assert.Equal("HB01", ini1.Properties["boot_scene"]);
        Assert.Equal("SB", ini1.ScenePlayerMapping["HB01"]);
        Assert.Equal("0200", ini1.ThresholdPointsRange["0100"]);

        string patchIni = "boot_scene=HB02\nScenePlayerMapping=HB01 PT";
        var ini2 = INIFile.FromContents(patchIni);

        ini1.ReplaceWith(ini2);

        Assert.Equal("HB02", ini1.Properties["boot_scene"]);
        Assert.Equal("PT", ini1.ScenePlayerMapping["HB01"]);
    }
}
