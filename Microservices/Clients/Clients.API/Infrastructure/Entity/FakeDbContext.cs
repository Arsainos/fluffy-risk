using System.Threading;
using System.Threading.Tasks;

namespace Clients.API.Infrastructure.Entity
{    
    public class FakeDbContext : IDbContext
    {
        //public FakeDbSet<User> Users { get; set; }
        //public FakeDbContext() => Users = new FakeDbSet<User>();
        public int SaveChanges => 0;

        public Task<int> GetSaveChangesAsync()
        {
            return Task<int>.Factory.StartNew(() => 1);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }
        protected virtual void Dispose(bool disposing) { }

        public void Dispose() => Dispose(true);
        public FakeDbSet<TEntity> Set<TEntity>() where TEntity : class => throw new System.NotImplementedException();
    }
}

