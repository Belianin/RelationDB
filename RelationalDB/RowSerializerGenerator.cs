using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RelationalDB.ValueSerializers;

namespace RelationalDB;

public static class RowSerializerGenerator
{
    private static Dictionary<Type, IValueSerializer> AllowedTypes = new() {
        [typeof(Guid)] = new GuidValueSerializer(),
        [typeof(string)] = new StringValueSerializer(),
        [typeof(int)] = new IntSerializer()
    };
    
    public static RowSerializer<T> Generate<T>()
    {
        var members = typeof(T)
            .GetMembers()
            .Where(x => x.MemberType == MemberTypes.Field)
            .Where(x => AllowedTypes.ContainsKey(x.GetMemberType()))
            .OrderBy(x => x.Name)
            .ToArray();

        byte[] Serialize(T value)
        { 
            var result = new List<byte>();
            foreach (var memberInfo in members)
            {
                var memberValue = memberInfo.GetMemberValue(value);

                var serializedValue = AllowedTypes[memberInfo.GetMemberType()].Serialize(memberValue);
                
                result.AddRange(serializedValue);
            }

            return result.ToArray();
        }
        
        T Deserialize(byte[] valueArray)
        {
            var value = valueArray.AsSpan();
            var result = Activator.CreateInstance<T>();

            var index = 0;
            foreach (var memberInfo in members)
            {
                var serializer = AllowedTypes[memberInfo.GetMemberType()];
                var memberValue = serializer.Deserialize(value[index..], out var length);
                index += length;
                
                memberInfo.SetMemberValue(result, memberValue);
            }
            
            return result;
        }


        return new RowSerializer<T>(Serialize, Deserialize);
    }
}