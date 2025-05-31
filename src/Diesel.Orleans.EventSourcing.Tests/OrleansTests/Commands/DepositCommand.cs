using Orleans;

namespace Diesel.Orleans.EventSourcing.Tests.Commands;

[GenerateSerializer]
public class DepositCommand
{
    [Id(0)]
    public double Amount { get; set; }
}