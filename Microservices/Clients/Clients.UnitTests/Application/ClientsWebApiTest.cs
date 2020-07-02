using Moq;
using NUnit.Framework;
using Clients.API.Model;
using Clients.API.Controllers;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Clients.UnitTests
{
    public class ClientsWebApiTest
    {
        private readonly Mock<IClientsRepository> _clientRepository;
        private readonly Mock<ILogger<ClientsController>> _loggerMock;

        public ClientsWebApiTest()
        {
            _clientRepository = new Mock<IClientsRepository>();
            _loggerMock = new Mock<ILogger<ClientsController>>();
        }

        [Test]
        public async Task GetClients()
        {
            // Arrange
            var fakeClientsList = GetFakeClientsList();

            _clientRepository.Setup(x => x.GetClients()).Returns(Task.FromResult(fakeClientsList));

            // Act
            var clientController = new ClientsController(_loggerMock.Object, _clientRepository.Object);

            var actionResult = await clientController.GetClients();
            // Assert
            Assert.AreEqual((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.NotZero((((ObjectResult)actionResult.Result).Value as List<ClientInfo>).Count);
        }

        private IEnumerable<ClientInfo> GetFakeClientsList()
        {
            return new List<ClientInfo>() 
            { 
                new ClientInfo() { Id = 1, Inn = 123456, Name = "Рога и копыта", Holding = "12 Стульев" },
                new ClientInfo() { Id = 2, Inn = 654321, Name = "Напитки из Черноголовки", Holding = "Лимонад и сладкая вода"}
            };
        }
    }
}