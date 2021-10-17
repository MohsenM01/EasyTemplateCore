using System.Threading.Tasks;
using EasyTemplateCore.Dtos.Location.Country;
using EasyTemplateCore.Services.Location.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace EasyTemplateCore.Services.Tests.Location
{
    public class CountryServiceTests : BaseServiceTest
    {

        [Test]
        public async Task AddCountryAsync_ReturnsSuccess()
        {
            using var serviceScope = ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            // Arrange
            var countryService = serviceScope.ServiceProvider.GetRequiredService<ICountryService>();
            var addCountryDto = new AddCountryDto
            {
                CountryAbbr = "TRK",
                CountryName = "TURKEY",
                CountryNo = 2,
                Remark = null
            };

            // Act
            var result = await countryService.AddCountryAsync(addCountryDto);

            // Assert
            result.IsSuccess.Should().Be(true);

        }

    }
}