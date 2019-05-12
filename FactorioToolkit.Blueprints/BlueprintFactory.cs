using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using FactorioToolkit.Domain.Items;
using FactorioToolkit.Domain.Items.Belts;
using FactorioToolkit.Domain.Items.CircuitNetwork;
using FactorioToolkit.Domain.Items.Inserters;
using FactorioToolkit.Domain.Items.Pipes;
using FactorioToolkit.Infrastructure.Exceptions;
using FactorioToolkit.Infrastructure.Model;
using FactorioToolkit.Infrastructure.Model.Connection;
using FactorioToolkit.Infrastructure.Repositories;

using Blueprint = FactorioToolkit.Domain.Blueprint;
using BlueprintBook = FactorioToolkit.Domain.BlueprintBook;

namespace FactorioToolkit.Infrastructure
{

    public class BlueprintFactory
    {
        private readonly IItemInfrastructureRepository itemRepository;

        public BlueprintFactory(IItemInfrastructureRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public BlueprintBook GetBlueprintBook(Model.BlueprintBook blueprintBook)
            => new BlueprintBook(blueprintBook.Label,
                                 blueprintBook.Blueprints.Select(t => GetBlueprint(t.blueprint)).ToList());



        public Blueprint GetBlueprint(Model.Blueprint blueprint)
        {
            var items = new List<Item>();
            var itemsWithConnections = new List<(Entity entity, ICircuitInput item)>();

            foreach (var entity in blueprint.Entities)
            {
                try
                {
                    var item = GetItem(entity);
                    itemRepository.AddItem(entity.EntityId, item);
                    items.Add(item);

                    if (item is ICircuitInput circuitInput)
                    {
                        itemsWithConnections.Add((entity, circuitInput));
                    }
                }
                catch (NotImplementedException)
                    when (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
            // TODO: Must be a bug in the Code-Flow-Analysis. Fix in Roslyn?
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type. 
            foreach (var (entity, item) in itemsWithConnections)
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
            {
                foreach (var connectionData in entity.Connections?.Default.Green ?? new ConnectionData[0])
                {
                    item.Input.Green.AddConnection(itemRepository.GetItem(connectionData.EntityId));
                }

                foreach (var connectionData in entity.Connections?.Default.Red ?? new ConnectionData[0])
                {
                    item.Input.Green.AddConnection(itemRepository.GetItem(connectionData.EntityId));
                }

            }

            return new Blueprint(blueprint.Label, items);
        }

        public Item GetItem(Entity entity)
            => entity switch
                   {
                   { Position: var p, Name: "storage-tank", Direction: var d }
                   => new StorageTank(p.ToDomainValue(),
                                      d.ToDomainValue(),
                                      new CircuitAccessPoint()),
                   { Position: var p, Name: "steam-turbine", Direction: var d }
                   => new StorageTank(p.ToDomainValue(),
                                      d.ToDomainValue(),
                                      new CircuitAccessPoint()),
                   { Position: var p, Name: "small-lamp" }
                   => new SmallLamp(p.ToDomainValue()),
                   { Position: var p, Name: "nuclear-reactor" }
                   => new NuclearReactor(p.ToDomainValue()),
                   { Position: var p, Name: "heat-exchanger" }
                   => new HeatExchanger(p.ToDomainValue()),
                   { Position: var p, Name: "substation" }
                   => new Substation(p.ToDomainValue(),
                                     new CircuitAccessPoint()),

                   // pipes
                   { Position: var p, Name: "pipe" }
                   => (Item)new Pipe(p.ToDomainValue()),
                   { Position: var p, Name: "pipe-to-ground", Direction: var d }
                   => new PipeToGround(p.ToDomainValue(),
                                       d.ToDomainValue()),
                   { Position: var p, Name: "heat-pipe" }
                   => new HeatPipe(p.ToDomainValue()),

                   // belts
                   { Position: var p, Name: "transport-belt", Direction: var d }
                   => new TransportBelt(p.ToDomainValue(),
                                        d.ToDomainValue(),
                                        new CircuitAccessPoint()),
                   { Position: var p, Name: "fast-transport-belt", Direction: var d }
                   => new FastTransportBelt(p.ToDomainValue(),
                                            d.ToDomainValue(),
                                            new CircuitAccessPoint()),
                   { Position: var p, Name: "express-transport-belt", Direction: var d }
                   => new ExpressTransportBelt(p.ToDomainValue(),
                                               d.ToDomainValue(),
                                               new CircuitAccessPoint()),

                   // underground belts
                   { Position: var p, Name: "underground-belt", Direction: var d, UndergroundBeltType: var beltType }
                   => new UndergroundBelt(p.ToDomainValue(),
                                          d.ToDomainValue(),
                                          new CircuitAccessPoint(),
                                          beltType!.ParseBeltValue()),
                   { Position: var p, Name: "fast-underground-belt", Direction: var d, UndergroundBeltType: var beltType }
                   => new FastUndergroundBelt(p.ToDomainValue(),
                                              d.ToDomainValue(),
                                              new CircuitAccessPoint(),
                                              beltType!.ParseBeltValue()),
                   { Position: var p, Name: "express-underground-belt", Direction: var d, UndergroundBeltType: var beltType }
                   => new ExpressUndergroundBelt(p.ToDomainValue(),
                                                 d.ToDomainValue(),
                                                 new CircuitAccessPoint(),
                                                 beltType!.ParseBeltValue()),

                   // splitters
                   { Position: var p, Name: "splitter", Direction: var d, InputPriority: var inputPriority, OutputPriority: var outputPriority }
                   => new Splitter(p.ToDomainValue(),
                                   d.ToDomainValue(),
                                   new CircuitAccessPoint(),
                                   inputPriority!.ParseSplitterPriority(),
                                   outputPriority!.ParseSplitterPriority()),
                   { Position: var p, Name: "fast-splitter", Direction: var d, InputPriority: var inputPriority, OutputPriority: var outputPriority }
                   => new FastSplitter(p.ToDomainValue(),
                                       d.ToDomainValue(),
                                       new CircuitAccessPoint(),
                                       inputPriority!.ParseSplitterPriority(),
                                       outputPriority!.ParseSplitterPriority()),
                   { Position: var p, Name: "express-splitter", Direction: var d, InputPriority: var inputPriority, OutputPriority: var outputPriority }
                   => new ExpressSplitter(p.ToDomainValue(),
                                          d.ToDomainValue(),
                                          new CircuitAccessPoint(),
                                          inputPriority!.ParseSplitterPriority(),
                                          outputPriority!.ParseSplitterPriority()),

                   // inserters
                   { Position: var p, Name: "inserter", Direction: var d, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(),
                                   d.ToDomainValue(),
                                   new CircuitAccessPoint(),
                                   ConversionHelpers.ToDomainValue(b),
                                   overrideStackSize),
                   { Position: var p, Name: "burner-inserter", Direction: var d, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(),
                                   d.ToDomainValue(),
                                   new CircuitAccessPoint(),
                                   ConversionHelpers.ToDomainValue(b),
                                   overrideStackSize),
                   { Position: var p, Name: "fast-inserter", Direction: var d, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(),
                                   d.ToDomainValue(),
                                   new CircuitAccessPoint(),
                                   ConversionHelpers.ToDomainValue(b),
                                   overrideStackSize),
                   { Position: var p, Name: "stack-inserter", Direction: var d, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(),
                                   d.ToDomainValue(),
                                   new CircuitAccessPoint(),
                                   ConversionHelpers.ToDomainValue(b),
                                   overrideStackSize),
                   { Position: var p, Name: "filter-inserter", Direction: var d, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(),
                                   d.ToDomainValue(),
                                   new CircuitAccessPoint(),
                                   ConversionHelpers.ToDomainValue(b),
                                   overrideStackSize),
                   { Position: var p, Name: "stack-filter-inserter", Direction: var d, ControlBehaviour: var b, OverrideStackSize: var overrideStackSize }
                   => new Inserter(p.ToDomainValue(),
                                   d.ToDomainValue(),
                                   new CircuitAccessPoint(),
                                   ConversionHelpers.ToDomainValue(b),
                                   overrideStackSize),
                   { Name: var name } => throw new NotImplementedException($"entity '{name}' not yet implemented"),
                   };
    }
}
