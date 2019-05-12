namespace FactorioToolkit.Domain.Entities.CircuitNetwork
{
    internal interface ICircuitPortMultiple : ICircuitPortSingle
    {
        public CircuitConnection Out { get; }
    }
}