using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.Direction;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public abstract class BeltBase : Item, IDirection
    {
        public BeltBase(Position position, Directions direction, CircuitConnection input)
            : base(position)
        {
            Direction = direction;
        }

        public Directions Direction { get; }
    }
}
