using System.Linq.Expressions;

namespace _23_Expression.CustomExpressionVisitor;

/// <summary>
/// 将二元表达式中的加法转换为减法
/// </summary>
public class OperationExpressionVisitor : ExpressionVisitor
{
    public override Expression? Visit(Expression? node)
    {
        return base.Visit(node);
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        if (node.NodeType == ExpressionType.Add)
        {
            var left = this.Visit(node.Left);
            var right = this.Visit(node.Right);

            return Expression.Subtract(left!, right!);
        }
        
        return base.VisitBinary(node);
    }


    protected override Expression VisitConstant(ConstantExpression node)
    {
        if (node.Type == typeof(int))
        {
            return Expression.Constant(Convert.ToInt32(node.Value) + 1, typeof(int));
        }
        return base.VisitConstant(node);
    }
}
