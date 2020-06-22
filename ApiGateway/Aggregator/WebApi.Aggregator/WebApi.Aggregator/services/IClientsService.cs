using WebApi.Aggregator.Models;
using System.Threading.Tasks;

namespace WebApi.Aggregator.services
{
    public interface IClientsService
    {
        Task<ClientInfo> GetClientById(int clientId);
    }
}
