using Identity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public interface ITokenService
    {
        Task<string> GenerateJwtTokenAsync(string login, string password);
        Task<List<Claim>> GetUserClaimsAsync(ApplicationUser user);
    }
}
