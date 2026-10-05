using HeavyModManager.Core.Classes;
using Xunit;

namespace HeavyModManager.Core.Tests;

public class IPSFileTests
{
    [Fact]
    public void TestIPSPatch()
    {
        // Construct valid IPS patch:
        // "PATCH" (5 bytes)
        // Offset: 0x000002 (3 bytes: 0x00, 0x00, 0x02)
        // Length: 2 bytes (0x00, 0x02)
        // Data: 0xEE, 0xFF (2 bytes)
        // "EOF" (0x45, 0x4F, 0x46)
        byte[] patchBytes = new byte[]
        {
            (byte)'P', (byte)'A', (byte)'T', (byte)'C', (byte)'H',
            0x00, 0x00, 0x02,
            0x00, 0x02,
            0xEE, 0xFF,
            0x45, 0x4F, 0x46
        };

        var ips = new IPSFile(patchBytes);
        Assert.Single(ips.Patches);
        Assert.Equal(2, ips.Patches[0].Offset);
        Assert.Equal(new byte[] { 0xEE, 0xFF }, ips.Patches[0].Data);

        byte[] targetDol = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04 };
        var mod = new Mod
        {
            IpsPatchBase64 = Convert.ToBase64String(patchBytes)
        };

        bool applied = mod.ApplyIPSPatch(ref targetDol);
        Assert.True(applied);
        Assert.Equal(0xEE, targetDol[2]);
        Assert.Equal(0xFF, targetDol[3]);
    }

    [Fact]
    public void TestInvalidIPSThrows()
    {
        byte[] invalidBytes = new byte[] { 1, 2, 3, 4, 5 };
        Assert.Throws<InvalidDataException>(() => new IPSFile(invalidBytes));
    }
}
