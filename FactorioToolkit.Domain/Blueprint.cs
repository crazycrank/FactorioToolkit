using System.Collections.Generic;

using FactorioToolkit.Domain.Items;

namespace FactorioToolkit.Domain
{
    public class Blueprint
    {
        public string Name { get; set; }
        public IList<Item> Items { get; set; } = new List<Item>();
    }
}