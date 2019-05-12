using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public class FastTransportBelt : BeltBase
    {
        public FastTransportBelt(Position position, Directions direction, CircuitAccessPoint input)
            : base(position, direction, input)
        {
        }
    }
}