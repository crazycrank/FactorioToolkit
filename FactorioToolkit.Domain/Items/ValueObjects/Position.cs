﻿namespace FactorioToolkit.Domain.Items.ValueObjects
{
    public struct Position
    {
        public Position(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public decimal X { get; }
        public decimal Y { get; }

        public override string ToString()
            => $"({X}/{Y})";
    }
}