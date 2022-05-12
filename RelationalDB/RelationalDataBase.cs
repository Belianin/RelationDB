using System.Collections.Generic;

namespace RelationalDB;

public class RelationalDataBase<T> : IRelationalDataBase<T>
{
    public void Add(T value)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<T> Scan()
    {
        throw new System.NotImplementedException();
    }
}