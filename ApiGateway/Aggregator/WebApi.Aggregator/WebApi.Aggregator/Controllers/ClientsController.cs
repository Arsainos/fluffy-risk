﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Aggregator.services;
using WebApi.Aggregator.Models;

namespace WebApi.Aggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clients;

        public ClientsController(IClientsService clientsService)
        {
            _clients = clientsService;
        }

        /// <summary>
        /// Get Client information from database by unique id.
        /// </summary>
        /// <remarks>
        /// Sample request: 
        ///     
        ///     POST /Clietns
        ///     {
        ///         "clientId":1
        ///     }
        ///     
        /// </remarks>
        /// <param name="clientId"></param>
        /// <returns>Client Information by unique identifier.</returns>
        /// <response code="200">Client Info exists in data base</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientInfo>> GetClientInfoByIdAsync(int clientId)
        {
            return await _clients.GetClientById(clientId);
        }
    }
}