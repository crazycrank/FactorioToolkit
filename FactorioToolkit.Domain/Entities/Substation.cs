using FactorioToolkit.Domain.Entities.CircuitNetwork;
using FactorioToolkit.Domain.Entities.Direction;
using FactorioToolkit.Domain.Entities.ValueObjects;

namespace FactorioToolkit.Domain.Entities
{
    public class Substation : Entity, ICircuitPortSingle
    {
        public Substation(Position position, CircuitConnection input)
            : base(position)
        {
            Input = input;
        }

        public CircuitConnection Input { get; }
    }
}