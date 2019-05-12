using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Belts
{
    public class FastTransportBelt : BeltBase
    {
        public FastTransportBelt(Position position, Directions direction, CircuitConnection input)
            : base(position, direction, input)
        {
        }
    }
}