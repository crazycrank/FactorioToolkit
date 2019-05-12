﻿using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Belts
{
    public class Splitter : SplitterBase
    {
        public Splitter(Position position, Directions direction, CircuitConnection input, SplitterPriority inputPriority = SplitterPriority.None, SplitterPriority outputPriority = SplitterPriority.None)
            : base(position, direction, input, inputPriority, outputPriority)
        {
        }
    }
}