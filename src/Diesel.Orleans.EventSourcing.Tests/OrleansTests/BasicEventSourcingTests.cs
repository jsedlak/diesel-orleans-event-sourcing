using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;
using Diesel.Orleans.EventSourcing.Tests.Commands;
using Diesel.Orleans.EventSourcing.Tests.Grains;

namespace Diesel.Orleans.EventSourcing.Tests;

[TestClass]
public class BasicEventSourcingTests : OrleansTestBase<DefaultSiloConfigurator>
{
    [TestMethod]
    public async Task CanStoreEvents()
    {
        var bankAccount = Grains.GetGrain<IBankAccountGrain>(Guid.NewGuid());

        var depositBalance = await bankAccount.Deposit(new DepositCommand() { Amount = 2_000 });
        var withdrawBalance = await bankAccount.Withdraw(new WithdrawCommand() { Amount = 1_000 });
        var finalBalance = await bankAccount.GetBalance();

        Assert.AreEqual(2000, depositBalance);
        Assert.AreEqual(finalBalance, withdrawBalance);
    }

    [TestMethod]
    public async Task CanStoreEventsWithStringKey()
    {
        var bankAccount = Grains.GetGrain<ICompoundKeyAccountGrain>("helloworld1234");

        var depositBalance = await bankAccount.Deposit(new DepositCommand() { Amount = 2_000 });
        var withdrawBalance = await bankAccount.Withdraw(new WithdrawCommand() { Amount = 1_000 });
        var finalBalance = await bankAccount.GetBalance();

        Assert.AreEqual(2000, depositBalance);
        Assert.AreEqual(finalBalance, withdrawBalance);
    }

    [TestMethod]
    public async Task CanDelayLogWrite()
    {
        var bankAccount = Grains.GetGrain<IDelayedBankAccountGrain>(Guid.NewGuid());

        var depositBalance = await bankAccount.Deposit(new DepositCommand() { Amount = 2_000 });
        var withdrawBalance = await bankAccount.Withdraw(new WithdrawCommand() { Amount = 1_000 });
        var finalBalance = await bankAccount.GetBalance();

        Assert.AreEqual(2000, depositBalance);
        Assert.AreEqual(finalBalance, withdrawBalance);
    }
}