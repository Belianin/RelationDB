using System.Collections.Generic;

namespace RelationalDB;

public interface IRelationalDataBase<T>
{
    void Add(T value);
    IEnumerable<T> Scan();
}