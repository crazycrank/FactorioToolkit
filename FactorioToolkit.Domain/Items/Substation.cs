using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items
{
    public class Substation : Item, ICircuitInput
    {
        public Substation(Position position, CircuitAccessPoint input)
            : base(position)
        {
            Input = input;
        }

        public CircuitAccessPoint Input { get; }
    }
}