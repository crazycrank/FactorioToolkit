using FactorioToolkit.Blueprints.Model.Filter;

using Newtonsoft.Json;

namespace FactorioToolkit.Blueprints.Model
{
    public class InfinitySettings
    {
        [JsonProperty("remove_unfiltered_items")]
        public bool RemoveUnfilteredObjects { get; set; }

        public InfinityFilter[] InfinityFilters { get; set; }
    }
}