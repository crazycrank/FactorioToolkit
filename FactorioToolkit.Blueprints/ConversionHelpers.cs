using System;

using FactorioToolkit.Blueprints.Model;
using FactorioToolkit.Blueprints.Model.Connection;
using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.ValueObjects;

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
        internal static Domain.Entities.ValueObjects.Position ToDomainValue(this Position position)
            => new Domain.Entities.ValueObjects.Position(position.X, position.Y);

        internal static CircuitConnection ToDomainValue(this ConnectionPoint? connection)
            => new CircuitConnection(new CircuitPort(), null);
        //=> new CircuitConnection((connection?.Red).ToDomainValue(), (connection?.Green).ToDomainValue()); TODO

        internal static Behaviour ToDomainValue(this ControlBehaviour? connection)
            => new Behaviour();

        internal static CircuitPort ToDomainValue(this ConnectionData? connection)
            => new CircuitPort();

        internal static Domain.Entities.Belts.UndergroundBeltType ParseBeltValue(this string? beltType)
            => beltType switch
                   {
                   "input" => Domain.Entities.Belts.UndergroundBeltType.Input,
                   "output" => Domain.Entities.Belts.UndergroundBeltType.Output,
                   _ => throw new ArgumentOutOfRangeException(nameof(beltType), beltType, $"Unexpected value: {beltType}")
                   };

        internal static Domain.Entities.Belts.SplitterPriority ParseSplitterPriority(this string? priority)
            => priority switch
                   {
                   "left" => Domain.Entities.Belts.SplitterPriority.Left,
                   "right" => Domain.Entities.Belts.SplitterPriority.Right,
                   _ => Domain.Entities.Belts.SplitterPriority.None,
                   };
    }
}