using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using EasyTemplateCore.Data;
using EasyTemplateCore.Dtos;
using EasyTemplateCore.Dtos.Location.Country;
using EasyTemplateCore.Entities.Location;
using EasyTemplateCore.Services.Location.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace EasyTemplateCore.Services.Tests
{
    public class BaseServiceTest
    {
        protected static IServiceProvider ServiceProvider;

        [SetUp]
        public static void AssemblyInit()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(_ =>
            {
                return new ConfigurationBuilder()
                    .AddInMemoryCollection(new[]
                    {
                        new KeyValuePair<string,string>("UseInMemoryDatabase", "true"),
                    })
                    .Build();
            });


            services.AddEntityFrameworkInMemoryDatabase().AddDbContext<EasyTemplateCoreContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseInMemoryDatabase("EasyTemplateCore_Core_Test_Db")
                    .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
            services.AddScoped<IUnitOfWork, EasyTemplateCoreContext>();

            services.Scan(scan => scan
                .FromAssemblyOf<ICountryService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            ServiceProvider = services.BuildServiceProvider();

            var configuration =
                new MapperConfiguration(cfg =>
                    cfg.AddMaps(
                        Assembly.GetAssembly(typeof(CountryProfile))
                    ));
            AutoMapperConfiguration.Init(configuration);

            LoadInitEntities();
        }

        #region Country

        protected static Country CountryIran = new Country
        {
            Id = Guid.NewGuid(),
            CountryNo = 1,
            CountryName = "Iran",
            CountryAbbr = "IRN",
            Remark = null
        };

        #endregion
        private static void LoadInitEntities()
        {

            #region ProductType

            using (var serviceScope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var uow = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                {
                    uow.Set<Country>().AddRange(CountryIran);
                    uow.SaveChanges();
                }
            }

            #endregion
        }

        protected void ScopeContext<T>(Action<IUnitOfWork, T> callback)
        {
            using (var serviceScope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                {
                    callback(context, serviceScope.ServiceProvider.GetRequiredService<T>());
                }
            }
        }
    }
}
