using System.Collections.Generic;

using FactorioToolkit.Domain.Items;
using FactorioToolkit.Domain.Items.ValueObjects;
using FactorioToolkit.Infrastructure.Exceptions;

namespace FactorioToolkit.Infrastructure.Repositories
{
    public class ItemRepository : IItemInfrastructureRepository
    {
        private readonly Dictionary<int, Item> itemsByEntityId = new Dictionary<int, Item>();
        private readonly Dictionary<Position, Item> itemsByPosition = new Dictionary<Position, Item>();

        public Item GetItem(Position position)
            => itemsByPosition.TryGetValue(position, out var item)
                   ? item
                   : throw new ItemNotFoundException(position);

        public bool AddItem(Item item)
        {
            if (itemsByPosition.ContainsKey(item.Position))
            {
                return false;
            }

            itemsByPosition.Add(item.Position, item);
            return true;
        }

        public Item GetItem(int entityId)
            => itemsByEntityId.TryGetValue(entityId, out var item)
                   ? item
                   : throw new ItemNotFoundException(entityId);

        public bool AddItem(int entityId, Item item)
        {
            if (itemsByEntityId.ContainsKey(entityId))
            {
                return false;
            }

            if (itemsByPosition.ContainsKey(item.Position))
            {
                throw new FactorioToolkitException($"The item should not yet be in the repository");
            }

            itemsByEntityId.Add(entityId, item);
            itemsByPosition.Add(item.Position, item);
            return true;
        }
    }
}
