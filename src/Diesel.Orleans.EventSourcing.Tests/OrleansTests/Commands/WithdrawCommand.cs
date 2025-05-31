using Orleans;

namespace Diesel.Orleans.EventSourcing.Tests.Commands;

[GenerateSerializer]
public class WithdrawCommand
{
    [Id(0)]
    public double Amount { get; set; }
}