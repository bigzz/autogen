using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace Microsoft.AutoGen.Abstractions;

public static class MessageExtensions
{
    public static CloudEvent ToCloudEvent<T>(this T message, string source) where T : IMessage
    {
        return new CloudEvent
        {
            ProtoData = Any.Pack(message),
            Type = message.Descriptor.FullName,
            Source = source,
            Id = Guid.NewGuid().ToString()

        };
    }

    public static T FromCloudEvent<T>(this CloudEvent cloudEvent) where T : IMessage, new()
    {
        return cloudEvent.ProtoData.Unpack<T>();
    }
}
