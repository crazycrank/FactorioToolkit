using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

using FactorioToolkit.Blueprints.Model.Data;

using Newtonsoft.Json;

namespace FactorioToolkit.Blueprints.Model
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
