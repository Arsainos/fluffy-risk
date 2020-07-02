using Identity.API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public class ApplicationLoginService : ILoginService<ApplicationUser>
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public ApplicationLoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<ApplicationUser> FindByLogin(string account)
        {
            return null;
        }

        public Task SignIn(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SignInAsync(ApplicationUser user, AuthenticationProperties properties, string authenticationMethod = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateCredentials(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
