using HeavyModManager.Classes;
using System.IO.Compression;
using System.Text.Json;

namespace HeavyModManager.Functions
{
    public static class AutomaticUpdater
    {
        public static async Task<bool> Update()
        {
            try
            {
                string versionInfoURL = "https://raw.githubusercontent.com/igorseabra4/HeavyModManager/master/Resources/ModManagerVersion.json";

                var client = new HttpClient();
                string updatedJson = await client.GetStringAsync(versionInfoURL);
                var updatedVersion = JsonSerializer.Deserialize<ModManagerVersion>(updatedJson);
                var oldVersion = new ModManagerVersion();

                if (oldVersion.Version != updatedVersion.Version)
                {
                    string messageText = $"There is an update available: Heavy Mod Manager {updatedVersion.Version}.\n\n{updatedVersion.Description}\n\nDo you wish to download it?";
                    DialogResult d = MessageBox.Show(messageText, "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (d == DialogResult.Yes)
                    {
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

                        File.Move(Path.Combine(Application.StartupPath, "HeavyModManager.dll"), Path.Combine(oldDirPath, "HeavyModManager.dll"));
                        File.Move(Path.Combine(Application.StartupPath, "HeavyModManager.exe"), Path.Combine(oldDirPath, "HeavyModManager.exe"));
                        File.Move(Path.Combine(Application.StartupPath, "HeavyModManager.runtimeconfig.json"), Path.Combine(oldDirPath, "HeavyModManager.runtimeconfig.json"));

                        ZipFile.ExtractToDirectory(updatedZipFilePath, Application.StartupPath);

                        File.Delete(updatedZipFilePath);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error checking for updates: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

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
