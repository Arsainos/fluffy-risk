using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clients.API.Infrastructure.Entity
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges { get; }
        Task<int> GetSaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);       
    }
}

