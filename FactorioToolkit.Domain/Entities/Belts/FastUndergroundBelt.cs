using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Belts
{
    public class FastUndergroundBelt : UndergroundBeltBase
    {
        public FastUndergroundBelt(Position position, Directions direction, CircuitConnection input, UndergroundBeltType type)
            : base(position, direction, input, type)
        {
        }
    }
}