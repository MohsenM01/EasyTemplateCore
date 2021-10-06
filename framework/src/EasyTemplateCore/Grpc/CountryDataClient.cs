using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration;
using EasyTemplateCore.Dtos.Location.Country;

namespace EasyTemplateCore.Grpc
{
    public class CountryDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CountryDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public IEnumerable<CountryDto> ReturnAllCountries()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(new List<CountryDto>());
        }
    }
}
