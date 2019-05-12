using System;
using System.Collections;
using System.Collections.Generic;

namespace FactorioToolkit.Domain
{
    public class BlueprintBook
    {
        public string Name { get; set; }
        IList<Blueprint> Blueprints { get; set; } = new List<Blueprint>();
    }
}
