using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.Direction;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Belts
{
    public abstract class UndergroundBeltBase : BeltBase, IDirection
    {
        public UndergroundBeltBase(Position position, Directions direction, CircuitConnection input, UndergroundBeltType type)
            : base(position, direction, input)
        {
            Type = type;
        }


        public UndergroundBeltType Type { get; }
    }
}