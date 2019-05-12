using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public class TransportBelt : BeltBase
    {
        public TransportBelt(Position position, Directions direction, CircuitAccessPoint input)
            : base(position, direction, input)
        {
        }
    }
}