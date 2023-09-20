namespace HeavyModManager.Classes
{
    public abstract class GameCubeImageAbstract
    {
        public int FileNameOffset;
        public string FileName;
    }

    public class GameCubeImageFile : GameCubeImageAbstract
    {
        public int FileOffset;
        public int FileLength;
        public byte[] File;
    }

    public class GameCubeImageDirectory : GameCubeImageAbstract
    {
        public bool IsRoot;
        public int ParentOffset;
        public int NextOffset;
    }

    /// <summary>
    /// Represents a GameCube ISO image.
    /// </summary>
    public class GameCubeImage
    {
        private byte[] Apploader;
        private byte[] Boot;
        private byte[] Bi2;
        private byte[] Fst;
        private byte[] Main;
        private List<GameCubeImageAbstract> Files;

        /// <summary>
        /// Creates a new instance of the <see cref="GameCubeImage"/> class by reading from an ISO file.
        /// </summary>
        /// <param name="fileName">The ISO image filename</param>
        /// <exception cref="InvalidDataException"></exception>
        public GameCubeImage(string fileName)
        {
            using var reader = new EndianBinaryReader(new FileStream(fileName, FileMode.Open), Endianness.Big);

            reader.BaseStream.Position = 0x0;
            Boot = reader.ReadBytes(0x0440);

            reader.BaseStream.Position = 0x0440;
            Bi2 = reader.ReadBytes(0x2000);

            reader.BaseStream.Position = 0x0400;
            var apploaderSize = reader.ReadInt32();
            reader.BaseStream.Position = 0x2440;
            Apploader = reader.ReadBytes(apploaderSize);

            reader.BaseStream.Position = 0x0420;
            var dolStartPos = reader.ReadInt32();
            var fstStartPos = reader.ReadInt32();
            var fstSize = reader.ReadInt32();
            var dolSize = fstStartPos - dolStartPos;
            reader.BaseStream.Position = dolStartPos;
            Main = reader.ReadBytes(dolSize);
            reader.BaseStream.Position = fstStartPos;
            Fst = reader.ReadBytes(fstSize);

            reader.BaseStream.Position = fstStartPos;
            var fileCount = 1;
            Files = new List<GameCubeImageAbstract>();

            for (int i = 0; i < fileCount; i++)
            {
                var int0 = reader.ReadInt32();
                var int1 = reader.ReadInt32();
                var int2 = reader.ReadInt32();

                var fileType = (0xFF000000 & int0) >> 24;
                var fileNameOffset = 0x00FFFFFF & int0;

                if (fileType == 1)
                {
                    Files.Add(new GameCubeImageDirectory()
                    {
                        IsRoot = i == 0,
                        ParentOffset = int1,
                        FileNameOffset = fileNameOffset,
                        NextOffset = int2
                    });

                    if (i == 0)
                        fileCount = int2;
                }
                else if (fileType == 0)
                {
                    Files.Add(new GameCubeImageFile()
                    {
                        FileNameOffset = fileNameOffset,
                        FileOffset = int1,
                        FileLength = int2,
                    });
                }
                else
                    throw new InvalidDataException("Error reading ISO file.");
            }

            var fstStringsTableStartPos = reader.BaseStream.Position;

            for (int i = 0; i < Files.Count; i++)
            {
                reader.BaseStream.Position = fstStringsTableStartPos + Files[i].FileNameOffset;
                Files[i].FileName = reader.ReadString();

                if (Files[i] is GameCubeImageFile file)
                {
                    reader.BaseStream.Position = file.FileOffset;
                    file.File = reader.ReadBytes(file.FileLength);
                }
            }
        }

        public void Dump(string filesPath, string sysPath)
        {
            File.WriteAllBytes(Path.Combine(sysPath, "apploader.img"), Apploader);
            File.WriteAllBytes(Path.Combine(sysPath, "bi2.bin"), Bi2);
            File.WriteAllBytes(Path.Combine(sysPath, "boot.bin"), Boot);
            File.WriteAllBytes(Path.Combine(sysPath, "fst.bin"), Fst);
            File.WriteAllBytes(Path.Combine(sysPath, "main.dol"), Main);

            GameCubeImageDirectory? currentDir = null;

            for (int i = 0; i < Files.Count; i++)
            {
                if (Files[i] is GameCubeImageDirectory dir)
                    currentDir = dir;
                if (currentDir != null && i >= currentDir.NextOffset)
                    currentDir = (GameCubeImageDirectory)Files[currentDir.ParentOffset];

                string currentDirPath = (currentDir == null || currentDir.IsRoot) ? filesPath : Path.Combine(filesPath, BuildPath(currentDir));

                if (!Directory.Exists(currentDirPath))
                    Directory.CreateDirectory(currentDirPath);

                if (Files[i] is GameCubeImageFile file && ShouldDump(file.FileName))
                    File.WriteAllBytes(Path.Combine(currentDirPath, file.FileName), file.File);
            }
        }

        private string BuildPath(GameCubeImageDirectory currentDir)
        {
            if (currentDir.IsRoot)
                return "";
            return Path.Combine(BuildPath((GameCubeImageDirectory)Files[currentDir.ParentOffset]), currentDir.FileName);
        }

        private static HashSet<string> ValidExtensions = new()
        {
            ".hip", ".hop", ".bik", ".bnr", ".tpl", ".ini"
        };

        private static bool ShouldDump(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            return ValidExtensions.Contains(extension);
        }
    }
}