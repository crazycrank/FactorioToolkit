using FactorioToolkit.Domain;
using FactorioToolkit.Domain.Items;

namespace FactorioToolkit.Infrastructure.Repositories
{
    public interface IItemInfrastructureRepository : IItemRepository
    {
        Item GetItem(int entityId);

        bool AddItem(int entityId, Item item);
    }
}