using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Inserters
{
    public class FastInserter : InserterBase
    {
        public FastInserter(Position position, Directions direction, CircuitConnection input, Behaviour behaviour, int? overrideStackSize)
            : base(position, direction, input, behaviour, overrideStackSize)
        {
        }
    }
}