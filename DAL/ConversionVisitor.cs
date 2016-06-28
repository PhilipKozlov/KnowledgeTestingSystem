using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DAL
{
    /// <summary>
    /// Represents a visitor or rewriter for expression trees.
    /// </summary>
    internal class ConversionVisitor : ExpressionVisitor
    {
        #region Fields
        private readonly Dictionary<Expression, Expression> parameterMap;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates ConversionVisitor with specified parameters.
        /// </summary>
        /// <param name="parameterMap"> Parameter mapping.</param>
        public ConversionVisitor(Dictionary<Expression, Expression> parameterMap)
        {
            this.parameterMap = parameterMap;
        }
        #endregion

        #region Protected Methods
        protected override Expression VisitParameter(ParameterExpression node)
        {
            Expression found;
            if (!parameterMap.TryGetValue(node, out found))
                found = base.VisitParameter(node);
            return found;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            var expr = Visit(node.Expression);
            if (expr.Type != node.Expression.Type)
            {
                MemberInfo newMember = expr.Type.GetMember(node.Member.Name).Single();
                return Expression.MakeMemberAccess(expr, newMember);
            }
            return base.VisitMember(node);
        }
        #endregion
    }
}
