using System;
using System.Linq;
using System.Text;

namespace RelationalDB.ValueSerializers;

public class StringValueSerializer : IValueSerializer
{
    public byte[] Serialize(object value)
    {
        var bytes = Encoding.UTF8.GetBytes((string) value);
        
        return BitConverter.GetBytes(bytes.Length)
            .Concat(bytes)
            .ToArray();
    }

    public object Deserialize(ReadOnlySpan<byte> value, out int length)
    {
        var count = BitConverter.ToInt32(value[..4]);
        length = count + 4;
        
        return Encoding.UTF8.GetString(value.Slice(4, count));
    }
}