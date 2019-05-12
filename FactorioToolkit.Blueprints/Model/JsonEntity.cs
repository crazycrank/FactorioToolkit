using FactorioToolkit.Blueprints.Model.Data;
using FactorioToolkit.Blueprints.Model.Filter;

using Newtonsoft.Json;

namespace FactorioToolkit.Blueprints.Model
{
    public class JsonEntity
    {
        [JsonProperty("entity_number")]
        public int Entity_Number { get; set; }

        public string Name { get; set; }
        public Position Position { get; set; }
        public Direction? Direction { get; set; }
        public Connection.Connection? Connections { get; set; }

        [JsonProperty("control_behaviour")]
        public ControlBehaviour? ControlBehaviour { get; set; } // TODO

        [JsonProperty("items")]
        public (string itemName, int quantitiy)[]? ItemRequests { get; set; }

        [JsonProperty("recipe")]
        public string? AssemblyRecipe { get; set; }

        public int? Bar { get; set; }

        [JsonProperty("infinity_settings")]
        public InfinitySettings? InfinitySettings { get; set; }

        [JsonProperty("type")]
        public string? UndergroundBeltType { get; set; }

        [JsonProperty("input_priority")]
        public string? InputPriority { get; set; }

        [JsonProperty("output_priority")]
        public string? OutputPriority { get; set; }

        [JsonProperty("filter")]
        public string? SplitterFilter { get; set; }

        [JsonProperty("filters")]
        public ItemFilter[]? InserterFilters { get; set; }

        [JsonProperty("override_stack_size")]
        public int? OverrideStackSize { get; set; }

        [JsonProperty("Drop_Position")]
        public Position? DropPosition { get; set; }

        [JsonProperty("Pickup_Position")]
        public Position? PickupPosition { get; set; }

        [JsonProperty("Request_Filters")]
        public LogisticFilter? LogisticsRequestFilters { get; set; }

        [JsonProperty("Request_From_Buffers")]
        public bool? LogisticsRequestFromBuffers { get; set; }

        [JsonProperty("parameters")]
        public SpeakerParameter? SpeakerParameters { get; set; }

        [JsonProperty("Alert_Parameters")]
        public SpeakerAlertParameter? SpeakerAlertParameters { get; set; }

        [JsonProperty("Auto_Launch")]
        public bool? RocketSiloAutoLaunch { get; set; }

        public object? Variation { get; set; }

        public object? Color { get; set; }

        [JsonProperty("station")]
        public string StationName { get; set; }
    }
}