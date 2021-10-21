using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTemplateCore.Web.Jwt
{
    public interface ITokenFactoryService
    {
        Task<string> CreateJwtTokensAsync(ApplicationUser user);
    }

}
