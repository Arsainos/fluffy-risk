using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clients.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clients.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository _repository;

        public ClientsController(ILogger<ClientsController> logger, IClientsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получает информацию по конкретному клиенту.
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        ///     Id это уникальный идентификатор клиента.
        /// 
        ///     GET /Clients/1
        ///    
        /// Пример ответа:
        ///     
        ///     {
        ///         clientId: 1,
        ///         clientInn: 988979344,
        ///         clientName: 'Рога и копыта',
        ///         clientsHolding: '12 Стульев'
        ///     }
        /// 
        /// </remarks>
        /// <returns>Информация по клиенту</returns>
        /// <response code="200">Найдена информация по клиенту</response>
        /// <response code="400">Клиент не найден</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ClientInfo), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ClientInfo), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClientInfo>> GetClientInfoByIdAsync()
        {
            var client = await _repository.GetClientInfoAsync(Convert.ToInt32(Request.RouteValues["id"]));

            return Ok(client);
        }

        /// <summary>
        /// Создание нового клиента
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        ///     Указывать Id для клиента при запросе не нужно
        /// 
        ///     POST /Clients/CreateClient
        ///     
        ///     {
        ///             clientInn: 1234567890,
        ///             clientName: 'Новая компания',
        ///             clientsHolding: 'Группа новых компаний'
        ///     }
        ///     
        /// Пример ответа:
        /// 
        ///     {
        ///         [integer]: 12
        ///     }
        /// </remarks>
        /// <param name="client">Информация по новому клиенту</param>
        /// <returns>Идентификатор нового созданого клиента</returns>
        /// <response code="200">Создан новый клиент</response>
        /// <response code="400">Ошибка создания клиента</response>
        [Route("CreateClient")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]      
        public async Task<ActionResult<int>> CreateClientAsync([FromBody]ClientInfo client)
        {
            return Ok(await _repository.CreateClientAsync(client));
        }

        /// <summary>
        /// Обновление информации по клиенту
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        ///     ClientId - уникальный идентификатор клиента
        /// 
        ///     POST /Clients/UpdateClient
        ///     
        ///     {
        ///         clientId: 1,
        ///         clientInn: 988979344,
        ///         clientName: 'Рога и копыта',
        ///         clientsHolding: '12 Стульев'
        ///     }
        ///     
        /// Пример ответа:
        /// 
        ///     {
        ///         clientId: 1,
        ///         clientInn: 988979344,
        ///         clientName: 'Измененное название',
        ///         clientsHolding: 'Другая группа компаний'
        ///     }
        /// </remarks>
        /// <param name="client">Информация по клиенту, которую нужно изменить</param>
        /// <returns>Обновленная информация по клиенту</returns>
        /// <response code="200">Клиент обновлен</response>
        /// <response code="400">Ошибка обновления клиента</response>
        [Route("UpdateClient")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ClientInfo), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<ClientInfo>> UpdateClientAsync(ClientInfo client)
        {
            return Ok(await _repository.UpdateClientInfoAsync(client));
        }

        /// <summary>
        /// Удаляет конкретного клиента по его идентификатору.
        /// </summary>
        /// <remarks>
        /// Id это уникальный идентификатор клиента.
        /// </remarks>
        /// <returns>BOOLEAN результат выполнения удаления. True - если клиент удален. False - клиент не удален или его не существует.</returns>
        /// <response code="201">Объект успешно удален.</response>
        /// <response code="400">Если объект не найден или произошла ошибка.</response>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteClientAsync()
        {
            return Ok(await _repository.DeleteClientInfoAsync(Convert.ToInt32(Request.RouteValues["id"])));
        }

        /// <summary>
        /// Получает информацию о всех клиентах в БД
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     GET /Clients
        /// 
        /// Пример ответа:
        ///     
        ///         {
        ///             clientId: 1,
        ///             clientInn: 988979344,
        ///             clientName: 'Рога и копыта',
        ///             clientsHolding: '12 Стульев'
        ///         },
        ///         {
        ///             clientId: 2,
        ///             clientInn: 8374985793487,
        ///             clientName: 'Напитки из Черноголовки',
        ///             clientsHolding: 'Вкусные напитки'
        ///         },
        ///         ...
        ///     
        /// </remarks>
        /// <returns>Информация по всем клиентам</returns>
        /// <response code="200">Найдена информация по клиентам</response>
        /// <response code="400">Клиенты не найдены</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ClientInfo>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientInfo>>> GetClients()
        {
            return Ok(await _repository.GetClients());
        }
    }
}