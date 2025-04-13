namespace Diesel.Orleans.EventSourcing;

public interface IStateSerializer
{
    BinaryData Serialize<TView>(TView data);
    
    TView Deserialize<TView>(byte[] data);
}