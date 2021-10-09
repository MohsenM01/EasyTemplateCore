using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LateralApp.Dtos.Location.Country;

namespace LateralApp.Services.Location.Interfaces
{
    public interface ICountryService
    {
        /// <summary>
        /// contain CountryName or latinName
        /// </summary>
        /// <param name="countryNo"></param>
        /// <returns></returns>
        Task<bool> ExistsCountryNoAsync(int countryNo);

        /// <summary>
        /// contain CountryName or latinName and id not equal id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countryNo"></param>
        /// <returns></returns>
        Task<bool> ExistsCountryNoAsync(Guid id, int countryNo);

        /// <summary>
        /// contain CountryName or latinName
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<bool> ExistsCountryNameAsync(string countryName);

        /// <summary>
        /// contain CountryName or latinName and id not equal id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<bool> ExistsCountryNameAsync(Guid id, string countryName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCountryModel"></param>
        /// <returns></returns>
        Task<Result<Guid, List<string>>> AddCountryAsync(AddCountryDto addCountryModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editCountryModel"></param>
        /// <returns></returns>
        Task<Result<bool, List<string>>> EditCountryAsync(Guid id, EditCountryDto editCountryModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<bool, List<string>>> RemoveCountryAsync(Guid id);

        /// <summary>
        /// countries count
        /// </summary>
        /// <returns></returns>
        Task<int> CountriesCountAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CountryDto> GetOneCountryAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EditCountryDto> GetCountryForEditAsync(Guid id);

        /// <summary>
        /// get countries
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<CountryDto>> GetCountriesAsync(int pageNo, int pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CountryDto>> GetAllAsync();
    }

}