using System.Collections.Generic;
using EasyTemplateCore.Dtos;
using EasyTemplateCore.Dtos.Location.Country;
using GrpcServer.CountryService;

namespace EasyTemplateCore.Web.Grpc.Server.Country
{
    public static class GrpcCountryExtentions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<GrpcCountryModel> ToGrpcCountryModels(this IEnumerable<CountryDto> list)
        {
            return AutoMapperConfiguration.Mapper.Map<IEnumerable<CountryDto>, IEnumerable<GrpcCountryModel>>(list);
        }

    }
}
