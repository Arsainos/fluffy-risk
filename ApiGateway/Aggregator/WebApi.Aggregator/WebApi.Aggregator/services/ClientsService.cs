using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using WebApi.Aggregator.Models;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Grpc.Core;
using Clients.API;

namespace WebApi.Aggregator.services
{
    public class ClientsService : IClientsService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<ClientsService> _logger;

        public ClientsService(HttpClient httpClient, ILogger<ClientsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public Task<ClientInfo> GetClientById(int clientId)
        {
            Channel channel = new Channel("localhost:5001", ChannelCredentials.Insecure);
            var client = new ClientsApi.ClientsApiClient(channel);
            _logger.LogInformation("grpc client created, request = { @id}", clientId);
            try
            {
                var response = client.GetClientById(new ClientRequest { ClientId = 1 });
                _logger.LogDebug("grpc response {@response}", response);

                return Task.FromResult(MapToClientsInfo(response));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private ClientInfo MapToClientsInfo(ClientResponse clientResponse)
        {
            return new ClientInfo
            {
                clientId = clientResponse.ClientId,
                clientInn = clientResponse.ClientInn,
                clientName = clientResponse.ClientName,
                clientsHolding = clientResponse.ClientsHolding
            };
        }
    }
}
