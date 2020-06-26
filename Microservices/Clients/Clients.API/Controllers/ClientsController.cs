using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clients.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clients.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository _repository;

        public ClientsController(ILogger<ClientsController> logger, IClientsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientInfo), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClientInfo>> GetClientInfoByIdAsync()
        {
            var client = await _repository.GetClientInfoAsync(Convert.ToInt32(Request.Query["id"]));

            return Ok(client);
        }

        [Route("CreateClient")]
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateClientAsync([FromBody]ClientInfo client)
        {
            return Ok(await _repository.CreateClientAsync(client));
        }

        [Route("UpdateClient")]
        [HttpPost]
        [ProducesResponseType(typeof(ClientInfo), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClientInfo>> UpdateClientAsync(ClientInfo client)
        {
            return Ok(await _repository.UpdateClientInfoAsync(client));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteClientAsync()
        {
            return Ok(await _repository.DeleteClientInfoAsync(Convert.ToInt32(Request.Query["id"])));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientInfo>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientInfo>>> GetClients()
        {
            return Ok(await _repository.GetClients());
        }
    }
}