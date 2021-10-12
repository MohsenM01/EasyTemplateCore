using AutoMapper;
using EasyTemplateCore.Dtos.Location.Country;
using GrpcServer.CountryService;

namespace EasyTemplateCore.Web.Grpc.Server.Country
{
    public class GrpcCountryProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public GrpcCountryProfile()
        {
            CreateMap<CountryDto, GrpcCountryModel>();
        }
    }
}
