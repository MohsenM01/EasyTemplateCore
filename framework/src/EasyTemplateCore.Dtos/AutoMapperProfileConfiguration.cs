using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using EasyTemplateCore.Dtos.Location.Country;

namespace EasyTemplateCore.Dtos
{
    /// <summary>
    /// Configure models to dommain classes
    /// </summary>
    public static class AutoMapperProfileConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// for Ignore map : .ForMember(des => des.RowVersion, op => op.Ignore())
        /// </remarks>
        public static List<Type> GetConfigureTypes()
        {
            var typesToRegisterAsm = Assembly.GetAssembly(typeof(CountryProfile));

            var configurations = typesToRegisterAsm?.GetTypes()
                .Where(type => type.BaseType != null &&
                               !type.BaseType.IsGenericType &&
                               type.BaseType == typeof(Profile))
                .ToList();
            return configurations;
        }

    }
}
