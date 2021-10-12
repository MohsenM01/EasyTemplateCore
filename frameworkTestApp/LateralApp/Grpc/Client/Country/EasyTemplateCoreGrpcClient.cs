using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcClient.CountryService;
using LateralApp.Dtos.Location.Country;
using Microsoft.Extensions.Configuration;

namespace LateralApp.Grpc.Client.Country
{
    /// <summary>
    /// 
    /// </summary>
    public class EasyTemplateCoreGrpcClient : IEasyTemplateCoreGrpcClient
    {
        private readonly string _easyTemplateCoreGrpcServiceAddress;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public EasyTemplateCoreGrpcClient(IConfiguration configuration)
        {
            _easyTemplateCoreGrpcServiceAddress = configuration["EasyTemplateCoreGrpcServiceAddress"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CountryDto>> GetCountries(int pageNo, int pageSize)
        {
            var channel = GrpcChannel.ForAddress(_easyTemplateCoreGrpcServiceAddress);
            var client = new GrpcCountry.GrpcCountryClient(channel);
            var request = new GrpcCountryRequestModel();
            var reply = await client.GetCountriesAsync(request);

            return reply.Countries.ToCountryDtos();
        }

    }
}