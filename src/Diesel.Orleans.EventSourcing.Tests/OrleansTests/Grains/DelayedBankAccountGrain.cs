using Diesel.Orleans.EventSourcing.Tests.Commands;
using Diesel.Orleans.EventSourcing.Tests.Events;
using Diesel.Orleans.EventSourcing.Tests.Model;

namespace Diesel.Orleans.EventSourcing.Tests.Grains;

// Delay log writes for 2 seconds to simulate a delayed event store write
[PersistTimer(2)]
public class DelayedBankAccountGrain : EventSourcedGrain<BankAccount, BankAccountEventBase>, IDelayedBankAccountGrain
{
    public ValueTask<double> Deposit(DepositCommand command)
    {
        Raise(new AmountDepositedEvent(this.GetPrimaryKey())
        {
            Amount = command.Amount
        });

        return ValueTask.FromResult(TentativeState.Balance);
    }

    public ValueTask<double> Withdraw(WithdrawCommand command)
    {
        var amount = command.Amount;
        if (amount > TentativeState.Balance)
        {
            amount = TentativeState.Balance;
        }

        Raise(new AmountWithdrawnEvent(this.GetPrimaryKey())
        {
            Amount = amount
        });
        
        return ValueTask.FromResult(TentativeState.Balance);
    }

    public ValueTask<double> GetBalance()
    {
        return ValueTask.FromResult(TentativeState.Balance);
    }

    public ValueTask<double> GetConfirmedBalance()
    {
        return ValueTask.FromResult(ConfirmedState.Balance);
    }
}