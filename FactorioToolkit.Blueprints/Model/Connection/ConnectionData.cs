using Newtonsoft.Json;

namespace FactorioToolkit.Blueprints.Model.Connection
{
    public class ConnectionData
    {
        [JsonProperty("entity_id")]
        public int EntityId { get; set; }

        [JsonProperty("circuit_id")]
        public int? CircuitId { get; set; }
    }
}