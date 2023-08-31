using System.Text.Json.Serialization;

namespace HeavyModManager.Classes
{
    public class ModManagerVersion
    {
        [JsonInclude]
        public string Version = "v2023.08.31";
        [JsonInclude]
        public string Description = "";
    }
}
