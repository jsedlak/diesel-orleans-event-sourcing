using Diesel.Orleans.EventSourcing.Tests.Commands;

namespace Diesel.Orleans.EventSourcing.Tests.Grains;

public interface IDelayedBankAccountGrain : IGrainWithGuidKey
{
    ValueTask<double> Deposit(DepositCommand command);

    ValueTask<double> Withdraw(WithdrawCommand command);

    ValueTask<double> GetBalance();

    ValueTask<double> GetConfirmedBalance();
}