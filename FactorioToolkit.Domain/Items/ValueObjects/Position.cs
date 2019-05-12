namespace FactorioToolkit.Domain.Items.ValueObjects
{
    public struct Position
    {
        public Position(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }
    }
}