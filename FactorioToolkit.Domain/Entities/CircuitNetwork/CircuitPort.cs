using System.Collections.Generic;

namespace FactorioToolkit.Domain.Entities.CircuitNetwork
{
    public class CircuitPort
    {
        // TODO Lazy load entities
        public IList<Entity> Connections { get; } = new List<Entity>();
    }
}