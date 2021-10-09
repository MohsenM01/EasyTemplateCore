using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LateralApp.Dtos.Location.Country;
using LateralApp.Http;
using Microsoft.AspNetCore.Mvc;

namespace LateralApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryEasyTemplateCoreHttpClientController : ControllerBase
    {
        private readonly IEasyTemplateCoreHttpClient _easyTemplateCoreHttpClient;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="easyTemplateCoreHttpClient"></param>
        public CountryEasyTemplateCoreHttpClientController(IEasyTemplateCoreHttpClient easyTemplateCoreHttpClient)
        {
            _easyTemplateCoreHttpClient = easyTemplateCoreHttpClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("pageNo={pageNo}&pageSize={pageSize}", Name = "etc-CountryList")]
        public async Task<ActionResult<IEnumerable<CountryDto>>> CountryList(int pageNo, int pageSize)
        {
            return Ok(await _easyTemplateCoreHttpClient.GetCountries(pageNo, pageSize));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "etc-GetCountryById")]
        public async Task<ActionResult<CountryDto>> GetCountryById(Guid id)
        {
            var countryDto = await _easyTemplateCoreHttpClient.GetCountry(id);
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
            var countryDto = await _easyTemplateCoreHttpClient.AddCountry(addCountryDto);
            //if (result.IsFailure)
            //{
            //    //TODO Return errors
            //}
            //var countryDto = await _countryService.GetOneCountryAsync(result.Value);
            return CreatedAtRoute(nameof(GetCountryById), new { Id = countryDto.Id }, countryDto);
        }


        ////
        //// PUT: /Country/Edit/5
        ///// <summary>
        ///// save country changes
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="editCountryDto"></param>
        ///// <returns></returns>
        //[HttpPut("{id}")]
        //public async Task<ActionResult<CountryDto>> Edit(Guid id, EditCountryDto editCountryDto)
        //{
        //    if (editCountryDto == null)
        //    {
        //        return NotFound();
        //    }
        //    var result = await _countryService.EditCountryAsync(id,editCountryDto);
        //    if (result.IsFailure)
        //    {
        //        //TODO Return errors
        //    }
        //    if (result.IsSuccess)
        //    {
        //        return Ok(editCountryDto);
        //    }
        //    return NoContent();
        //}

        ////
        //// Delete: /Country/Delete/5
        ///// <summary>
        ///// delete country
        ///// </summary>
        ///// <param name="id">country id</param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<CountryDto>> Delete(Guid id)
        //{
        //    var result = await _countryService.RemoveCountryAsync(id);
        //    if (result.IsFailure)
        //    {
        //        //TODO Return errors
        //    }
        //    if (result.IsSuccess)
        //    {
        //        return NoContent();
        //    }
        //    return NotFound();
        //}
    }
}
