﻿using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public class UndergroundBelt : UndergroundBeltBase
    {
        public UndergroundBelt(Position position, Directions direction, CircuitAccessPoint input, UndergroundBeltType type)
            : base(position, direction, input, type)
        {
        }
    }
}