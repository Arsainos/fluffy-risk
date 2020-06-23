﻿using WebApi.Aggregator.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebApi.Aggregator.services
{
    public interface IClientsService
    {
        Task<ClientInfo> GetClientById(int clientId);
        Task<ClientInfo> UpdateClientInfo(ClientInfo clientInfo);
        IEnumerable<ClientInfo> GetClients();
        Task<bool> DeleteClient(int clientId);
    }
}
