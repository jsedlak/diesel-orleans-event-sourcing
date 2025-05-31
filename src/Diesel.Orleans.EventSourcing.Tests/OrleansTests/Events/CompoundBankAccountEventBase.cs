namespace Diesel.Orleans.EventSourcing.Tests.Events;

[GenerateSerializer]
public abstract class CompoundBankAccountEventBase
{
    protected CompoundBankAccountEventBase(string accountId)
    {
        AccountId = accountId;
    }
    
    [Id(0)]
    public string AccountId { get; set; }
}