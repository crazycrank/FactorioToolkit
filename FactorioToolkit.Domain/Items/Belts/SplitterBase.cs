using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.Direction;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
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