using LateralApp.Dtos.Location.Country;

namespace LateralApp.MessageBus.ProduceMessage
{
    public interface IMessageBusClient
    {
        void PublishNewCountry(AddCountryDto addCountry);
    }
}