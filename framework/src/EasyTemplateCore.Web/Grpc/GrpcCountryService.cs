using System.Threading.Tasks;
using AutoMapper;
using CountryService;
using EasyTemplateCore.Services.Location.Interfaces;
using Grpc.Core;

namespace EasyTemplateCore.Web.Grpc
{
    public class GrpcCountryService : GrpcCountry.GrpcCountryBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public GrpcCountryService(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public override async Task<CountryResponse> GetAllCountries(GetAllRequest request, ServerCallContext context)
        {
            var response = new CountryResponse();
            var countries = await _countryService.GetAllAsync();

            foreach (var country in countries)
            {
                response.Country.Add(_mapper.Map<GrpcCountryModel>(country));
            }

            return await Task.FromResult(response);
        }
    }
}