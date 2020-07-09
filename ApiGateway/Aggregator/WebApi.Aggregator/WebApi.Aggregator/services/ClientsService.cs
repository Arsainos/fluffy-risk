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
using Microsoft.AspNetCore.Http;

namespace WebApi.Aggregator.services
{
    public class ClientsService : IClientsService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<ClientsService> _logger;
        private readonly string _connection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientsService(HttpClient httpClient, ILogger<ClientsService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _logger = logger;
            _connection = Config.UrlsConfig.GrpcClients;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CreateClient(ClientInfo clientInfo)
        {
            return await GrpcCallerService.CallServiceWithCredentialsAsync(_connection, _httpContextAccessor.HttpContext.Request.Headers["Authorization"], async channel =>
            {
                var client = new ClientsGrpc.ClientsGrpcClient(channel);
                _logger.LogInformation("grpc client created, request = { @id}", clientInfo);

                var response = await client.CreateClientAsync(MapToClientReponse(clientInfo));
                _logger.LogDebug("grpc response {@response}", response);

                return response.ClientId;
            });
        }

        public async Task<bool> DeleteClient(int clientId)
        {
            return await GrpcCallerService.CallServiceWithCredentialsAsync(_connection, _httpContextAccessor.HttpContext.Request.Headers["Authorization"], async channel =>
            {
                var client = new ClientsGrpc.ClientsGrpcClient(channel);
                _logger.LogInformation("grpc client created, request = { @id}", clientId);

                var response = await client.DeleteClientAsync(new ClientRequest { ClientId = clientId });
                _logger.LogDebug("grpc response {@response}", response);

                return await Task.FromResult(response.Result);
            });
        }

        public async Task<ClientInfo> GetClientById(int clientId)
        {
            return await GrpcCallerService.CallServiceWithCredentialsAsync(_connection, _httpContextAccessor.HttpContext.Request.Headers["Authorization"], async channel =>
            {
                var client = new ClientsGrpc.ClientsGrpcClient(channel);
                _logger.LogInformation("grpc client created, request = { @id}", clientId);

                var response = await client.GetClientByIdAsync(new ClientRequest { ClientId = clientId });
                _logger.LogDebug("grpc response {@response}", response);

                return await Task.FromResult(MapToClientsInfo(response));
            });
        }

        public async Task<IEnumerable<ClientInfo>> GetClients()
        {
            return await GrpcCallerService.CallServiceWithCredentialsAsync(_connection, _httpContextAccessor.HttpContext.Request.Headers["Authorization"], async channel =>
            {
                var client = new ClientsGrpc.ClientsGrpcClient(channel);
                _logger.LogInformation("grpc get clients");

                var response = await client.GetClientsAsync(new ClientRequestWithNoParameters());
                _logger.LogDebug("grpc response {@response}", response);

                return await Task.FromResult(response.Clients.ToList().ConvertAll(new Converter<ClientResponse, ClientInfo>(MapToClientsInfo)).AsEnumerable());
            });
        }

        public async Task<ClientInfo> UpdateClientInfo(ClientInfo clientInfo)
        {
            return await GrpcCallerService.CallServiceWithCredentialsAsync(_connection, _httpContextAccessor.HttpContext.Request.Headers["Authorization"], async channel =>
            {
                var client = new ClientsGrpc.ClientsGrpcClient(channel);
                _logger.LogInformation("grpc client created, request = { @id}", clientInfo);

                var response = await client.UpdateClientInfoAsync(MapToClientReponse(clientInfo)); ;
                _logger.LogDebug("grpc response {@response}", response);

                return await Task.FromResult(MapToClientsInfo(response));
            });
        }

        private static ClientResponse MapToClientReponse(ClientInfo clientInfo)
        {
            return new ClientResponse { ClientId = clientInfo.clientId, ClientInn = clientInfo.clientInn, ClientName = clientInfo.clientName, ClientsHolding = clientInfo.clientsHolding };
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
