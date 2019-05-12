using System;
using System.Collections.Generic;
using System.Text;

using FactorioToolkit.Domain.Items;
using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain
{
    public interface IItemRepository
    {
        Item GetItem(Position position);

        bool AddItem(Item item);
    }
}
