using System.Text.Json.Serialization;

namespace HeavyModManager.Classes
{
    /// <summary>
    /// The version of the mod manager application.
    /// </summary>
    public class ModManagerVersion
    {
        /// <summary>
        /// The version number.
        /// </summary>
        [JsonInclude]
        public string Version { get; } = "v2023.09.26";


        /// <summary>
        /// A description of the version changes.
        /// </summary>
        [JsonInclude]
        public string Description { get; } = "";
    }
}
