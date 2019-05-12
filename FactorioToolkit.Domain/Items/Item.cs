using FactorioToolkit.Domain.Items.ValueObjects;

namespace FactorioToolkit.Domain.Items
{
    public abstract class Item
    {
        public Item(Position position)
        {
            Position = position;
        }

        public Position Position { get; }
    }
}