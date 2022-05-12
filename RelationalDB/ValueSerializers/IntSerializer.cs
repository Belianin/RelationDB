using System;

namespace RelationalDB.ValueSerializers;

public class IntSerializer : IValueSerializer
{
    public byte[] Serialize(object value)
    {
        return BitConverter.GetBytes((int) value);
    }

    public object Deserialize(ReadOnlySpan<byte> value, out int length)
    {
        length = 4;
        
        return BitConverter.ToInt32(value[..4]);
    }
}