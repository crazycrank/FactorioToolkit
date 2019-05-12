using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Inserters
{
    public class BurnerInserter : InserterBase
    {
        public BurnerInserter(Position position, Directions direction, CircuitConnection input, Behaviour behaviour, int? overrideStackSize)
            : base(position, direction, input, behaviour, overrideStackSize)
        {
        }
    }
}