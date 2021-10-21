using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EasyTemplateCore.Web.Jwt
{
    public class TokenFactoryService : ITokenFactoryService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BearerTokensOptions _configuration;

        public TokenFactoryService(
                UserManager<ApplicationUser> userManager,
                IOptionsSnapshot<BearerTokensOptions> bearerTokensOptions)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            if (bearerTokensOptions is null)
            {
                throw new ArgumentNullException(nameof(bearerTokensOptions));
            }
            _configuration = bearerTokensOptions.Value;
        }

        public async Task<string> CreateJwtTokensAsync(ApplicationUser user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key)),
                SecurityAlgorithms.HmacSha256);
            var claims = await getClaimsAsync(user);
            var now = DateTime.UtcNow;
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_configuration.AccessTokenExpirationMinutes),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private async Task<List<Claim>> getClaimsAsync(ApplicationUser user)
        {
            string issuer = _configuration.Issuer;
            var claims = new List<Claim>
            {
                // Issuer
                new Claim(JwtRegisteredClaimNames.Iss, issuer, ClaimValueTypes.String, issuer),
                // Issued at
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim(ClaimTypes.Name, user.Email, ClaimValueTypes.String, issuer),
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String, issuer),
                new Claim("Id", user.Id, ClaimValueTypes.String, issuer),
                new Claim("DisplayName", user.FirstName + " " + user.LastName, ClaimValueTypes.String, issuer),
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String, issuer));
            }
            return claims;
        }
    }
}
