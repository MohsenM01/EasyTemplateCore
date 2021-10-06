using AutoMapper;
using CountryService;
using EasyTemplateCore.Dtos.Location.Country;

namespace EasyTemplateCore.Grpc
{
    public class CountryGrpcProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public CountryGrpcProfile()
        {
            CreateMap<CountryDto, GrpcCountryModel>();
        }
    }
}
