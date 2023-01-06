using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace _11_StateSamples.Extensions;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        var str = JsonSerializer.Serialize(value);
        session.SetString(key, str);
    }

    public static T Get<T>(this ISession session, string key)
    {
        return JsonSerializer.Deserialize<T>(session.GetString(key));
    }

    public static Type Get(this ISession session, string key, Type type)
    {
        return JsonSerializer.Deserialize<Type>(session.GetString(key));
    }
}