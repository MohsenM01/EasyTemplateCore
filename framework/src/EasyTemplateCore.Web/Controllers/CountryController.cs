using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTemplateCore.Dtos.Location.Country;
using EasyTemplateCore.Services.Location.Interfaces;
using EasyTemplateCore.Web.RedisCache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyTemplateCore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="countryService"></param>
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status307TemporaryRedirect)]
        public IActionResult CountryList()
        {
            return RedirectToAction(nameof(CountryList), new { pageNo = 1, pageSize = 10 });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("{pageNo}/{pageSize}", Name = "CountryList")]
        [Cached]
        public async Task<ActionResult<IEnumerable<CountryDto>>> CountryList(int pageNo, int pageSize)
        {
            return Ok(await _countryService.GetCountriesAsync(pageNo, pageSize));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCountryById")]
        public async Task<ActionResult<CountryDto>> GetCountryById(Guid id)
        {
            var countryDto = await _countryService.GetOneCountryAsync(id);
            if (countryDto != null)
            {
                return Ok(countryDto);
            }
            return NotFound();
        }

        //
        // POST: /Country/Create
        /// <summary>
        /// Add country to countries
        /// </summary>
        /// <param name="addCountryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CountryDto>> Create(AddCountryDto addCountryDto)
        {
            if (addCountryDto == null)
            {
                return NotFound();
            }
            var result = await _countryService.AddCountryAsync(addCountryDto);
            if (result.IsFailure)
            {
                //TODO Return errors
            }
            var countryDto = await _countryService.GetOneCountryAsync(result.Value);
            return CreatedAtRoute(nameof(GetCountryById), new { Id = result.Value }, countryDto);
        }


        //
        // PUT: /Country/Edit/5
        /// <summary>
        /// save country changes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editCountryDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<CountryDto>> Edit(Guid id, EditCountryDto editCountryDto)
        {
            if (editCountryDto == null)
            {
                return NotFound();
            }
            var result = await _countryService.EditCountryAsync(id, editCountryDto);
            if (result.IsFailure)
            {
                //TODO Return errors
            }
            if (result.IsSuccess)
            {
                return Ok(editCountryDto);
            }
            return NoContent();
        }

        //
        // Delete: /Country/Delete/5
        /// <summary>
        /// delete country
        /// </summary>
        /// <param name="id">country id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<CountryDto>> Delete(Guid id)
        {
            var result = await _countryService.RemoveCountryAsync(id);
            if (result.IsFailure)
            {
                //TODO Return errors
            }
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
