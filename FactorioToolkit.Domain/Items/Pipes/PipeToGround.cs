using FactorioToolkit.Domain.Items.Direction;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items.Pipes
{
    public class PipeToGround : Item, IDirection
    {
        public PipeToGround(Position position, Directions direction)
            : base(position)
            => Direction = direction;

        public Directions Direction { get; }
    }
}