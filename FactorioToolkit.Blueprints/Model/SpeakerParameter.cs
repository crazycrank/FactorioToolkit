using Newtonsoft.Json;

namespace FactorioToolkit.Blueprints.Model
{
    public class SpeakerParameter
    {
        [JsonProperty("playback_volume")]
        public float PlaybackVolume { get; set; }

        [JsonProperty("playback_globally")]
        public bool PlaybackGlobally { get; set; }

        [JsonProperty("allow_polyphony")]
        public bool PlaybackPolyphony { get; set; }
    }
}