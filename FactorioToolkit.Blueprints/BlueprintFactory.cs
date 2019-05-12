using FactorioToolkit.Domain.Entities;
using FactorioToolkit.Domain.Entities.Direction;
using FactorioToolkit.Domain.Entities.Pipes;
using System;
using System.Reflection.Emit;

using FactorioToolkit.Domain.Entities.Belts;
using FactorioToolkit.Domain.Entities.Inserters;

namespace FactorioToolkit.Blueprints
{
    public class BlueprintFactory
    {
        public Entity GetDomainEntity(Model.JsonEntity entity)
            => entity switch
                   {
                   { Position: var p, Name: "storage-tank", Direction: var d, Connections: var c }
                   => new StorageTank(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue()),
                   { Position: var p, Name: "steam-turbine", Direction: var d, Connections: var c }
                   => new StorageTank(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue()),
                   { Position: var p, Name: "small-lamp" }
                   => new SmallLamp(p.ToDomainValue()),
                   { Position: var p, Name: "nuclear-reactor" }
                   => new NuclearReactor(p.ToDomainValue()),
                   { Position: var p, Name: "heat-exchanger" }
                   => new HeatExchanger(p.ToDomainValue()),
                   { Position: var p, Name: "substation", Connections: var c }
                   => new Substation(p.ToDomainValue(), (c?.Default).ToDomainValue()),

                       // pipes
                       { Position: var p, Name: "pipe" } => (Entity)new Pipe(p.ToDomainValue()),
                   { Position: var p, Name: "pipe-to-ground", Direction: var d } => new PipeToGround(p.ToDomainValue(), d.ToDomainValue()),
                   { Position: var p, Name: "heat-pipe" } => new HeatPipe(p.ToDomainValue()),

                   // belts
                   { Position: var p, Name: "transport-belt", Direction: var d, Connections: var c }
                   => new TransportBelt(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue()),
                   { Position: var p, Name: "fast-transport-belt", Direction: var d, Connections: var c }
                   => new FastTransportBelt(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue()),
                   { Position: var p, Name: "express-transport-belt", Direction: var d, Connections: var c }
                   => new ExpressTransportBelt(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue()),

                   // underground belts
                   { Position: var p, Name: "underground-belt", Direction: var d, Connections: var c, UndergroundBeltType: var beltType }
                   => new UndergroundBelt(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), beltType.ParseBeltValue()),
                   { Position: var p, Name: "fast-underground-belt", Direction: var d, Connections: var c, UndergroundBeltType: var beltType }
                   => new FastUndergroundBelt(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), beltType.ParseBeltValue()),
                   { Position: var p, Name: "express-underground-belt", Direction: var d, Connections: var c, UndergroundBeltType: var beltType }
                   => new ExpressUndergroundBelt(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), beltType.ParseBeltValue()),

                   // splitters
                   { Position: var p, Name: "splitter", Direction: var d, Connections: var c, InputPriority: var inputPriority, OutputPriority: var outputPriority }
                   => new Splitter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), inputPriority.ParseSplitterPriority(), outputPriority.ParseSplitterPriority()),
                   { Position: var p, Name: "fast-splitter", Direction: var d, Connections: var c, InputPriority: var inputPriority, OutputPriority: var outputPriority }
                   => new FastSplitter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), inputPriority.ParseSplitterPriority(), outputPriority.ParseSplitterPriority()),
                   { Position: var p, Name: "express-splitter", Direction: var d, Connections: var c, InputPriority: var inputPriority, OutputPriority: var outputPriority }
                   => new ExpressSplitter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), inputPriority.ParseSplitterPriority(), outputPriority.ParseSplitterPriority()),

                       // inserters
                   { Position: var p, Name: "inserter", Direction: var d, Connections: var c, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), b.ToDomainValue(), overrideStackSize),
                   { Position: var p, Name: "burner-inserter", Direction: var d, Connections: var c, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), b.ToDomainValue(), overrideStackSize),
                   { Position: var p, Name: "fast-inserter", Direction: var d, Connections: var c, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), b.ToDomainValue(), overrideStackSize),
                   { Position: var p, Name: "stack-inserter", Direction: var d, Connections: var c, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), b.ToDomainValue(), overrideStackSize),
                   { Position: var p, Name: "filter-inserter", Direction: var d, Connections: var c, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), b.ToDomainValue(), overrideStackSize),
                   { Position: var p, Name: "stack-filter-inserter", Direction: var d, Connections: var c, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(), d.ToDomainValue(), (c?.Default).ToDomainValue(), b.ToDomainValue(), overrideStackSize),

                       { Name: var name } => throw new NotImplementedException($"entity '{name}' not yet implemented"),
                   };
    }
}
