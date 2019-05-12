namespace FactorioToolkit.Domain.Items.CircuitNetwork
{
    internal interface ICircuitPortMultiple : ICircuitPortSingle
    {
        public CircuitConnection Out { get; }
    }
}