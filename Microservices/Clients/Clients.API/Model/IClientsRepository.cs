using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients.API.Model
{
    public interface IClientsRepository
    {
        Task<ClientInfo> GetClientInfoAsync(int clientId);
        Task<IEnumerable<ClientInfo>> GetClients();
        Task<ClientInfo> UpdateClientInfoAsync(ClientInfo clientInfo);
        Task<bool> DeleteClientInfoAsync(int clientId);
        Task<int> CreateClientAsync(ClientInfo clientInfo);
    }
}
