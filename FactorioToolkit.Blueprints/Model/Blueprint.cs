using FactorioToolkit.Infrastructure.Model.Data;

using Newtonsoft.Json;

namespace FactorioToolkit.Infrastructure.Model
{
    public class Blueprint
    {
        public string Item { get; set; }
        public string Label { get; set; }

        [JsonProperty("label_color")]
        public Color? LabelColor { get; set; }

        public Entity[] Entities { get; set; }
        public Tile[] Tiles { get; set; }
        public Icon[] Icons { get; set; }

        [JsonProperty("version")]
        public long MapVersion { get; set; }
    }
}
