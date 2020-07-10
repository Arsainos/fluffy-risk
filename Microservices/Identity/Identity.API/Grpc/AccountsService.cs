using Grpc.Core;
using Identity.API.Models;
using Identity.API.Services;
using Microsoft.AspNetCore.Authentication;
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

        public async override Task<AccountResponse> GetAccountById(AccountRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for account id {Id}", context.Method, request.AccountId);

            var accountData = await _loginService.FindById(request.AccountId);

            _logger.LogInformation("Account data {info}", accountData);

            var roles = new Google.Protobuf.Collections.RepeatedField<string>();
            foreach(var role in await _loginService.GetUserRoles(accountData))
            {
                roles.Add(role);
            }

            AccountResponse response = new AccountResponse() { AccountId = accountData.Id, AccountName = accountData.Name };
            response.AccountRole.Add(roles);

            return response;
        }

        public async override Task<ListAccountResponse> GetAccounts(AccountRequestWithNoParameters request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method}}", context.Method);

            var accounts = await _loginService.GetUsers();

            _logger.LogInformation("Success get accounts data");

            var accountsList = new Google.Protobuf.Collections.RepeatedField<AccountResponse>();
            foreach(var accountData in accounts)
            {
                var roles = new Google.Protobuf.Collections.RepeatedField<string>();
                foreach (var role in await _loginService.GetUserRoles(accountData))
                {
                    roles.Add(role);
                }

                AccountResponse accountResponse = new AccountResponse() { AccountId = accountData.Id, AccountName = accountData.Name };
                accountResponse.AccountRole.Add(roles);

                accountsList.Add(accountResponse);
            }

            ListAccountResponse response = new ListAccountResponse();
            response.Accounts.Add(accountsList);

            return response;
        }

        public async override Task<AccountTokenResponse> Login(AccountLoginRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method}}", context.Method);

            var user = await _loginService.FindByLogin(request.AccountName);

            if (user == null)
            {
                throw new Exception("user not found");
            }

            if (_loginService.ValidateCredentials(user, request.AccountPassword))
            {
                var props = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    AllowRefresh = true
                };

                await _loginService.SignInAsync(user, props);
            }

            var token = await _tokenService.GenerateJwtTokenAsync(user, request.AccountPassword);

            _logger.LogInformation("Success get token data");

            return new AccountTokenResponse() { Token = token };
        }
    }
}
