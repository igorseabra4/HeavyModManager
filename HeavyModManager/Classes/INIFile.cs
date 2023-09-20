using System.Text.RegularExpressions;

namespace HeavyModManager.Classes
{
    public class INIFile
    {
        public Dictionary<string, string> Properties { get; set; }

        public Dictionary<string, string> ScenePlayerMapping { get; set; }
        public Dictionary<string, string> ThresholdPointsRange { get; set; }
        public Dictionary<string, string> AlternateCostumeMapping { get; set; }

        public List<string> TaskStatus { get; set; }
        public List<string> Extra { get; set; }

        public static INIFile FromPath(string fileName) => new(File.Exists(fileName) ? File.ReadAllLines(fileName) : Array.Empty<string>());

        public static INIFile FromContents(string contents) => new(contents.Split('\n'));

        private INIFile(string[] contents)
        {
            Properties = new Dictionary<string, string>();
            ScenePlayerMapping = new Dictionary<string, string>();
            ThresholdPointsRange = new Dictionary<string, string>();
            AlternateCostumeMapping = new Dictionary<string, string>();
            TaskStatus = new List<string>();
            Extra = new List<string>();

            var properties = contents
                .Select(l => l.Split('#')[0].Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => l.Split('='))
                .Select(vals => (vals[0].Trim(), Regex.Replace(vals[1], @"\s+", " ").Trim()));

            foreach ((string key, string value) in properties)
            {
                switch (key)
                {
                    case "ScenePlayerMapping":
                    {
                        ScenePlayerMapping[value.Substring(0, 4)] = value.Substring(5);
                        continue;
                    }
                    case "ThresholdPointsRange":
                    {
                        ThresholdPointsRange[value.Substring(0, 4)] = value.Substring(5);
                        continue;
                    }
                    case "TaskStatus":
                    {
                        TaskStatus.Add(value);
                        continue;
                    }
                    case "Extra":
                    {
                        Extra.Add(value);
                        continue;
                    }
                    case "AlternateCostumeMapping":
                    {
                        AlternateCostumeMapping[value.Substring(0, 4)] = value.Substring(5);
                        continue;
                    }
                    default:
                    {
                        Properties[key] = value;
                        continue;
                    }
                }
            }
        }

        public void ReplaceWith(INIFile iniFile)
        {
            foreach ((string key, string value) in iniFile.Properties)
                Properties[key] = value;
            foreach ((string key, string value) in iniFile.ScenePlayerMapping)
                ScenePlayerMapping[key] = value;
            foreach ((string key, string value) in iniFile.ThresholdPointsRange)
                ThresholdPointsRange[key] = value;
            if (iniFile.TaskStatus.Any())
                TaskStatus = iniFile.TaskStatus;
            if (iniFile.Extra.Any())
                Extra = iniFile.Extra;
            foreach ((string key, string value) in iniFile.AlternateCostumeMapping)
                AlternateCostumeMapping[key] = value;
        }

        public void SaveTo(string fileName)
        {
            using var writer = new StreamWriter(new FileStream(fileName, FileMode.Create));
            foreach ((string key, string value) in Properties)
                writer.WriteLine($"{key}={value}");
            foreach ((string key, string value) in ScenePlayerMapping)
                writer.WriteLine($"ScenePlayerMapping={key} {value}");
            foreach ((string key, string value) in ThresholdPointsRange)
                writer.WriteLine($"ThresholdPointsRange={key} {value}");
            foreach (string value in TaskStatus)
                writer.WriteLine($"TaskStatus={value}");
            foreach (string value in Extra)
                writer.WriteLine($"Extra={value}");
            foreach ((string key, string value) in AlternateCostumeMapping)
                writer.WriteLine($"AlternateCostumeMapping={key} {value}");
        }
    }
}
