using Diesel.Orleans.EventSourcing.Tests.Events;

namespace Diesel.Orleans.EventSourcing.Tests.Model;

public sealed class BankAccount
{    
    public double Balance { get; set; }

    public void Apply(AmountDepositedEvent @event)
    {
        Balance += @event.Amount;
    }

    public void Apply(AmountWithdrawnEvent @event)
    {
        Balance -= @event.Amount;
    }
}
