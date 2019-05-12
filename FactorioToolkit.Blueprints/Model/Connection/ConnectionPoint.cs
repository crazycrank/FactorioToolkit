using Newtonsoft.Json;

namespace FactorioToolkit.Infrastructure.Model.Connection
{
    public class ConnectionPoint
    {
#pragma warning disable CS8618 // Non-nullable field is uninitialized.
        [JsonProperty("red")]
        public ConnectionData[]? Red { get; set; }

        [JsonProperty("green")]
        public ConnectionData[]? Green { get; set; }
#pragma warning restore CS8618 // Non-nullable field is uninitialized.
    }
}