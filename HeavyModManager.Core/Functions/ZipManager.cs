using HeavyModManager.Core.Classes;
using HeavyModManager.Core.Services;
using System.IO.Compression;
using System.Text;
using System.Text.Json;

namespace HeavyModManager.Core.Functions;

/// <summary>
/// Class for managing ZIP files containing mods.
/// </summary>
public static class ZipManager
{
    public static async Task<bool> InstallModAsync(string fileName, IDialogService? dialogService = null)
    {
        try
        {
            using var file = File.OpenRead(fileName);
            using var zip = new ZipArchive(file, ZipArchiveMode.Read);
            var zMod = zip.GetEntry("mod.json");

            if (zMod == null)
            {
                if (dialogService != null)
                {
                    await dialogService.ShowErrorAsync("Error adding mod",
                        $"Could not find mod.json on zip root of {Path.GetFileName(fileName)}. Are you sure this is a compatible mod?");
                }
                return false;
            }

            using var zModStream = zMod.Open();
            using StreamReader reader = new(zModStream, Encoding.UTF8);
            var zModString = await reader.ReadToEndAsync();

            var mod = JsonSerializer.Deserialize<Mod>(zModString);
            if (mod == null || string.IsNullOrWhiteSpace(mod.ModId))
            {
                if (dialogService != null)
                {
                    await dialogService.ShowErrorAsync("Error adding mod",
                        $"Could not read mod.json on {Path.GetFileName(fileName)}. Are you sure this is a compatible mod?");
                }
                return false;
            }

            var modPath = ModManager.GetModPath(mod.ModId);

            ModManager.DeleteMod(mod.ModId);
            Directory.CreateDirectory(modPath);

            foreach (var entry in zip.Entries)
            {
                if (entry.FullName.EndsWith('/') || entry.FullName.EndsWith('\\'))
                    continue;

                // Normalize entry path to current OS
                var relativePath = entry.FullName
                    .Replace('\\', Path.DirectorySeparatorChar)
                    .Replace('/', Path.DirectorySeparatorChar);

                var destinationPath = Path.Combine(modPath, relativePath);

                var destFolder = Path.GetDirectoryName(destinationPath);
                if (!string.IsNullOrEmpty(destFolder) && !Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                entry.ExtractToFile(destinationPath, true);
            }

            return true;
        }
        catch (Exception ex)
        {
            if (dialogService != null)
            {
                await dialogService.ShowErrorAsync("Error adding mod",
                    $"Failed to install {Path.GetFileName(fileName)}: {ex.Message}");
            }
            return false;
        }
    }

    public static void ZipMod(string modId, string destinationZipPath)
    {
        var modPath = ModManager.GetModPath(modId);

        if (!Directory.Exists(modPath))
            throw new DirectoryNotFoundException($"Unable to zip mod: mod '{modId}' not found at {modPath}");

        var dir = Path.GetDirectoryName(destinationZipPath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        if (File.Exists(destinationZipPath))
            File.Delete(destinationZipPath);

        using var zip = new ZipArchive(new FileStream(destinationZipPath, FileMode.Create), ZipArchiveMode.Create);

        string[] entries = Directory.GetFiles(modPath, "*", SearchOption.AllDirectories);

        foreach (var e in entries)
        {
            var relativePath = Path.GetRelativePath(modPath, e).Replace('\\', '/');
            zip.CreateEntryFromFile(e, relativePath);
        }
    }
}
