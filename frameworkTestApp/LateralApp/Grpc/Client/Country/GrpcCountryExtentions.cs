using System.Collections.Generic;
using GrpcClient.CountryService;
using LateralApp.Dtos;
using LateralApp.Dtos.Location.Country;

namespace LateralApp.Grpc.Client.Country
{
    public static class GrpcCountryExtentions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<CountryDto> ToCountryDtos(this IEnumerable<GrpcCountryModel> list)
        {
            return AutoMapperConfiguration.Mapper.Map<IEnumerable<GrpcCountryModel>, IEnumerable<CountryDto>>(list);
        }

    }
}