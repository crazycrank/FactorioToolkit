﻿using FactorioToolkit.Infrastructure.Model.Data;

using Newtonsoft.Json;

namespace FactorioToolkit.Infrastructure.Model
{
    public class BlueprintBook
    {
        public string Item { get; set; }
        public string Label { get; set; }

        [JsonProperty("label_color")]
        public Color? LabelColor { get; set; }
        public (int index, Blueprint blueprint)[] Blueprints { get; set; }

        [JsonProperty("activeIndex")]
        public int ActiveIndex { get; set; }

        [JsonProperty("version")]
        public long MapVersion { get; set; }
    }
}
