using System.Collections.Generic;

namespace FactorioToolkit.Domain.Items.CircuitNetwork
{
    public class CircuitPort
    {
        // TODO Lazy load entities
        public IList<Item> Connections { get; } = new List<Item>();
    }
}