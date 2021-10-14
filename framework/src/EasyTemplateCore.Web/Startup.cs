using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AspNetCoreRateLimit;
using AutoMapper;
using DNTCommon.Web.Core;
using EasyTemplateCore.Data;
using EasyTemplateCore.Dtos;
using EasyTemplateCore.Dtos.Location.Country;
using EasyTemplateCore.Services.Location.Interfaces;
using EasyTemplateCore.Web.Grpc.Server.Country;
using EasyTemplateCore.Web.MessageBus.ConsumeMessage;
using EasyTemplateCore.Web.RedisCache;
using ElmahCore;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EasyTemplateCore.Web
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
            //https://github.com/stefanprodan/AspNetCoreRateLimit

            // needed to load configuration from appsettings.json
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            // inject counter and rules stores
            services.AddInMemoryRateLimiting();
            //services.AddDistributedRateLimiting<AsyncKeyLockProcessingStrategy>();
            //services.AddDistributedRateLimiting<RedisProcessingStrategy>();
            //services.AddRedisRateLimiting();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            //https://docs.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-5.0&tabs=dotnet
            services.AddSignalR()
                .AddJsonProtocol(options =>
                {
                    options.PayloadSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.PayloadSerializerOptions.WriteIndented = true;
                    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
                });

            //https://github.com/VahidN/DNTCommon.Web.Core
            services.Configure<SmtpConfig>(options => Configuration.GetSection("SmtpConfig").Bind(options));
            services.Configure<AntiDosConfig>(options => Configuration.GetSection("AntiDosConfig").Bind(options));
            services.Configure<AntiXssConfig>(options => Configuration.GetSection("AntiXssConfig").Bind(options));
            services.AddDNTCommonWeb();

            //https://docs.microsoft.com/en-us/aspnet/core/performance/response-compression?view=aspnetcore-5.0
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = Microsoft.AspNetCore.ResponseCompression.ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    "image/svg+xml",
                    "application/font-woff2"
                });
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            //https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
            services.AddHostedService<MessageBusSubscriber>();
            services.AddSingleton<IEventProcessor, EventProcessor>();

            //https://github.com/grpc/grpc-dotnet
            services.AddGrpc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyTemplateCore", Version = "v1" });
            });

            // Scrutor => Scan method which looks in the calling assembly, and adds all concrete classes as transient services
            services.Scan(scan => scan
                .FromAssemblyOf<ICountryService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            // Automapper => Automatically scanning for profiles
            var configuration =
                new MapperConfiguration(cfg =>
                    cfg.AddMaps(
                        Assembly.GetAssembly(typeof(CountryProfile)),
                        Assembly.GetAssembly(typeof(GrpcCountryProfile))
                        ));
            //configuration.AssertConfigurationIsValid();
            AutoMapperConfiguration.Init(configuration);

            //https://docs.microsoft.com/en-us/ef/core/performance/advanced-performance-topics?tabs=with-constant
            var useInMemoryDatabase = Configuration["UseInMemoryDatabase"].Equals("true", StringComparison.OrdinalIgnoreCase);
            if (useInMemoryDatabase)
            {
                services.AddEntityFrameworkInMemoryDatabase();
            }
            else
            {
                services.AddEntityFrameworkSqlServer();
            }
            services.AddDbContextPool<EasyTemplateCoreContext>((serviceProvider, optionsBuilder) =>
            {
                if (useInMemoryDatabase)
                {
                    optionsBuilder.UseInMemoryDatabase("EasyTemplateCore_Core_Test_Db").ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                }
                else
                {
                    optionsBuilder.UseSqlServer(
                        Configuration["ConnectionStrings:EasyTemplateCoreContext"]
                        , serverDbContextOptionsBuilder =>
                        {
                            var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                            serverDbContextOptionsBuilder.CommandTimeout(minutes);

                            //https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                            serverDbContextOptionsBuilder.EnableRetryOnFailure(
                                 10,
                                 TimeSpan.FromSeconds(30),
                                 null);

                            serverDbContextOptionsBuilder.MigrationsAssembly("EasyTemplateCore.Web");
                        }).AddInterceptors(new PersianYeKeCommandInterceptor());
                }
                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<IUnitOfWork, EasyTemplateCoreContext>();

            //https://github.com/dotnet/aspnet-api-versioning/wiki
            services.AddApiVersioning(options => options.AssumeDefaultVersionWhenUnspecified = true);

            //https://github.com/ElmahCore/ElmahCore
            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.OnPermissionCheck = context => context.User.Identity.IsAuthenticated && context.User.Identity.Name == "admin";
                options.LogPath = "~/ElmahLogs"; // OR options.LogPath = "с:\errors";
            });

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration["ConnectionStrings:EasyTemplateCoreRedis"];
            });

            //Register Custom Services
            services.AddSingleton<RedisCache.ICacheService, CacheService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IUnitOfWork unitOfWork)
        {
            //https://github.com/stefanprodan/AspNetCoreRateLimit
            app.UseIpRateLimiting();

            //https://github.com/andrewlock/NetEscapades.AspNetCore.SecurityHeaders
            var policyCollection = new HeaderPolicyCollection()
                .AddFrameOptionsDeny()
                .AddXssProtectionBlock()
                .AddContentTypeOptionsNoSniff()
                .AddStrictTransportSecurityMaxAgeIncludeSubDomains(maxAgeInSeconds: 60 * 60 * 24 * 365) // maxage = one year in seconds
                .AddReferrerPolicyStrictOriginWhenCrossOrigin()
                .RemoveServerHeader()
                .AddContentSecurityPolicy(builder =>
                {
                    builder.AddObjectSrc().None();
                    builder.AddFormAction().Self();
                    builder.AddFrameAncestors().None();
                });
            app.UseSecurityHeaders(policyCollection);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyTemplateCore v1"));
            }



            //https://docs.microsoft.com/en-us/aspnet/core/performance/response-compression?view=aspnetcore-5.0
            app.UseResponseCompression();  // Adds the response compression to the request pipeline

            //app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //https://docs.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-5.0&tabs=dotnet
                //endpoints.MapHub<ChatHub>("/chathub", options =>
                //{
                //    options.Transports =
                //        HttpTransportType.WebSockets |
                //        HttpTransportType.LongPolling;
                //});

                endpoints.MapGrpcService<GrpcCountryService>();

                endpoints.MapGet("grpc/protos/countries.proto", async context =>
                {
                    await context.Response.WriteAsync(File.ReadAllText("Grpc/Protos/countries.proto"));
                });
            });

            //https://github.com/ElmahCore/ElmahCore
            app.UseElmah();

            PrepDb.SeedData(unitOfWork);
        }
    }
}
