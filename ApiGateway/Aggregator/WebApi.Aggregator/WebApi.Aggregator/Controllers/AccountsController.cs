using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Aggregator.Models;
using WebApi.Aggregator.services;

namespace WebApi.Aggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accounts;

        public AccountsController(IAccountsService accountsService)
        {
            _accounts = accountsService;
        }

        /// <summary>
        /// Получает информацию по конкретному клиенту.
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        ///     Id это уникальный идентификатор пользователя.
        /// 
        ///     GET /Accounts/1
        ///    
        /// Пример ответа:
        ///     
        ///     {
        ///         Id: '1',
        ///         Name: IvanovII,
        ///         Roles: ['Менеджер']
        ///     }
        /// 
        /// </remarks>
        /// <returns>Информация по пользователю</returns>
        /// <response code="200">Найдена информация по пользователю</response>
        /// <response code="400">Аккаунт не найден</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AccountInfo), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountInfo>> GetAccountInfoByIdAsync()
        {
            return await _accounts.GetAccountById(RouteData.Values["id"].ToString());
        }

        /// <summary>
        /// Получает информацию о всех пользователях в БД
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        /// 
        ///     GET /Accounts
        /// 
        /// Пример ответа:
        ///     
        ///         {
        ///             Id: '1',
        ///             Inn: 'IvanovII',
        ///             Roles: ['Менеджер']
        ///         },
        ///         {
        ///             Id: '2',
        ///             Inn: 'PetrovAV',
        ///             Roles: ['Менеджер','Администратор']
        ///         },
        ///         ...
        ///     
        /// </remarks>
        /// <returns>Информация по всем пользователямм</returns>
        /// <response code="200">Найдена информация по пользователям</response>
        /// <response code="400">Пользователи не найдены</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<AccountInfo>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<AccountInfo>> GetAccounts()
        {
            return await _accounts.GetAccounts();
        }

        /// <summary>
        /// Логин в систему и получение токена для пользователя
        /// </summary>
        /// <remarks>
        /// 
        /// Пример запроса:
        ///     POST /Accounts/Login
        ///     
        ///     {
        ///             Name: 'IvanovII',
        ///             Password: [{your super secret password}]
        ///     }
        ///     
        /// Пример ответа:
        /// 
        ///     {
        ///         [string]: [{token}]
        ///     }
        /// </remarks>
        /// <param name="Name">Имя пользователя</param>
        /// <param name="Password">Секретный пароль</param>
        /// <returns>Токен для работы для конкретного пользователя</returns>
        /// <response code="200">Успешная авторизация на сервисе и получение токена</response>
        /// <response code="400">Ошибка при авторизации и получении токена</response>
        [Route("Login")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<string>> AccountLoginAsync([FromBody]string Name, [FromBody] string Password)
        {
            return await _accounts.Login(Name, Password);
        }
    }
}