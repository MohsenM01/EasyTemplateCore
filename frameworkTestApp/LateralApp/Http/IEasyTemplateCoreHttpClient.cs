using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LateralApp.Dtos.Location.Country;

namespace LateralApp.Http
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEasyTemplateCoreHttpClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCountry"></param>
        /// <returns></returns>
        Task<CountryDto> AddCountry(AddCountryDto addCountry);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<CountryDto>> GetCountries(int pageNo, int pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CountryDto> GetCountry(Guid id);
    }
}