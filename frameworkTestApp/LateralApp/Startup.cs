using System.Reflection;
using AutoMapper;
using LateralApp.Data;
using LateralApp.Dtos;
using LateralApp.Dtos.Location.Country;
using LateralApp.Grpc.Client.Country;
using LateralApp.Http;
using LateralApp.Services.Location;
using LateralApp.Services.Location.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LateralApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            // Automapper => Automatically scanning for profiles
            var configuration =
                new MapperConfiguration(cfg =>
                    cfg.AddMaps(
                        Assembly.GetAssembly(typeof(CountryProfile)),
                        Assembly.GetAssembly(typeof(GrpcCountryProfile))
                    ));
            //configuration.AssertConfigurationIsValid();
            AutoMapperConfiguration.Init(configuration);

            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContextPool<LateralAppContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseInMemoryDatabase("LateralApp_Core_Test_Db").ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<LateralAppContext>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddHttpClient<IEasyTemplateCoreHttpClient, EasyTemplateCoreHttpClient>();
            services.AddScoped<IEasyTemplateCoreHttpClient, EasyTemplateCoreHttpClient>();
            services.AddSingleton<IEasyTemplateCoreGrpcClient, EasyTemplateCoreGrpcClient>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LateralApp", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyTemplateCore v1"));
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
