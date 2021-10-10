using AutoMapper;
using LateralApp.Dtos.Location.Country;

namespace LateralApp.MessageBus.Dtos.Location.Country
{
    public class MessageBusCountryProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageBusCountryProfile()
        {
            CreateMap<AddCountryDto, PublishedAddCountryDto>();
        }
    }
}
