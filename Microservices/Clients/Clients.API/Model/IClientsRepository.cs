using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients.API.Model
{
    public interface IClientsRepository
    {
        Task<ClientInfo> GetClientInfoAsync(int clientId);
        IEnumerable<ClientInfo> GetClients();
        Task<ClientInfo> UpdateClientInfoAsync(ClientInfo clientInfo);
        Task<bool> DeleteClientInfoAsync(int clientId);
    }
}
