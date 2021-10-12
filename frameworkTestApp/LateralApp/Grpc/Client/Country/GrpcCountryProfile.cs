using AutoMapper;
using GrpcClient.CountryService;
using LateralApp.Dtos.Location.Country;

namespace LateralApp.Grpc.Client.Country
{
    public class GrpcCountryProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public GrpcCountryProfile()
        {
            CreateMap<GrpcCountryModel, CountryDto>();
        }
    }
}