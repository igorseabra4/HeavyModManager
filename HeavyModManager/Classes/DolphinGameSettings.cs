namespace HeavyModManager.Classes
{
    public class DolphinCode
    {
        public string Name { get; set; }
        public List<(uint, uint)> Code { get; set; }
        public bool Enabled { get; set; }

        public DolphinCode()
        {
            Name = "";
            Code = new List<(uint, uint)>();
            Enabled = false;
        }
    }

    public enum DolphinSettingsReaderMode
    {
        Lines,
        Core,
        ActionReplay,
        ActionReplayEnabled,
        Gecko,
        GeckoEnabled
    }

    public class DolphinGameSettings
    {
        public List<string> Lines { get; set; }
        public Dictionary<string, string> Core { get; set; }
        public List<DolphinCode> ActionReplay { get; set; }
        public List<DolphinCode> Gecko { get; set; }

        public static DolphinGameSettings FromPath(string fileName) => new(File.Exists(fileName) ? File.ReadAllLines(fileName) : Array.Empty<string>());

        public static DolphinGameSettings FromContents(string contents, DolphinSettingsReaderMode defaultMode = DolphinSettingsReaderMode.Lines) => new(contents.Split('\n'), defaultMode);

        private DolphinGameSettings(string[] contents, DolphinSettingsReaderMode defaultMode = DolphinSettingsReaderMode.Lines)
        {
            Lines = new List<string>();
            Core = new Dictionary<string, string>();
            ActionReplay = new List<DolphinCode>();
            Gecko = new List<DolphinCode>();

            var mode = defaultMode;
            DolphinCode currCode = new DolphinCode();

            void addCurrCode()
            {
                if (currCode.Code.Any())
                {
                    if (mode == DolphinSettingsReaderMode.Gecko)
                        Gecko.Add(currCode);
                    else if (mode == DolphinSettingsReaderMode.ActionReplay)
                        ActionReplay.Add(currCode);
                    else
                        throw new InvalidDataException("Wrong format");
                }
                currCode = new DolphinCode();
            }

            foreach (var l in contents)
            {
                var line = l.Split('*')[0];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                switch (line)
                {
                    case "[Core]":
                        addCurrCode();
                        mode = DolphinSettingsReaderMode.Core;
                        continue;
                    case "[ActionReplay]":
                        addCurrCode();
                        mode = DolphinSettingsReaderMode.ActionReplay;
                        continue;
                    case "[ActionReplay_Enabled]":
                        addCurrCode();
                        mode = DolphinSettingsReaderMode.ActionReplayEnabled;
                        continue;
                    case "[Gecko]":
                        addCurrCode();
                        mode = DolphinSettingsReaderMode.Gecko;
                        continue;
                    case "[Gecko_Enabled]":
                        addCurrCode();
                        mode = DolphinSettingsReaderMode.GeckoEnabled;
                        continue;
                }

                if (line.StartsWith('['))
                {
                    addCurrCode();
                    mode = DolphinSettingsReaderMode.Lines;
                }

                switch (mode)
                {
                    case DolphinSettingsReaderMode.Lines:
                        Lines.Add(line);
                        continue;
                    case DolphinSettingsReaderMode.Core:
                        var values = line.Split('=', 2);
                        if (values.Length != 2)
                            throw new InvalidDataException("Wrong format");
                        Core[values[0].Trim()] = values[1].Trim();
                        continue;
                    case DolphinSettingsReaderMode.ActionReplay:
                    case DolphinSettingsReaderMode.Gecko:
                        if (line.StartsWith('$'))
                        {
                            addCurrCode();
                            currCode.Name = line.Substring(1);
                        }
                        else
                        {
                            var vals = line.Split(' ', 2);
                            if (vals.Length != 2)
                                throw new InvalidDataException("Wrong format");
                            currCode.Code.Add((Convert.ToUInt32(vals[0], 16), Convert.ToUInt32(vals[1], 16)));
                        }
                        continue;
                    case DolphinSettingsReaderMode.ActionReplayEnabled:
                        var ar = ActionReplay.Where(code => code.Name == line.Substring(1));
                        foreach (var code in ar)
                            code.Enabled = true;
                        continue;
                    case DolphinSettingsReaderMode.GeckoEnabled:
                        var gecko = Gecko.Where(code => code.Name == line.Substring(1));
                        foreach (var code in gecko)
                            code.Enabled = true;
                        continue;
                }
            }

            addCurrCode();
        }

        public void SaveTo(string fileName)
        {
            using var writer = new StreamWriter(new FileStream(fileName, FileMode.Create));
            foreach (var line in Lines)
                writer.WriteLine(line);
            if (Core.Any())
            {
                writer.WriteLine("[Core]");
                foreach (var entry in Core)
                    writer.WriteLine($"{entry.Key} = {entry.Value}");
            }
            if (ActionReplay.Any())
            {
                writer.WriteLine("[ActionReplay]");
                foreach (var code in ActionReplay)
                {
                    writer.WriteLine($"${code.Name}");
                    foreach (var codeLine in code.Code)
                        writer.WriteLine($"{codeLine.Item1:X8} {codeLine.Item2:X8}");
                }
            }
            var arEnabled = ActionReplay.Where(code => code.Enabled).Select(code => code.Name);
            if (arEnabled.Any())
            {
                writer.WriteLine("[ActionReplay_Enabled]");
                foreach (var code in arEnabled)
                    writer.WriteLine($"${code}");
            }
            if (Gecko.Any())
            {
                writer.WriteLine("[Gecko]");
                foreach (var code in Gecko)
                {
                    writer.WriteLine($"${code.Name}");
                    foreach (var codeLine in code.Code)
                        writer.WriteLine($"{codeLine.Item1:X8} {codeLine.Item2:X8}");
                }
            }
            var geckoEnabled = Gecko.Where(code => code.Enabled).Select(code => code.Name);
            if (geckoEnabled.Any())
            {
                writer.WriteLine("[Gecko_Enabled]");
                foreach (var code in geckoEnabled)
                    writer.WriteLine($"${code}");
            }
        }
    }
}
