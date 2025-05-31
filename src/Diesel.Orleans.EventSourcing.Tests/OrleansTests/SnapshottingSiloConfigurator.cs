using Diesel.Orleans.EventSourcing.Snapshotting;

namespace Diesel.Orleans.EventSourcing.Tests;

public class SnapshottingSiloConfigurator : DefaultSiloConfigurator
{
    public override void Configure(ISiloBuilder siloBuilder)
    {
        base.Configure(siloBuilder);

        siloBuilder.Services.AddPredicatedSnapshotting((type, grainId) => (true, false));
    }
}