using System.Collections.Generic;
using System.Threading.Tasks;
using LateralApp.Dtos.Location.Country;

namespace LateralApp.Grpc.Client.Country
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEasyTemplateCoreGrpcClient
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<CountryDto>> GetCountries(int pageNo, int pageSize);
    }
}