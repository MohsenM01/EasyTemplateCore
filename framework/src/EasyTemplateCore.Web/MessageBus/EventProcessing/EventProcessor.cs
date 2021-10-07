using System;
using System.Text.Json;
using System.Threading.Tasks;
using EasyTemplateCore.Dtos.Location.Country;
using EasyTemplateCore.Services.Location.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EasyTemplateCore.Web.MessageBus.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            if (eventType == EventType.AddCountry)
            {
                await AddCountry(message);
            }

            throw new Exception($"Unkown message : {message}");
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            if (eventType == null) throw new ArgumentNullException(nameof(eventType));

            return eventType.Event switch
            {
                "AddCountry" => EventType.AddCountry,
                _ => EventType.Undetermined
            };
        }

        //This is an example and will be changed in future
        private async Task AddCountry(string publishedMessage)
        {
            using var scope = _scopeFactory.CreateScope();

            var countryService = scope.ServiceProvider.GetRequiredService<ICountryService>();

            var addCountryDto = JsonSerializer.Deserialize<AddCountryDto>(publishedMessage);

            await countryService.AddCountryAsync(addCountryDto);
        }
    }

}