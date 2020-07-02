using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public interface ILoginService<T>
    {
        Task<bool> ValidateCredentials(T user, string password);
        Task<T> FindByAccount(string account);
        Task SignIn(T user);
        Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);
    }
}
