namespace LateralApp.Dtos.Location.Country
{
    public static class CountryExtentions
    {
        #region Country

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Entities.Location.Country ToEntity(this AddCountryDto model)
        {
            return AutoMapperConfiguration.Mapper.Map<AddCountryDto, Entities.Location.Country>(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Entities.Location.Country ToEntity(this EditCountryDto model)
        {
            return AutoMapperConfiguration.Mapper.Map<EditCountryDto, Entities.Location.Country>(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void ToEntity(this EditCountryDto model, Entities.Location.Country entity)
        {
            AutoMapperConfiguration.Mapper.Map(model, entity);
        }

        #endregion
    }
}
