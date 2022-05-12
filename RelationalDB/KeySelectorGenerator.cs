using System;
using System.Linq;
using System.Reflection;

namespace RelationalDB;

public delegate dynamic KeySelector<in T>(T value);

public static class KeySelectorGenerator
{
    public static KeySelector<T> Generate<T>()
    {
        var key = typeof(T)
            .GetMembers()
            .FirstOrDefault(t => Attribute.IsDefined(t, typeof(KeyAttribute)));

        if (key == null)
            throw new InvalidOperationException($"{typeof(KeyAttribute)} is not found on any {typeof(T)}'s members");

        var keyType = key.DeclaringType!;

        return key switch
        {
            FieldInfo fieldInfo => x => fieldInfo.GetValue(x),
            PropertyInfo propertyInfo => x => propertyInfo.GetValue(x)
        };
    }
}