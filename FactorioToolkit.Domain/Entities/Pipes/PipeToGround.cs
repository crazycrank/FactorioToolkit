using FactorioToolkit.Domain.Entities.Direction;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities.Pipes
{
    public class PipeToGround : Entity, IDirection
    {
        public PipeToGround(Position position, Directions direction)
            : base(position)
            => Direction = direction;

        public Directions Direction { get; }
    }
}