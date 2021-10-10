using LateralApp.Dtos;
using LateralApp.Dtos.Location.Country;

namespace LateralApp.MessageBus.Dtos.Location.Country
{
    public static class MessageBusCountryExtentions
    {
        #region Country

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PublishedAddCountryDto ToMessageBusDto(this AddCountryDto model)
        {
            return AutoMapperConfiguration.Mapper.Map<AddCountryDto, PublishedAddCountryDto>(model);
        }

        #endregion
    }
}
