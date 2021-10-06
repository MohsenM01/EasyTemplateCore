using AutoMapper;

namespace EasyTemplateCore.Dtos.Location.Country
{
    public class CountryProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public CountryProfile()
        {
            CreateMap<AddCountryDto, Entities.Location.Country>();
            CreateMap<Entities.Location.Country, AddCountryDto>();
            CreateMap<Entities.Location.Country, CountryDto>();
        }
    }
}
