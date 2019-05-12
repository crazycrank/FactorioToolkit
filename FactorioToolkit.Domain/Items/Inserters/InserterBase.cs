using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.Direction;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Inserters
{
    public abstract class InserterBase : Item, IDirection, IControllable
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
