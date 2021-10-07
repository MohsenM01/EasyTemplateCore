using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EasyTemplateCore.Dtos.Location.Country;
using Microsoft.Extensions.Configuration;

namespace EasyTemplateCore.Web.Http
{
    public class HttpDataClient : IHttpDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendCountries(CountryDto country)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(country), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_configuration["HttpServiceAddress"]}", httpContent).ConfigureAwait(false);
        }
    }
}