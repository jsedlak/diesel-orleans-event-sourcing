using Orleans;

namespace Diesel.Orleans.EventSourcing.Tests.Events;

[GenerateSerializer]
public abstract class BankAccountEventBase
{
    protected BankAccountEventBase(Guid accountId)
    {
        AccountId = accountId;
    }
    
    [Id(0)]
    public Guid AccountId { get; set; }
}
