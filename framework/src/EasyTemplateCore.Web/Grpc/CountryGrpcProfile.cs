using AutoMapper;
using CountryService;
using EasyTemplateCore.Dtos.Location.Country;

namespace EasyTemplateCore.Web.Grpc
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
