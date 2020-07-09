using Grpc.Core;
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

        public AccountsService(ILogger<AccountsService> logger)
        {
            _logger = logger;
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
