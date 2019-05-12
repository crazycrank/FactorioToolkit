namespace FactorioToolkit.Domain.Entities.CircuitNetwork
{
    public interface IControllable
    {
        // TODO Lazy load entities
        public Behaviour Behaviour { get; }
    }
}