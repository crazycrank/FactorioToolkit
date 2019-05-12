using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.Direction;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Inserters
{
    public abstract class InserterBase : Item, IDirection, IControllable, ICircuitInput 
    {
        protected InserterBase(Position position, Directions direction, CircuitAccessPoint input, Behaviour behaviour, int? overrideStackSize)
            : base(position)
        {
            Direction = direction;
            Input = input;
            Behaviour = behaviour;
            OverrideStackSize = overrideStackSize;
        }

        public Directions Direction { get; }
        public Behaviour Behaviour { get; }
        public CircuitAccessPoint Input { get; }
        public int? OverrideStackSize { get; }
    }
}
