using Orleans.TestingHost;
using Diesel.Orleans.EventSourcing;

namespace Diesel.Orleans.EventSourcing.Tests;

public class DefaultSiloConfigurator : ISiloConfigurator
{
    public virtual void Configure(ISiloBuilder siloBuilder)
    {
        siloBuilder.Services.AddOrleansSerializers();
        siloBuilder.Services.AddMemoryEventSourcing();
        siloBuilder.UseInMemoryReminderService();
    }
}