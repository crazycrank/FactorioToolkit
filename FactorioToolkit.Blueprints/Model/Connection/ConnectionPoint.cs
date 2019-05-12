using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace FactorioToolkit.Blueprints.Model.Connection
{
    public class ConnectionPoint
    {
        [JsonProperty("red")]
        public ConnectionData[] Red { get; set; }

        [JsonProperty("green")]
        public ConnectionData[] Green { get; set; }
    }
}