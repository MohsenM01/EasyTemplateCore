using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EasyTemplateCore.Dtos.Location.Country;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyTemplateCore.Web.IntegrationTests
{
    [TestClass]
    public class CountryTests
    {
        [TestMethod]
        public async Task Create_Should_Add_Country()
        {
            // Arrange
            var client = TestsHttpClient.Instance;

            // Act
            const string countryApiUrl = "/Country";
            var addCountryDto = new AddCountryDto
            {
                CountryAbbr = "UK",
                CountryName = "THE UNITED KINGDOM",
                CountryNo = 4,
                Remark = null
            };
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, countryApiUrl)
            {
                Content = new StringContent(JsonSerializer.Serialize(addCountryDto), Encoding.UTF8, "application/json")
            });

            response.EnsureSuccessStatusCode();

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().NotBeNullOrEmpty();
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var apiResponse = JsonSerializer.Deserialize<CountryDto>(responseString, options);
            apiResponse.Should().NotBeNull();
            apiResponse.CountryAbbr.Should().Be(addCountryDto.CountryAbbr);
            apiResponse.CountryName.Should().Be(addCountryDto.CountryName);
            apiResponse.CountryNo.Should().Be(addCountryDto.CountryNo);
            apiResponse.Remark.Should().Be(addCountryDto.Remark);
        }
    }
}
