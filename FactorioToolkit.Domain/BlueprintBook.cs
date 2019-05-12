using System.Collections.Generic;

namespace FactorioToolkit.Domain
{
    public class BlueprintBook
    {
        public BlueprintBook(string name, IList<Blueprint> blueprints)
        {
            Name = name;
            Blueprints = blueprints;
        }

        public string Name { get; }
        public IList<Blueprint> Blueprints { get; }
    }
}
