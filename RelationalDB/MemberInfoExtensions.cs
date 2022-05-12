using System;
using System.Reflection;

namespace RelationalDB;

public static class MemberInfoExtensions
{
    public static Type GetMemberType(this MemberInfo memberInfo)
    {
        if (memberInfo is FieldInfo fieldInfo)
            return fieldInfo.FieldType;
        return ((PropertyInfo) memberInfo).PropertyType;
    }

    public static object GetMemberValue(this MemberInfo memberInfo, object obj)
    {
        if (memberInfo is FieldInfo fieldInfo)
            return fieldInfo.GetValue(obj);
        return ((PropertyInfo) memberInfo).GetValue(obj);
    }
    
    public static void SetMemberValue(this MemberInfo memberInfo, object obj, object value)
    {
        if (memberInfo is FieldInfo fieldInfo)
            fieldInfo.SetValue(obj, value);
        else
            ((PropertyInfo) memberInfo).SetValue(obj, value);
    }
}