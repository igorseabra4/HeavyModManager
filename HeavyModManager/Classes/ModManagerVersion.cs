﻿using System.Text.Json.Serialization;

namespace HeavyModManager.Classes
{
    public class ModManagerVersion
    {
        [JsonInclude]
        public string Version = "v2023.09.01.2";
        [JsonInclude]
        public string Description = "";
    }
}