using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.Direction;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Belts
{
    public abstract class SplitterBase : BeltBase, IDirection
    {
        public SplitterBase(Position position, Directions direction, CircuitConnection input, SplitterPriority inputPriority = SplitterPriority.None, SplitterPriority outputPriority = SplitterPriority.None)
            : base(position, direction, input)
        {
            InputPriority = inputPriority;
            OutputPriority = outputPriority;
        }

        public SplitterPriority InputPriority { get; }
        public SplitterPriority OutputPriority { get; }
    }
}