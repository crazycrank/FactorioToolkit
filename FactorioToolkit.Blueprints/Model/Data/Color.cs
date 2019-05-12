using Newtonsoft.Json;

namespace FactorioToolkit.Infrastructure.Model.Data
{
    public struct Color
    {
        [JsonProperty("r")]
        public int Red { get; set; }

        [JsonProperty("g")]
        public int Green { get; set; }

        [JsonProperty("b")]
        public int Blue { get; set; }

        [JsonProperty("a")]
        public int Alpha { get; set; }
    }
}