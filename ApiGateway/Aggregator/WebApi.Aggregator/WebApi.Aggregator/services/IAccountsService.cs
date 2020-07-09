using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Aggregator.Models;

namespace WebApi.Aggregator.services
{
    public interface IAccountsService
    {
        Task<AccountInfo> GetAccountById(string id);
        Task<IEnumerable<AccountInfo>> GetAccounts();
        Task<string> Login(string Name, string Password);
    }
}
