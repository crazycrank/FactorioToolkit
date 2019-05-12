﻿using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Belts
{
    public class ExpressUndergroundBelt : UndergroundBeltBase
    {
        public ExpressUndergroundBelt(Position position, Directions direction, CircuitConnection input, UndergroundBeltType type)
            : base(position, direction, input, type)
        {
        }
    }
}