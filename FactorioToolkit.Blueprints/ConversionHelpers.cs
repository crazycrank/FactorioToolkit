using System;

using FactorioToolkit.Blueprints.Model;
using FactorioToolkit.Blueprints.Model.Connection;
using FactorioToolkit.Domain.Items.Belts;
using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.ValueObjects;

using Position = FactorioToolkit.Blueprints.Model.Data.Position;

namespace FactorioToolkit.Blueprints
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

        internal static CircuitConnection ToDomainValue(this ConnectionPoint? connection)
            => new CircuitConnection(new CircuitPort(), null);
        //=> new CircuitConnection((connection?.Red).ToDomainValue(), (connection?.Green).ToDomainValue()); TODO

        internal static Behaviour ToDomainValue(this ControlBehaviour? connection)
            => new Behaviour();

        internal static CircuitPort ToDomainValue(this ConnectionData? connection)
            => new CircuitPort();

        internal static UndergroundBeltType ParseBeltValue(this string? beltType)
            => beltType switch
                   {
                   "input" => UndergroundBeltType.Input,
                   "output" => UndergroundBeltType.Output,
                   _ => throw new ArgumentOutOfRangeException(nameof(beltType), beltType, $"Unexpected value: {beltType}")
                   };

        internal static SplitterPriority ParseSplitterPriority(this string? priority)
            => priority switch
                   {
                   "left" => SplitterPriority.Left,
                   "right" => SplitterPriority.Right,
                   _ => SplitterPriority.None,
                   };
    }
}