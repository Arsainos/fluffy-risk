using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Aggregator.Models;
using Identity.API;
using Microsoft.AspNetCore.Http;
using WebApi.Aggregator.Config;
using Microsoft.Extensions.Options;

namespace WebApi.Aggregator.services
{
    public class AccountsService : IAccountsService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<AccountsService> _logger;
        private readonly UrlsConfig _urls;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountsService(HttpClient httpClient, ILogger<AccountsService> logger, IOptions<UrlsConfig> urls, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = urls.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AccountInfo> GetAccountById(string id)
        {
            return await GrpcCallerService.CallServiceWithCredentialsAsync(_urls.AccountsGrpc, _httpContextAccessor.HttpContext.Request.Headers["Authorization"], async channel =>
            {
                var client = new AccountsGrpc.AccountsGrpcClient(channel);
                _logger.LogInformation("grpc client created, request = { @id}", id);
                try
                {
                    var response1 = await client.GetAccountByIdAsync(new AccountRequest() { AccountId = id });
                }
                catch (Exception ex)
                {
                    var a = ex;
                }
                var response = await client.GetAccountByIdAsync(new AccountRequest() { AccountId = id });
                _logger.LogDebug("grpc response {@response}", response);

                return await Task.FromResult(MapToAccountInfo(response));
            });
        }

        public async Task<IEnumerable<AccountInfo>> GetAccounts()
        {
            return await GrpcCallerService.CallServiceWithCredentialsAsync(_urls.AccountsGrpc, _httpContextAccessor.HttpContext.Request.Headers["Authorization"], async channel =>
            {
                var client = new AccountsGrpc.AccountsGrpcClient(channel);
                _logger.LogInformation("grpc get accounts");

                var response = await client.GetAccountsAsync(new AccountRequestWithNoParameters());
                _logger.LogDebug("grpc response {@response}", response);

                return await Task.FromResult(response.Accounts.ToList().ConvertAll(new Converter<AccountResponse, AccountInfo>(MapToAccountInfo)).AsEnumerable());
            });
        }

        public async Task<string> Login(string Name, string Password)
        {
            return await GrpcCallerService.CallServiceAsync(_urls.AccountsGrpc, async channel =>
            {
                var client = new AccountsGrpc.AccountsGrpcClient(channel);
                _logger.LogInformation("grpc client created");
                _logger.LogInformation(_urls.AccountsGrpc);
                try
                {
                    var response = await client.LoginAsync(new AccountLoginRequest() { AccountName = Name, AccountPassword = Password });
                    _logger.LogDebug("grpc response {@response}", response);
                }
                catch(Exception ex)
                {
                    var c = ex;
                }

                return ""; //response.Token;
            });
        }

        private static AccountResponse MapToAccountReponse(AccountInfo accountInfo)
        {
            AccountResponse account = new AccountResponse()
            {
                AccountId = accountInfo.Id,
                AccountName = accountInfo.Name
            };
            account.AccountRole.Add(accountInfo.Roles);
            return account;
        }

        private AccountInfo MapToAccountInfo(AccountResponse accountResponse)
        {
            return new AccountInfo
            {
                Id = accountResponse.AccountId,
                Name = accountResponse.AccountName,
                Roles = accountResponse.AccountRole.ToList()
            };
        }
    }
}
