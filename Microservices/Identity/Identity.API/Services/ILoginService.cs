using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public interface ILoginService<T>
    {
        bool ValidateCredentials(T user, string password);
        Task<T> FindByLogin(string account);
        Task<T> FindById(string id);
        Task<IList<T>> GetUsers();
        Task<IList<string>> GetUserRoles(T user);
        Task SignIn(T user);
        Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);
    }
}
