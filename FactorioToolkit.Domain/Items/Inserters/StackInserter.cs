﻿using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Inserters
{
    public class StackInserter : InserterBase
    {
        public StackInserter(Position position, Directions direction, CircuitAccessPoint input, Behaviour behaviour, int? overrideStackSize)
            : base(position, direction, input, behaviour, overrideStackSize)
        {
        }
    }
}