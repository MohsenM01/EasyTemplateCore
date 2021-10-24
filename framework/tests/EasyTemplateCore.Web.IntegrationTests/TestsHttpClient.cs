using System;
using System.Net.Http;
using System.Threading;

namespace EasyTemplateCore.Web.IntegrationTests
{
    public static class TestsHttpClient
    {
        private static readonly Lazy<HttpClient> ServiceProviderBuilder =
            new(GetHttpClient, LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// A lazy loaded thread-safe singleton
        /// </summary>
        public static HttpClient Instance { get; } = ServiceProviderBuilder.Value;

        private static HttpClient GetHttpClient()
        {
            var services = new CustomWebApplicationFactory();
            return services.CreateClient(); //NOTE: This action is very time consuming, so it should be defined as a singleton.
        }
    }
}
