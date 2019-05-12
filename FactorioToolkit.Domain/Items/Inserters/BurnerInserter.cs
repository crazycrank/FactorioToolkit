using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Inserters
{
    public class BurnerInserter : InserterBase
    {
        public BurnerInserter(Position position, Directions direction, CircuitConnection input, Behaviour behaviour, int? overrideStackSize)
            : base(position, direction, input, behaviour, overrideStackSize)
        {
        }
    }
}