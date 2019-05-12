using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Infrastructure.Exceptions
{
    public class ItemNotFoundException : FactorioToolkitException
    {
        public Position? Position { get; }
        public int? EntityId { get; }

        public ItemNotFoundException(Position position)
            : base($"No item at position {position}")
        {
            Position = position;
        }

        public ItemNotFoundException(int entityId)
            : base($"No item with EntityId {entityId}")

        {
            EntityId = entityId;
        }
    }
}