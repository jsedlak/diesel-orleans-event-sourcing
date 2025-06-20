using Diesel.Orleans.EventSourcing.Tests.Commands;
using Diesel.Orleans.EventSourcing.Tests.Events;
using Diesel.Orleans.EventSourcing.Tests.Model;

namespace Diesel.Orleans.EventSourcing.Tests.Grains;

public class CompoundKeyAccountGrain : 
    EventSourcedGrain<StringKeyBankAccount, CompoundBankAccountEventBase>, 
    ICompoundKeyAccountGrain
{
    public ValueTask<double> Deposit(DepositCommand command)
    {
        Raise(new CompoundKeyAmountDepositedEvent(this.GetPrimaryKeyString())
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
        Raise(new CompoundKeyAmountWithdrawnEvent(this.GetPrimaryKeyString())
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