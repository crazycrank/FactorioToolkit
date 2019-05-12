using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items
{
    public class Substation : Item, ICircuitPortSingle
    {
        public Substation(Position position, CircuitConnection input)
            : base(position)
        {
            Input = input;
        }

        public CircuitConnection Input { get; }
    }
}