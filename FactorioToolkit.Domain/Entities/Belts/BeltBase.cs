using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.Direction;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Belts
{
    public abstract class BeltBase : Entity, IDirection
    {
        public BeltBase(Position position, Directions direction, CircuitConnection input)
            : base(position)
        {
            Direction = direction;
        }

        public Directions Direction { get; }
    }
}
