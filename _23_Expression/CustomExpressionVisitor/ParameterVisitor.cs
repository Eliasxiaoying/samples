using System.Linq.Expressions;

namespace _23_Expression.CustomExpressionVisitor;

/// <summary>
/// 参数访问器，用于将两个相同对象的不同参数合并为一个参数
/// </summary>
public class ParameterVisitor : ExpressionVisitor
{
    /// <summary>
    /// 用于替换参数的参数表达式
    /// </summary>
    private readonly ParameterExpression parameter;

    /// <summary>
    /// 创建参数访问器时传入，将两个相同对象的不同参数合并为一个参数
    /// </summary>
    /// <param name="parameter"></param>
    public ParameterVisitor(ParameterExpression parameter)
    {
        this.parameter = parameter;
    }

    /// <summary>
    /// 调用访问方法，可以替换掉参数
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public Expression Replace(Expression expression)
    {
        return this.Visit(expression);
    }

    /// <summary>
    /// 重写了父类的VisitParameter方法，将表达式的参数替换为指定的参数
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected override Expression VisitParameter(ParameterExpression node)
    {
        return this.parameter;
    }
}