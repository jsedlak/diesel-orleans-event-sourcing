using Diesel.Orleans.EventSourcing.Tests.Commands;

namespace Diesel.Orleans.EventSourcing.Tests.Grains;

public interface ICompoundKeyAccountGrain : IGrainWithStringKey
{
    public ValueTask<double> Deposit(DepositCommand command);

    public ValueTask<double> Withdraw(WithdrawCommand command);
    
    public ValueTask<double> GetBalance();
}