using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Belts
{
    public class FastSplitter : SplitterBase
    {
        public FastSplitter(Position position, Directions direction, CircuitConnection input, SplitterPriority inputPriority = SplitterPriority.None, SplitterPriority outputPriority = SplitterPriority.None)
            : base(position, direction, input, inputPriority: inputPriority, outputPriority: outputPriority)
        {
        }
    }
}