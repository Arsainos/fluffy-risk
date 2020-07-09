using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public interface ILoginService<T>
    {
        bool ValidateCredentials(T user, string password);
        Task<T> FindByLogin(string account);
        Task<T> FindById(string id);
        Task SignIn(T user);
        Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);
    }
}
