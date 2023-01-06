using System.Linq.Expressions;
using _23_Expression.CustomExpressionVisitor;

namespace _23_Expression.ExpressionExtensions;

public static class OrExpressionExtension
{
    /// <summary>
    /// 将两个相同类型的委托合并为一个，并且两个委托之间的关系表示为或
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> predicate)
    {
        var parameter = Expression.Parameter(typeof(T), "p");
        var parameterVisitor = new ParameterVisitor(parameter);

        var left = parameterVisitor.Replace(expression.Body);
        var right = parameterVisitor.Replace(predicate.Body);

        var body = Expression.Or(left, right);

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}