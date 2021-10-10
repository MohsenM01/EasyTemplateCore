using LateralApp.Dtos.Location.Country;
using LateralApp.MessageBus.ProduceMessage;
using Microsoft.AspNetCore.Mvc;

namespace LateralApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryMessageBusController : ControllerBase
    {
        private readonly IMessageBusClient _messageBusClient;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="messageBusClient"></param>
        public CountryMessageBusController(IMessageBusClient messageBusClient)
        {
            _messageBusClient = messageBusClient;
        }

        //
        // POST: /Country/Create
        /// <summary>
        /// Add country to countries
        /// </summary>
        /// <param name="addCountryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CountryDto> Create(AddCountryDto addCountryDto)
        {
            if (addCountryDto == null)
            {
                return NotFound();
            }
            _messageBusClient.PublishNewCountry(addCountryDto);
            //if (result.IsFailure)
            //{
            //    //TODO Return errors
            //}
            //var countryDto = await _countryService.GetOneCountryAsync(result.Value);
            return Ok(addCountryDto);
        }

    }
}
