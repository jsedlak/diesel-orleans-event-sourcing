using Microsoft.Extensions.DependencyInjection;
using Diesel.Orleans.EventSourcing.Snapshotting;
using Diesel.Orleans.EventSourcing.Tests.Commands;
using Diesel.Orleans.EventSourcing.Tests.Grains;

namespace Diesel.Orleans.EventSourcing.Tests;

[TestClass]
public class SnapshotAndTruncateTests : OrleansTestBase<SnapshottingTruncatingSiloConfigurator>
{
    [TestMethod]
    public async Task CanSnapshotAndTruncate()
    {
        var bankAccount = Grains.GetGrain<IBankAccountGrain>(Guid.NewGuid());

        var depositBalance = await bankAccount.Deposit(new DepositCommand() { Amount = 2_000 });
        var withdrawBalance = await bankAccount.Withdraw(new WithdrawCommand() { Amount = 1_000 });
        var finalBalance = await bankAccount.GetBalance();

        Assert.AreEqual(2000, depositBalance);
        Assert.AreEqual(finalBalance, withdrawBalance);
    }
}