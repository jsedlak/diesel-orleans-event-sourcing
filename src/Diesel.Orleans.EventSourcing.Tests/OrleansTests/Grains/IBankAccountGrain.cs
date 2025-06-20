using Orleans;
using Diesel.Orleans.EventSourcing.Tests.Commands;

namespace Diesel.Orleans.EventSourcing.Tests.Grains;

public interface IBankAccountGrain : IGrainWithGuidKey
{
    public ValueTask<double> Deposit(DepositCommand command);

    public ValueTask<double> Withdraw(WithdrawCommand command);

    public ValueTask<double> GetBalance();
}
