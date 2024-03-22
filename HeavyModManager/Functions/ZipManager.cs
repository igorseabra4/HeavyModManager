using HeavyModManager.Classes;
using System.IO.Compression;
using System.Text;
using System.Text.Json;

namespace HeavyModManager.Functions;

/// <summary>
/// Class for managing ZIP files containing mods.
/// </summary>
public static class ZipManager
{
    public static void InstallMod(string fileName)
    {
        using var file = File.OpenRead(fileName);
        using var zip = new ZipArchive(file, ZipArchiveMode.Read);
        var zMod = zip.GetEntry("mod.json");

        if (zMod == null)
        {
            // TODO: Localize!
            MessageBox.Show($"Could not find mod.json on zip root of {Path.GetFileName(fileName)}. Are you sure this is a compatible mod?",
                "Error adding mod", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        using var zModStream = zMod.Open();
        using StreamReader reader = new(zModStream, Encoding.UTF8);
        var zModString = reader.ReadToEnd();

        var mod = JsonSerializer.Deserialize<Mod>(zModString);
        if (mod == null)
        {
            // TODO: Localize!
            MessageBox.Show($"Could not read mod.json on {Path.GetFileName(fileName)}. Are you sure this is a compatible mod?",
                "Error adding mod", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var modPath = ModManager.GetModPath(mod.ModId);

        ModManager.DeleteMod(mod.ModId);
        Directory.CreateDirectory(modPath);

        foreach (var entry in zip.Entries)
        {
            // If the entry is a directory, FullName ends with '/'
            // Can skip directories since they are created below
            // - Pepperpot
            if (entry.FullName.EndsWith('/'))
                continue;

            var destinationPath = Path.Combine(modPath, entry.FullName);

            var destFolder = Path.GetDirectoryName(destinationPath);
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            entry.ExtractToFile(destinationPath, true);
        }
    }

    public static void ZipMod(string modId, string fileName)
    {
        var modPath = ModManager.GetModPath(modId);

        if (!Directory.Exists(modPath))
        {
            // TODO: Localize!
            MessageBox.Show("Unable to zip mod: mod not found.", "Error zipping mod",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // TODO: Localize!
        var saveFile = new SaveFileDialog()
        {
            Filter = "ZIP Archives|*.zip",
            Title = "Save a mod ZIP",
            FileName = fileName + ".zip",
        };

        if (saveFile.ShowDialog() == DialogResult.OK)
        {
            using var zip = new ZipArchive(new FileStream(saveFile.FileName, FileMode.Create), ZipArchiveMode.Create);

            string[] entries = Directory.GetFiles(modPath, "*", SearchOption.AllDirectories);

            foreach (var e in entries)
                zip.CreateEntryFromFile(e, Path.GetRelativePath(modPath, e));
        }
    }
}