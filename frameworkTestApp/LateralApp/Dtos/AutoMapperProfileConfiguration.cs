using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using LateralApp.Dtos.Location.Country;

namespace LateralApp.Dtos
{
    /// <summary>
    /// Configure models to dommain classes
    /// </summary>
    public static class AutoMapperProfileConfiguration
    {

        /// <summary>
        ///  Get all Automapper Profiles 
        /// </summary>
        /// <remarks>
        /// for Ignore map : .ForMember(des => des.RowVersion, op => op.Ignore())
        /// </remarks>
        public static List<Type> GetConfigureTypes()
        {
            var typesToRegisterAsm = Assembly.GetAssembly(typeof(CountryProfile));

            return typesToRegisterAsm?.GetTypes()
                .Where(type => type
                    .BaseType?
                    .IsGenericType == false &&
                               type.BaseType == typeof(Profile))
                .ToList();
        }
    }
}
