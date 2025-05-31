using Diesel.Orleans.EventSourcing;
using Diesel.Orleans.EventSourcing.Tests.Commands;
using Diesel.Orleans.EventSourcing.Tests.Events;
using Diesel.Orleans.EventSourcing.Tests.Model;

namespace Diesel.Orleans.EventSourcing.Tests.Grains;

[PersistTimer(30*1000)]
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
}