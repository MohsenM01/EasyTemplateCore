using EasyTemplateCore.Dtos.Location.Country;

namespace EasyTemplateCore.MessageBus
{
    public interface IMessageBusClient
    {
        void PublishNewCountry(CountryDto countryDto);
    }
}