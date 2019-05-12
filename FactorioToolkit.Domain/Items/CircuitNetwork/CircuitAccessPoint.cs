using System.Collections.Generic;

namespace FactorioToolkit.Domain.Items.CircuitNetwork
{
    public class CircuitAccessPoint
    {
        public CircuitAccessPoint()
        {
            Red = new CircuitPort();
            Green = new CircuitPort();
        }

        public CircuitPort Red { get; }
        public CircuitPort Green { get; }
    }
}