using System;

namespace RelationalDB.ValueSerializers;

public class GuidValueSerializer : IValueSerializer
{
    public byte[] Serialize(object value)
    {
        return ((Guid) value).ToByteArray();
    }

    public object Deserialize(ReadOnlySpan<byte> value, out int length)
    {
        length = 16;
        
        return new Guid(value[..16]);
    }
}