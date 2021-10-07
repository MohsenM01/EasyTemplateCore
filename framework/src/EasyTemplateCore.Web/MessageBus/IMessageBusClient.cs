using EasyTemplateCore.Dtos.Location.Country;

namespace EasyTemplateCore.Web.MessageBus
{
    public interface IMessageBusClient
    {
        void PublishNewCountry(CountryDto countryDto);
    }
}