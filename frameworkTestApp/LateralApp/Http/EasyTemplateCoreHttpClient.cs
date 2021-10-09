using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LateralApp.Dtos.Location.Country;
using Microsoft.Extensions.Configuration;

namespace LateralApp.Http
{
    /// <summary>
    /// 
    /// </summary>
    public class EasyTemplateCoreHttpClient : IEasyTemplateCoreHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _easyTemplateCoreHttpServiceAddress;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="configuration"></param>
        public EasyTemplateCoreHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _easyTemplateCoreHttpServiceAddress = _configuration["EasyTemplateCoreHttpServiceAddress"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCountry"></param>
        /// <returns></returns>
        public async Task<CountryDto> AddCountry(AddCountryDto addCountry)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(addCountry), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_easyTemplateCoreHttpServiceAddress}/Country", httpContent).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            var countryDtos = JsonSerializer.Deserialize<CountryDto>(result);
            return countryDtos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CountryDto>> GetCountries(int pageNo, int pageSize)
        {
            var response = await _httpClient.GetAsync($"{_easyTemplateCoreHttpServiceAddress}/Country/pageNo={pageNo}&pageSize={pageSize}").ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            var countryDtos = JsonSerializer.Deserialize<IEnumerable<CountryDto>>(result);
            return countryDtos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CountryDto> GetCountry(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_easyTemplateCoreHttpServiceAddress}/Country/{id}").ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            var countryDtos = JsonSerializer.Deserialize<CountryDto>(result);
            return countryDtos;
        }
    }
}