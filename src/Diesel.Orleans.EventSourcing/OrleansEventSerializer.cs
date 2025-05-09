using Orleans.Storage;

namespace Diesel.Orleans.EventSourcing;

public class OrleansEventSerializer : IEventSerializer
{
    private readonly IGrainStorageSerializer _storageSerializer;

    public OrleansEventSerializer(IGrainStorageSerializer storageSerializer)
    {
        _storageSerializer = storageSerializer;
    }
    
    public BinaryData Serialize<TEvent>(TEvent data)
    {
        return _storageSerializer.Serialize(data);
    }

    public TEvent Deserialize<TEvent>(byte[] data)
    {
        return _storageSerializer.Deserialize<TEvent>(data);
    }
}