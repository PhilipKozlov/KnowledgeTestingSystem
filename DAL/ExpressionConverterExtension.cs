using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    /// <summary>
    /// Contains static met hods for converting expressions.
    /// </summary>
    internal static class ExpressionConverterExtension
    {
        #region Public Methods
        /// <summary>
        /// Converts expression of one type to another.
        /// </summary>
        /// <typeparam name="TFrom"> Expression type to convert from.</typeparam>
        /// <typeparam name="TTo"> Expression type to convert to.</typeparam>
        /// <param name="from"> Expression instance to convert from.</param>
        /// <returns> Expression converted to specified type.</returns>
        public static Expression<Func<TTo, bool>> Convert<TFrom, TTo>(this Expression<Func<TFrom, bool>> from)
        {
            return ConvertHelper<Func<TFrom, bool>, Func<TTo, bool>>(from);
        }
        #endregion

        #region Private methods
        private static Expression<TTo> ConvertHelper<TFrom, TTo>(Expression<TFrom> from) where TFrom : class where TTo : class
        {
            var fromTypes = typeof(TFrom).GetGenericArguments();
            var toTypes = typeof(TTo).GetGenericArguments();
            var parameterMap = new Dictionary<Expression, Expression>();
            for (int i = 0; i < from.Parameters.Count; i++)
            {
                if (fromTypes[i] != toTypes[i])
                {
                    parameterMap[from.Parameters[i]] = Expression.Parameter(toTypes[i], from.Parameters[i].Name);
                }
            }
            var body = new ConversionVisitor(parameterMap).Visit(from.Body);
            return Expression.Lambda<TTo>(body, parameterMap.Count() == 0 ? from.Parameters.ToArray() : parameterMap.Values.Cast<ParameterExpression>().ToArray());
        }
        #endregion
    }
}
