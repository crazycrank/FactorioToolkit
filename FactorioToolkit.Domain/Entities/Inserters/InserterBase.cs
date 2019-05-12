using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.Direction;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Inserters
{
    public abstract class InserterBase : Entity, IDirection, IControllable
    {
        protected InserterBase(Position position, Directions direction, CircuitConnection input, Behaviour behaviour, int? overrideStackSize)
            : base(position)
        {
            Direction = direction;
            OverrideStackSize = overrideStackSize;
            Behaviour = behaviour;
        }

        public Directions Direction { get; }
        public Behaviour Behaviour { get; }
        public int? OverrideStackSize { get; }
    }
}
