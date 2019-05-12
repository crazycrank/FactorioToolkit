using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.Direction;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public abstract class BeltBase : Item, IDirection, ICircuitInput
    {
        public BeltBase(Position position, Directions direction, CircuitAccessPoint input)
            : base(position)
        {
            Direction = direction;
            Input = input;
        }

        public Directions Direction { get; }
        public CircuitAccessPoint Input { get; }
    }
}
