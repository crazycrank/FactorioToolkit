namespace FactorioToolkit.Domain.Items.CircuitNetwork
{
    internal interface ICircuitInputOutput : ICircuitInput
    {
        public CircuitAccessPoint Out { get; }
    }
}