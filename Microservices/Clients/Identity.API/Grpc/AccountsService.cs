using Grpc.Core;
using Identity.API.Models;
using Identity.API.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Grpc
{
    public class AccountsService : AccountsGrpc.AccountsGrpcBase
    {
        private readonly ILogger<AccountsService> _logger;
        private readonly ILoginService<ApplicationUser> _loginService;
        private readonly ITokenService<ApplicationUser> _tokenService;

        public AccountsService(ILogger<AccountsService> logger, ILoginService<ApplicationUser> loginService, ITokenService<ApplicationUser> tokenService)
        {
            _logger = logger;
            _loginService = loginService;
            _tokenService = tokenService;
        }

        public override Task<AccountResponse> GetAccountById(AccountRequest request, ServerCallContext context)
        {
            return base.GetAccountById(request, context);
        }

        public override Task<ListAccountResponse> GetAccounts(AccountRequestWithNoParameters request, ServerCallContext context)
        {
            return base.GetAccounts(request, context);
        }

        public override Task<AccountTokenResponse> Login(AccountLoginRequest request, ServerCallContext context)
        {
            return base.Login(request, context);
        }
    }
}
