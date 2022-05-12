using System;

namespace RelationalDB;

public sealed class RowSerializer<T>
{
    private readonly Func<T, byte[]> serialize;
    private readonly Func<byte[], T> deserialize;

    public RowSerializer(Func<T, byte[]> serialize, Func<byte[], T> deserialize)
    {
        this.serialize = serialize;
        this.deserialize = deserialize;
    }

    public byte[] Serialize(T value) => serialize(value);
    public T Deserialize(byte[] value) => deserialize(value);
}