using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LateralApp.Dtos.Location.Country;
using LateralApp.Grpc;
using LateralApp.Grpc.Client.Country;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LateralApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryGrpcClientController : ControllerBase
    {
        private readonly IEasyTemplateCoreGrpcClient _easyTemplateCoreGrpcClient;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="easyTemplateCoreGrpcClient"></param>
        public CountryGrpcClientController(IEasyTemplateCoreGrpcClient easyTemplateCoreGrpcClient)
        {
            _easyTemplateCoreGrpcClient = easyTemplateCoreGrpcClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status307TemporaryRedirect)]
        public IActionResult CountryList()
        {
            return RedirectToAction(nameof(CountryList), new { pageNo = 1, pageSize = 10 });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{pageNo}/{pageSize}", Name = "etc-grpc-CountryList")]
        public async Task<ActionResult<IEnumerable<CountryDto>>> CountryList(int pageNo , int pageSize )
        {
            return Ok(await _easyTemplateCoreGrpcClient.GetCountries(pageNo, pageSize));
        }
    }
}
