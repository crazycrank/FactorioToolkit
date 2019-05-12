using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public abstract class SplitterBase : BeltBase
    {
        public SplitterBase(Position position, Directions direction, CircuitAccessPoint input, SplitterPriority inputPriority = SplitterPriority.None, SplitterPriority outputPriority = SplitterPriority.None)
            : base(position, direction, input)
        {
            InputPriority = inputPriority;
            OutputPriority = outputPriority;
        }

        public SplitterPriority InputPriority { get; }
        public SplitterPriority OutputPriority { get; }
    }
}