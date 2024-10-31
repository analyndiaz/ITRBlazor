using System.Linq.Expressions;

namespace Evolve.ITR.Infrastructure.DataAccess.Extensions
{
    public static class FilterExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> filter, Expression<Func<T, bool>> newFilter)
        {
            var secondBody = newFilter.Body.Replace(newFilter.Parameters[0], filter.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(filter.Body, secondBody), filter.Parameters);
        }

        public static Expression Replace(this Expression expression, Expression searchEx, Expression replaceEx)
        {
            return new ReplaceVisitor(searchEx, replaceEx).Visit(expression);
        }
    }

    internal class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public ReplaceVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
}
