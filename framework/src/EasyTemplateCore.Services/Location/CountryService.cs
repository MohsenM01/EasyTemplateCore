using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using EasyTemplateCore.Data;
using EasyTemplateCore.Dtos;
using EasyTemplateCore.Dtos.Location.Country;
using EasyTemplateCore.Entities.Location;
using EasyTemplateCore.Services.Location.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyTemplateCore.Services.Location
{
    /// <summary>
    /// 
    /// </summary>
    public class CountryService : ICountryService
    {
        #region Field

        private readonly IUnitOfWork _uow;
        private readonly DbSet<Country> _country;

        #endregion

        #region Ctor

        /// <summary>
        /// Create Instanse Of Country
        /// </summary>
        /// <param name="uow"></param>
        public CountryService(IUnitOfWork uow)
        {
            _uow = uow;
            _country = uow.Set<Country>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// contain CountryName or latinName
        /// </summary>
        /// <param name="countryNo"></param>
        /// <returns></returns>
        public async Task<bool> ExistsCountryNoAsync(int countryNo)
        {
            return await _country.AnyAsync(a => a.CountryNo == countryNo);
        }

        /// <summary>
        /// contain CountryName or latinName
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public async Task<bool> ExistsCountryNameAsync(string countryName)
        {
            return await _country.AnyAsync(a => a.CountryName.ToLower() == countryName.ToLower());
        }

        /// <summary>
        /// contain CountryName or latinName and id not equal id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public async Task<bool> ExistsCountryNameAsync(Guid id, string countryName)
        {
            return await _country.AnyAsync(a => (a.CountryName.ToLower() == countryName.ToLower()) && a.Id != id);
        }

        /// <summary>
        /// contain CountryName or latinName and id not equal id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countryNo"></param>
        /// <returns></returns>
        public async Task<bool> ExistsCountryNoAsync(Guid id, int countryNo)
        {
            return await _country.AnyAsync(a => a.CountryNo == countryNo && a.Id != id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCountryModel"></param>
        /// <returns></returns>
        public async Task<Result<Guid, List<string>>> AddCountryAsync(AddCountryDto addCountryModel)
        {
            if (addCountryModel == null)
                throw new ArgumentNullException(nameof(addCountryModel));

            var result = addCountryModel.IsValid();
            if (!result.IsSuccess)
                return Result.Failure<Guid, List<string>>(result.Error);

            if (await ExistsCountryNameAsync(addCountryModel.CountryName))
            {
                return Result.Failure<Guid, List<string>>(new List<string>
                {
                    "The country name is duplicate."
                });
            }
            if (await ExistsCountryNoAsync(addCountryModel.CountryNo))
            {
                return Result.Failure<Guid, List<string>>(new List<string>
                {
                    "The country no is duplicate."
                });
            }
            var country = addCountryModel.ToEntity();
            country.Id = Guid.NewGuid();
            _country.Add(country);
            if (await _uow.SaveChangesAsync() > 0)
            {
                return Result.Success<Guid, List<string>>(country.Id);
            }

            throw new Exception("unkown");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editCountryModel"></param>
        /// <returns></returns>
        public async Task<Result<bool, List<string>>> EditCountryAsync(Guid id, EditCountryDto editCountryModel)
        {
            if (editCountryModel == null)
                throw new ArgumentNullException(nameof(editCountryModel));

            if (id != editCountryModel.Id)
            {
                return Result.Failure<bool, List<string>>(new List<string>
                {
                    "ID ERROR"
                });
            }

            var result = editCountryModel.IsValid();
            if (!result.IsSuccess)
                return Result.Failure<bool, List<string>>(result.Error);

            if (await ExistsCountryNameAsync(id, editCountryModel.CountryName))
            {
                return Result.Failure<bool, List<string>>(new List<string>
                {
                    "The country name is duplicate."
                });
            }
            if (await ExistsCountryNoAsync(id, editCountryModel.CountryNo))
            {
                return Result.Failure<bool, List<string>>(new List<string>
                {
                    "The country no is duplicate."
                });
            }
            var searchCountry = await GetOne(id);
            if (searchCountry == null)
            {
                return Result.Failure<bool, List<string>>(new List<string>
                {
                    "The record has been deleted."
                });
            }
            var changeCountry = editCountryModel.ToEntity();
            if (EqualValue.ValueEquals(searchCountry, changeCountry,
                a => a.CountryName,
                a => a.CountryAbbr,
                a => a.CountryNo,
                a => a.Id,
                a => a.Remark))
            {
                return Result.Failure<bool, List<string>>(new List<string>
                {
                    "The record has not changed."
                });
            }
            editCountryModel.ToEntity(searchCountry);
            if (await _uow.SaveChangesAsync() > 0)
            {
                return Result.Success<bool, List<string>>(true);
            }
            return Result.Failure<bool, List<string>>(new List<string>
            {
                "Invalid record."
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<bool, List<string>>> RemoveCountryAsync(Guid id)
        {
            var searchCountry = await GetOne(id);
            if (searchCountry == null)
            {
                return Result.Failure<bool, List<string>>(new List<string>
                {
                    "The record has been deleted."
                });
            }
            _country.Remove(searchCountry);
            if (await _uow.SaveChangesAsync() > 0)
            {
                return Result.Success<bool, List<string>>(true);
            }
            return Result.Failure<bool, List<string>>(new List<string>
            {
                "Invalid record."
            });
        }



        /// <summary>
        /// countries count
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountriesCountAsync()
        {
            return await _country.CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CountryDto> GetOneCountryAsync(Guid id)
        {
            return await _country.ProjectTo<CountryDto>().FirstOrDefaultAsync(a => a.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EditCountryDto> GetCountryForEditAsync(Guid id)
        {
            return await _country.ProjectTo<EditCountryDto>().FirstOrDefaultAsync(a => a.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Country> GetOne(Guid id)
        {
            return await _country.FirstOrDefaultAsync(a => a.Id == id);
        }

        /// <summary>
        /// get countries
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CountryDto>> GetCountriesAsync(int pageNo, int pageSize)
        {
            var countriesQuery = _country.AsNoTracking();
            countriesQuery = countriesQuery.ApplyPaging(pageNo, pageSize);
            return await countriesQuery.ProjectTo<CountryDto>().ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return await _country.OrderBy(a => a.CountryName).AsNoTracking().ProjectTo<CountryDto>().ToListAsync();
        }

        #endregion

    }
}
