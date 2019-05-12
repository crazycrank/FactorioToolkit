using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities
{
    public abstract class Entity
    {
        public Entity(Position position)
        {
            Position = position;
        }

        public Position Position { get; }
    }
}