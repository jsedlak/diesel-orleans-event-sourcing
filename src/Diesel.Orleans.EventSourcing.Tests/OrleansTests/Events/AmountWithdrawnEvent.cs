using Orleans;

namespace Diesel.Orleans.EventSourcing.Tests.Events;

[GenerateSerializer]
public sealed class AmountWithdrawnEvent : BankAccountEventBase
{
    public AmountWithdrawnEvent(Guid accountId) 
        : base(accountId)
    {
    }
    
    [Id(0)]
    public double Amount { get; set; }
}
