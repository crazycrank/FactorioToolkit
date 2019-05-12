namespace FactorioToolkit.Domain.Entities.CircuitNetwork
{
    public class CircuitConnection
    {
        public CircuitConnection(CircuitPort? red = null, CircuitPort? green = null)
        {
            Red = red ?? new CircuitPort();
            Green = green ?? new CircuitPort();
        }

        public CircuitPort Green { get; }
        public CircuitPort Red { get; }
    }
}