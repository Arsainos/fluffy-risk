﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Aggregator.Models;
using Identity.API;

namespace WebApi.Aggregator.services
{
    public class AccountsService : IAccountsService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<AccountsService> _logger;
        private readonly string _connection;

        public AccountsService(HttpClient httpClient, ILogger<AccountsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _connection = Config.UrlsConfig.GrpcAccounts;
        }

        public async Task<AccountInfo> GetAccountById(string id)
        {
            return await GrpcCallerService.CallServiceAsync(_connection, async channel =>
            {
                var client = new AccountsGrpc.AccountsGrpcClient(channel);
                _logger.LogInformation("grpc client created, request = { @id}", id);

                var response = await client.GetAccountByIdAsync(new AccountRequest() { AccountId = id });
                _logger.LogDebug("grpc response {@response}", response);

                return await Task.FromResult(MapToAccountInfo(response));
            });
        }

        public async Task<IEnumerable<AccountInfo>> GetAccounts()
        {
            return await GrpcCallerService.CallServiceAsync(_connection, async channel =>
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
            return await GrpcCallerService.CallServiceAsync(_connection, async channel =>
            {
                var client = new AccountsGrpc.AccountsGrpcClient(channel);
                _logger.LogInformation("grpc client created");

                var response = await client.LoginAsync(new AccountLoginRequest() { AccountName = Name, AccountPassword = Password });
                _logger.LogDebug("grpc response {@response}", response);

                return response.Token;
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
