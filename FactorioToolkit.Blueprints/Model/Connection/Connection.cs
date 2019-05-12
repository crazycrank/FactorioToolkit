using Newtonsoft.Json;

namespace FactorioToolkit.Infrastructure.Model.Connection
{
    public class Connection
    {
        [JsonProperty("1")]
        public ConnectionPoint Default { get; set; }

        [JsonProperty("2")]
        public ConnectionPoint? Optional { get; set; }
    }
}