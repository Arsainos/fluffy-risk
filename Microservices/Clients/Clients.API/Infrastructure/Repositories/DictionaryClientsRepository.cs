using Clients.API.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients.API.Infrastructure.Repositories
{
    public class DictionaryClientsRepository : IClientsRepository
    {
        private Dictionary<int, ClientInfo> _storage;

        public DictionaryClientsRepository()
        {
            _storage = new Dictionary<int, ClientInfo>();
            _storage.Add(1, new ClientInfo { Id = 1, Inn = 123456, Name = "Рога и Копыта", Holding = "12 стульев" });
            _storage.Add(2, new ClientInfo { Id = 2, Inn = 123456, Name = "Напитки из черноголовки", Holding = "Лимонад и сладкая вода" });
        }

        public Task<bool> DeleteClientInfoAsync(int clientId)
        {
            return Task.FromResult(_storage.Remove(clientId));
        }

        public Task<ClientInfo> GetClientInfoAsync(int clientId)
        {
            return Task.FromResult(_storage[clientId]);
        }

        public Task<IEnumerable<ClientInfo>> GetClients()
        {
            return Task.FromResult(_storage.Values.AsEnumerable());
        }

        public Task<ClientInfo> UpdateClientInfoAsync(ClientInfo clientInfo)
        {
            return Task.FromResult(_storage[clientInfo.Id] = clientInfo);
        }

        public Task<int> CreateClientAsync(ClientInfo clientInfo)
        {
            return Task<int>.Factory.StartNew(() => {
                int index = _storage.Max(client => client.Key) + 1;

                _storage.Add(index, new ClientInfo { Id = index, Inn = clientInfo.Inn, Name = clientInfo.Name, Holding = clientInfo.Holding });
                
                return index;
            });
        }
    }
}
