namespace FactorioToolkit.Domain.Items.CircuitNetwork
{
    public interface IControllable
    {
        // TODO Lazy load entities
        public Behaviour Behaviour { get; }
    }
}