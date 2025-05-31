using Diesel.Orleans.EventSourcing.Snapshotting;

namespace Diesel.Orleans.EventSourcing.Tests;

public class SnapshottingTruncatingSiloConfigurator : DefaultSiloConfigurator
{
    public override void Configure(ISiloBuilder siloBuilder)
    {
        base.Configure(siloBuilder);

        siloBuilder.Services.AddPredicatedSnapshotting((type, grainId) => (true, true));
    }
}