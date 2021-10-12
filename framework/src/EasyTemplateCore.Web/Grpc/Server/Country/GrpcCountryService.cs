using System;
using System.Threading.Tasks;
using EasyTemplateCore.Services.Location.Interfaces;
using Grpc.Core;
using GrpcServer.CountryService;

namespace EasyTemplateCore.Web.Grpc.Server.Country
{
    public class GrpcCountryService : GrpcCountry.GrpcCountryBase
    {
        private readonly ICountryService _countryService;

        public GrpcCountryService(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public override async Task<GrpcCountryResponseModel> GetCountries(GrpcCountryRequestModel request, ServerCallContext context)
        {
            var response = new GrpcCountryResponseModel();
            var countries = await _countryService.GetCountriesAsync(request.PageNo, request.PageSize);

            response.Countries.AddRange(countries.ToGrpcCountryModels());

            return await Task.FromResult(response);
        }
    }
}