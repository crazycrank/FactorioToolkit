using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public class ExpressTransportBelt : BeltBase
    {
        public ExpressTransportBelt(Position position, Directions direction, CircuitConnection input)
            : base(position, direction, input)
        {
        }
    }
}