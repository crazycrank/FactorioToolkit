using FactorioToolkit.Domain.Entities;
using System.Collections.Generic;

namespace FactorioToolkit.Domain
{
    public class Blueprint
    {
        public string Name { get; set; }
        public IList<Entity> Entities { get; set; } = new List<Entity>();
    }
}