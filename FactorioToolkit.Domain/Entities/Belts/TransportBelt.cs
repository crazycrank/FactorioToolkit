using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Belts
{
    public class TransportBelt : BeltBase
    {
        public TransportBelt(Position position, Directions direction, CircuitConnection input)
            : base(position, direction, input)
        {
        }
    }
}