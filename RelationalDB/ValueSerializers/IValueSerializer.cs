using System;

namespace RelationalDB.ValueSerializers;

public interface IValueSerializer
{
    byte[] Serialize(object value);
    object Deserialize(ReadOnlySpan<byte> value, out int length);
    
}