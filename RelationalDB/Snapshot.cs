using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RelationalDB;

public class Snapshot<T>
{
    private readonly KeySelector<T> keySelector;

    public Snapshot()
    {
        keySelector = KeySelectorGenerator.Generate<T>();
    }
    // int Size { get; set; }
    // void Save(T value);
    // IEnumerable<T> Scan();
}