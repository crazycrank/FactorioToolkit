﻿using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public class Splitter : SplitterBase
    {
        public Splitter(Position position, Directions direction, CircuitConnection input, SplitterPriority inputPriority = SplitterPriority.None, SplitterPriority outputPriority = SplitterPriority.None)
            : base(position, direction, input, inputPriority, outputPriority)
        {
        }
    }
}