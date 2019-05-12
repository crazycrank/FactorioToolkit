using System.Diagnostics;

using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class Item
    {
        public Item(Position position)
        {
            Position = position;
        }

        public Position Position { get; }

        private string DebuggerDisplay => $"{Position}: {GetType().Name}";
    }
}