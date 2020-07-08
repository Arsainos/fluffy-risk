using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.API.Models;
using Identity.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService<ApplicationUser> _loginService;
        private readonly ITokenService<ApplicationUser> _tokenService;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ILoginService<ApplicationUser> loginService, ILogger<AccountController> logger, UserManager<ApplicationUser> userManager)
        {
            _loginService = loginService;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _loginService.FindByLogin(model.Account);

                if(await _loginService.ValidateCredentials(user, model.Password))
                {
                    var props = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        AllowRefresh = true,
                        RedirectUri = model.ReturnUrl
                    };

                    await _loginService.SignInAsync(user, props);
                }

                return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError("", "Invalid username or password.");

            return ValidationProblem();
        }
    }
}