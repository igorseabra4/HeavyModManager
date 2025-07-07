﻿using HeavyModManager.Classes;
using HeavyModManager.Forms;
using System.IO.Compression;
using System.Text.Json;

namespace HeavyModManager.Functions
{
    public enum UpdateResult
    {
        Updated,
        UserDeclined,
        NoUpdateAvailable,
        Error
    }

    /// <summary>
    /// Class for updating the mod manager application.
    /// </summary>
    public static class AutomaticUpdater
    {

        /// <summary>
        /// Attempts to update the mod manager application.
        /// </summary>
        /// <returns>true if the update was successful, otherwise false</returns>
        public static async Task<UpdateResult> Update()
        {
            try
            {
                string versionInfoURL = "https://raw.githubusercontent.com/igorseabra4/HeavyModManager/master/Resources/ModManagerVersion.json";

                var client = new HttpClient();
                string updatedJson = await client.GetStringAsync(versionInfoURL);
                var updatedVersion = JsonSerializer.Deserialize<ModManagerVersion>(updatedJson);
                var oldVersion = ModManagerVersion.GetCurrent();

                if (updatedVersion == null || oldVersion.Version == updatedVersion.Version)
                    return UpdateResult.NoUpdateAvailable;

                string messageText =
                    $"{GlobalResources.updateAvailable} {GlobalResources.programName} {updatedVersion.Version}." +
                    $"\n\n{updatedVersion.Description}\n\n{GlobalResources.downloadPrompt}";

                DialogResult d = MessageBox.Show(messageText,
                    GlobalResources.updateAvailableTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (d == DialogResult.Yes)
                {
                    // FIXME : Hard-coded file name breaks updates if the release .zip filename is different
                    string updatedFileName = $"HeavyModManager_{updatedVersion.Version}.zip";
                    string updatedURL = $"https://github.com/igorseabra4/HeavyModManager/releases/download/{updatedVersion.Version}/{updatedFileName}";

                    var tempDir = Path.Combine(Application.StartupPath, "temp");
                    if (!Directory.Exists(tempDir))
                        Directory.CreateDirectory(tempDir);

                    string updatedZipFilePath = Path.Combine(tempDir, updatedFileName);

                    using (var zipFileStream = await client.GetStreamAsync(updatedURL))
                    using (var writer = new BinaryWriter(new FileStream(updatedZipFilePath, FileMode.Create)))
                        zipFileStream.CopyTo(writer.BaseStream);

                    var oldDirPath = Path.Combine(Application.StartupPath, "HeavyModManager_old");
                    if (!Directory.Exists(oldDirPath))
                        Directory.CreateDirectory(oldDirPath);

                    var fileNames = new string[]
                    {
                        "HeavyModManager.deps.json", // not needed
                        "HeavyModManager.dll",
                        "HeavyModManager.exe",
                        "HeavyModManager.pdb", // not needed
                        "HeavyModManager.runtimeconfig.json",
                        "HipHopFile.dll",
                        "HipHopFile.pdb", // not needed
                    };

                    foreach (var file in fileNames)
                    {
                        var oldFilePath = Path.Combine(Application.StartupPath, file);
                        if (File.Exists(oldFilePath))
                            File.Move(oldFilePath, Path.Combine(oldDirPath, file));
                    }

                    ZipFile.ExtractToDirectory(updatedZipFilePath, Application.StartupPath);

                    File.Delete(updatedZipFilePath);
                    Directory.Delete(tempDir);

                    return UpdateResult.Updated;
                }

                return UpdateResult.UserDeclined;
            }
            catch (Exception ex)
            {
                string messageText = GlobalResources.errorCheckingForUpdates + " " + ex.Message;

                MessageBox.Show(
                    messageText,
                    GlobalResources.errorCheckingForUpdatesTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return UpdateResult.Error;
            }
        }

        /// <summary>
        /// Recursively deletes a directory and all its contents.
        /// </summary>
        /// <param name="directory">The directory to delete</param>
        private static void RecursiveDelete(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            foreach (var dir in Directory.GetDirectories(directory))
                RecursiveDelete(dir);

            foreach (var s in Directory.GetFiles(directory))
                File.Delete(s);

            Directory.Delete(directory);
        }
    }
}