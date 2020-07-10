using Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public class TokenService : ITokenService<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SymmetricSecurityKey _securityKey;
        private readonly JwtSecurityTokenHandler _jwtTokenHandler = new JwtSecurityTokenHandler();

        public TokenService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _securityKey = Certificates.Keys._securityKey;
        }

        public async Task<string> GenerateJwtTokenAsync(ApplicationUser user, string password)
        {
            if (user == null || !user.PasswordHash.Equals(password))
                throw new Exception("User not found");

            SigningCredentials credentials =
                new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token =
                new JwtSecurityToken("Fluffy-Risk.Identity.Api", "Fluffy-Risk.Clients", await GetUserClaimsAsync(user), expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            return _jwtTokenHandler.WriteToken(token);
        }

        public async Task<List<Claim>> GetUserClaimsAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>();

            roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            return claims;
        }
    }
}
