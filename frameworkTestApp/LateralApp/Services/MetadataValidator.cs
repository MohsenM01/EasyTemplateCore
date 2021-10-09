using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using CSharpFunctionalExtensions;

namespace LateralApp.Services
{
    /// <summary>
    /// Extentions for validate Metadata to entities
    /// </summary>
    public static class MetadataValidator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result<bool, List<string>> IsValid<T>(this T obj)
        {
            var errors = new List<string>();
            dynamic validationContext = new ValidationContext(obj, null, null);
            dynamic validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(obj, validationContext, validationResults, true);

            foreach (ValidationResult var in validationResults)
            {
                errors.Add(var.ErrorMessage);
            }

            if (errors.Count == 0)
            {
                return Result.Success<bool, List<string>>(true);
            }
            return Result.Failure<bool, List<string>>(errors);
        }

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
