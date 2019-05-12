using System;

using FactorioToolkit.Domain.Items.Belts;
using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;
using FactorioToolkit.Infrastructure.Model;

using Position = FactorioToolkit.Infrastructure.Model.Data.Position;

namespace FactorioToolkit.Infrastructure
{
    internal static class ConversionHelpers
    {
        internal static Directions ToDomainValue(this Direction? direction)
            => direction switch
                   {
                   Direction.N => Directions.North,
                   Direction.NE => Directions.NorthEast,
                   Direction.E => Directions.East,
                   Direction.SE => Directions.SouthEast,
                   Direction.S => Directions.South,
                   Direction.SW => Directions.SouthWest,
                   Direction.W => Directions.West,
                   Direction.NW => Directions.NorthWest,
                   _ => Directions.North
                   };
        internal static Domain.Items.ValueObjects.Position ToDomainValue(this Position position)
            => new Domain.Items.ValueObjects.Position(position.X, position.Y);

        internal static Behaviour ToDomainValue(this ControlBehaviour? connection)
            => new Behaviour();


        internal static UndergroundBeltType ParseBeltValue(this string beltType)
            => beltType switch
                   {
                   "input" => UndergroundBeltType.Input,
                   "output" => UndergroundBeltType.Output,
                   _ => throw new ArgumentOutOfRangeException(nameof(beltType), beltType, $"Unexpected value: {beltType}")
                   };

        internal static SplitterPriority ParseSplitterPriority(this string priority)
            => priority switch
                   {
                   "left" => SplitterPriority.Left,
                   "right" => SplitterPriority.Right,
                   _ => SplitterPriority.None,
                   };
    }
}