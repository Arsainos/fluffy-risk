using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Clients.API.Model;

namespace Clients.API.Grpc
{
    public class ClientsService : ClientsGrpc.ClientsGrpcBase
    {
        private readonly ILogger<ClientsService> _logger;
        private readonly IClientsRepository _repository;
        public ClientsService(ILogger<ClientsService> logger, IClientsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public override async Task<ClientActionResult> DeleteClient(ClientRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for client id {Id}", context.Method, request.ClientId);

            var deleteResult = await _repository.DeleteClientInfoAsync(request.ClientId);

            _logger.LogInformation("client {Id} have been deleted", request.ClientId);

            return new ClientActionResult() { Result = deleteResult };
        }

        public override async Task<ClientResponse> GetClientById(ClientRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for client id {Id}", context.Method, request.ClientId);

            var clientData = await _repository.GetClientInfoAsync(request.ClientId);

            _logger.LogInformation("Client data {info}", clientData);

            return new ClientResponse()
            {
                ClientId = clientData.Id,
                ClientInn = clientData.Inn,
                ClientName = clientData.Name,
                ClientsHolding = clientData.Holding
            };
        }

        public override Task<ListClientReponse> GetClients(ClintRequestWithNoParameters request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for clients ", context.Method);

            var clients = _repository.GetClients();

            return null;
        }

        public override async Task<ClientResponse> UpdateClientInfo(ClientResponse request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for client id {Id}", context.Method, request.ClientId);

            var clientData = await _repository.UpdateClientInfoAsync(new ClientInfo() { Id = request.ClientId, Inn = request.ClientInn, Name = request.ClientName, Holding = request.ClientsHolding });

            return new ClientResponse()
            {
                ClientId = clientData.Id,
                ClientInn = clientData.Inn,
                ClientName = clientData.Name,
                ClientsHolding = clientData.Holding
            };
        }
    }
}
