using System.Collections.Generic;

namespace FactorioToolkit.Domain.Items.CircuitNetwork
{
    public class CircuitPort
    {
        public ISet<Item> ConnectedItems { get; } = new HashSet<Item>();

        public void AddConnection(Item connectedItem)
        {
            ConnectedItems.Add(connectedItem);
        }

        public void RemoveConnection(Item connectedItem)
        {
            ConnectedItems.Remove(connectedItem);
        }
    }
}
