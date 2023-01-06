using System.Linq.Expressions;
using _23_Expression.CustomExpressionVisitor;

namespace _23_Expression.ExpressionExtensions;

public static class AndAlsoExpressionExtension
{
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> predicate)
    {
        // 创建一个用于替换两个相同类型委托的参数和对应的访问器
        var parameter = Expression.Parameter(typeof(T), "p");
        var parameterVisitor = new ParameterVisitor(parameter);

        // 使用访问器访问表达式，将两个表达式的左右替换为相同的参数
        var left = parameterVisitor.Replace(expression.Body);
        var right = parameterVisitor.Replace(predicate.Body);

        // 将左右两个表达式合并为And
        var body = Expression.And(left, right);
        
        // 返回一个新创建的表达式，其中参数已经替换为了p
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
    
    public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> predicate)
    {
        // 创建一个用于替换两个相同类型委托的参数和对应的访问器
        var parameter = Expression.Parameter(typeof(T), "p");
        var parameterVisitor = new ParameterVisitor(parameter);

        // 使用访问器访问表达式，将两个表达式的左右替换为相同的参数
        var left = parameterVisitor.Replace(expression.Body);
        var right = parameterVisitor.Replace(predicate.Body);

        // 将左右两个表达式合并为AndAlso
        var body = Expression.AndAlso(left, right);
        
        // 返回一个新创建的表达式，其中参数已经替换为了p
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}