using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Clients.API.Grpc
{
    public class ClientsService : ClientsApi.ClientsApiBase
    {
        private readonly ILogger<ClientsService> _logger;
        public ClientsService(ILogger<ClientsService> logger)
        {
            _logger = logger;
        }

        public override Task<ClientResponse> GetClientById(ClientRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for basket id {Id}", context.Method, request.ClientId);

            return Task.FromResult(new ClientResponse()
            {
                ClientId = 1,
                ClientInn = 123,
                ClientName = "Азаза",
                ClientsHolding = "Ололо"
            });
        }
    }
}
