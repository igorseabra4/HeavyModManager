﻿using NoCheese.Classes;
using System.IO.Compression;
using System.Text;
using System.Text.Json;

namespace NoCheese;

public static class ZipManager
{
    public static string TempUnzipPath => Path.Combine(Application.StartupPath, "temp", "unzip");

    public static void InstallMod(string fileName)
    {
        if (!Directory.Exists(TempUnzipPath))
            Directory.CreateDirectory(TempUnzipPath);

        using var file = File.OpenRead(fileName);
        using var zip = new ZipArchive(file, ZipArchiveMode.Read);
        var zMod = zip.GetEntry("mod.json");

        if (zMod == null)
        {
            MessageBox.Show("Error: could not find mod.json on zip root. Are you sure this is a compatible mod?");
            return;
        }

        using var zModStream = zMod.Open();
        using StreamReader reader = new(zModStream, Encoding.UTF8);
        var zModString = reader.ReadToEnd();

        var mod = JsonSerializer.Deserialize<Mod>(zModString);
        var modPath = ModManager.GetModPath(mod.ModId);

        ModManager.DeleteMod(mod.ModId, true);
        Directory.CreateDirectory(modPath);

        foreach (var entry in zip.Entries)
        {
            var destinationPath = Path.Combine(modPath, entry.FullName);

            var destFolder = Path.GetDirectoryName(destinationPath);
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            entry.ExtractToFile(destinationPath, true);
        }

        if (Directory.Exists(TempUnzipPath))
            Directory.Delete(TempUnzipPath);
    }

    public static void ZipMod(string modId, string fileName)
    {
        var modPath = ModManager.GetModPath(modId);

        if (!Directory.Exists(modPath))
        {
            MessageBox.Show("Unable to zip mod: mod not found.");
            return;
        }

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