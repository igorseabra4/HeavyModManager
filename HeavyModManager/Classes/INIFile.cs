namespace HeavyModManager.Classes
{
    public class INIFile
    {
        public Dictionary<string, string> Properties { get; set; }

        public INIFile(string fileName)
        {
            Properties = new Dictionary<string, string>();

            if (!File.Exists(fileName))
                return;

            var properties = File.ReadAllLines(fileName)
                .Select(l => l.Split('#')[0].Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => l.Split('='))
                .Select(vals => (vals[0].Trim(), vals[1].Trim()));

            foreach ((string key, string value) in properties)
                Properties[key] = value;
        }

        public void Replace(INIFile ExternalINI)
        {
            Replace(ExternalINI.Properties);
        }

        public void Replace(Dictionary<string, string> ExternalProperties)
        {
            foreach ((string key, string value) in ExternalProperties)
                Properties[key] = value;
        }

        public void Replace(IEnumerable<(string, string)> ExternalProperties)
        {
            foreach ((string key, string value) in ExternalProperties)
                Properties[key] = value;
        }

        public void SaveTo(string fileName)
        {
            using var writer = new StreamWriter(new FileStream(fileName, FileMode.Create));
            foreach ((string key, string value) in Properties)
                writer.WriteLine($"{key}={value}");
        }
    }
}
