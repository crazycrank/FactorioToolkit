using System.Collections.Generic;

using FactorioToolkit.Domain.Items;

namespace FactorioToolkit.Domain
{
    public class Blueprint
    {
        public Blueprint(string name, IList<Item> items)
        {
            Name = name;
            Items = items;
        }

        public string Name { get; }
        public IList<Item> Items { get; } 
    }
}