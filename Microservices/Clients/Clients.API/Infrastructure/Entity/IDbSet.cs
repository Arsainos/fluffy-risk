using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Clients.API.Infrastructure.Entity
{    
    public interface IDbSet<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable where TEntity : class
    {
        ObservableCollection<TEntity> Local { get; }        
        TEntity Add(TEntity entity);
        TEntity Attach(TEntity entity);
        TEntity Create();
        TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity;        
        TEntity Find(params object[] keyValues);        
        TEntity Remove(TEntity entity);
    }
}