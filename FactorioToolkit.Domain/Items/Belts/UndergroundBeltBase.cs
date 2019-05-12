using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.Direction;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public abstract class UndergroundBeltBase : BeltBase, IDirection
    {
        public UndergroundBeltBase(Position position, Directions direction, CircuitAccessPoint input, UndergroundBeltType type)
            : base(position, direction, input)
        {
            Type = type;
        }


        public UndergroundBeltType Type { get; }
    }
}