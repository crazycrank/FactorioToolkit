using Newtonsoft.Json;

namespace FactorioToolkit.Blueprints.Model
{
    public class SpeakerAlertParameter
    {
        [JsonProperty("show_alert")]
        public bool ShowAlert { get; set; }

        [JsonProperty("show_on_map")]
        public bool ShowOnMap { get; set; }

        [JsonProperty("icon_signal_id")]
        public Signal Signal { get; set; }

        [JsonProperty("alert_message")]
        public string AlertMessage { get; set; }
    }
}