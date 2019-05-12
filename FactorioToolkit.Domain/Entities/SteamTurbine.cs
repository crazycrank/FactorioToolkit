using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.Direction;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities
{
    public class SteamTurbine : Entity, IDirection, ICircuitPortSingle
    {
        public SteamTurbine(Position position, Directions direction, CircuitConnection input)
            : base(position)
        {
            Direction = direction;
            Input = input;
        }

        public Directions Direction { get; }
        public CircuitConnection Input { get; }
    }
}