namespace FactorioToolkit.Blueprints.Model.Filter
{
    public class InfinityFilter : Filter
    {
        public int Count { get; set; }
        public InfinityFilterMode Mode { get; set; }

        public enum InfinityFilterMode
        {
            At_Least,
            At_Most,
            Exactly
        }
    }
}