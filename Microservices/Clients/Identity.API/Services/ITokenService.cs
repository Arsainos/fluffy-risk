using Identity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public interface ITokenService<T>
    {
        Task<string> GenerateJwtTokenAsync(T user, string password);
        Task<List<Claim>> GetUserClaimsAsync(T user);
    }
}
