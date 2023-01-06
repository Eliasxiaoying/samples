using System.Linq.Expressions;

namespace _23_Expression.Mapper;

public static class MapperUtil<TIn, TOut>
{

    private static readonly Dictionary<string, Func<TIn, TOut>> Cache = new();

    static MapperUtil()
    {
        var key = $"{typeof(TIn).FullName}_{typeof(TOut).FullName}";

        var parameter = Expression.Parameter(typeof(TIn), "origin");
        var bindings = new List<MemberBinding>();

        foreach (var prop in typeof(TOut).GetProperties())
        {
            var propertyInfo = typeof(TIn).GetProperty(prop.Name);
            if (propertyInfo == null) continue;

            var assign = Expression.Bind(prop, Expression.Property(parameter, propertyInfo));
            bindings.Add(assign);
        }

        foreach (var field in typeof(TOut).GetFields())
        {
            var fieldInfo = typeof(TIn).GetField(field.Name);
            if (fieldInfo == null) continue;

            var assign = Expression.Bind(field, Expression.Field(parameter, fieldInfo));
            bindings.Add(assign);
        }

        var memberInit = Expression.MemberInit(Expression.New(typeof(TOut)), bindings);
        var lambdaExp = Expression.Lambda<Func<TIn, TOut>>(memberInit, parameter);

        Cache[key] = lambdaExp.Compile();
    }

    public static TOut MapTo(TIn original)
    {
        if (original is null) throw new ArgumentNullException(nameof(original));

        var instance = Activator.CreateInstance<TOut>();

        foreach (var prop in original.GetType().GetProperties())
        {
            var property = typeof(TOut).GetProperty(prop.Name);
            property?.SetValue(instance, prop.GetValue(original));
        }

        foreach (var field in original.GetType().GetFields())
        {
            var fieldInfo = typeof(TOut).GetField(field.Name);
            fieldInfo?.SetValue(instance, field.GetValue(original));
        }

        return instance;
    }

    /// <summary>
    /// 使用表达式目录树实现实体映射
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static TOut ExpressionMapTo(TIn origin)
    {
        var key = $"{typeof(TIn).FullName}_{typeof(TOut).FullName}";
        if (!Cache.ContainsKey(key))
        {
            var parameter = Expression.Parameter(typeof(TIn), "origin");
            var bindings = new List<MemberBinding>();

            foreach (var prop in typeof(TOut).GetProperties())
            {
                var propertyInfo = typeof(TIn).GetProperty(prop.Name);
                if (propertyInfo == null) continue;
                bindings.Add(Expression.Bind(prop, Expression.Property(parameter, propertyInfo)));
            }

            foreach (var field in typeof(TOut).GetFields())
            {
                var fieldInfo = typeof(TIn).GetField(field.Name);
                if (fieldInfo == null) continue;
                bindings.Add(Expression.Bind(field, Expression.Field(parameter, fieldInfo)));
            }

            var memberInit = Expression.MemberInit(Expression.New(typeof(TOut)), bindings);
            var lambdaExp = Expression.Lambda<Func<TIn, TOut>>(memberInit, parameter);

            Cache[key] = lambdaExp.Compile();
        }

        return Cache[key].Invoke(origin);
    }
}