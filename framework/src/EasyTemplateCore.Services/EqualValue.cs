using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyTemplateCore.Services
{
    /// <summary>
    /// 
    /// </summary>
    public static class EqualValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static bool ValueEquals<T>(T x, T y, params Expression<Func<T, object>>[] expressions) where T : class
        {
            //if (x == null || y == null || x.GetType() == y.GetType()) return x == y;

            var type = x.GetType();

            var comparableProperties = new List<string>(expressions.Length);
            comparableProperties.AddRange(expressions.Select(expression => expression.PropertyName()));
            var objectProperties = type.GetProperties();

            var relevantProperties = objectProperties.Where(propertyInfo => comparableProperties.Contains(propertyInfo.Name));

            foreach (var propertyInfo in relevantProperties)
            {
                //var xPropertyValue = type.GetProperty(propertyInfo.Name).GetValue(x, null);
                var xPropertyValue = type.GetProperties().First(p => p.Name == propertyInfo.Name).GetValue(x, null);

                //var yPropertyValue = type.GetProperty(propertyInfo.Name).GetValue(y, null);
                var yPropertyValue = type.GetProperties().First(p => p.Name == propertyInfo.Name).GetValue(y, null);

                if (xPropertyValue != yPropertyValue && (xPropertyValue == null || !xPropertyValue.Equals(yPropertyValue)))
                {
                    return false;
                }

            }
            return true;
        }
    }
}
