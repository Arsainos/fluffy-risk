using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using Clients.API.Infrastructure.Entity;

namespace Clients.API.Infrastructure.Entity
{
    public class FakeDbSet<TEntity> : IDbSet<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity> where TEntity : class
    {
        private readonly IQueryable<TEntity> _queryable;

        public FakeDbSet() => _queryable = Local.AsQueryable();

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            List<TEntity> items = entities.ToList();

            foreach (var entity in items)
                Local.Add(entity);

            return items;
        }

        public TEntity Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            Local.Add(item);

            return item;
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            List<TEntity> items = entities.ToList();

            foreach (var entity in items)
                Local.Remove(entity);

            return items;
        }

        public TEntity Remove(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            Local.Remove(item);
            return item;
        }

        public TEntity Attach(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            Local.Add(item);

            return item;
        }

        public TEntity Create() => Activator.CreateInstance<TEntity>();
        public ObservableCollection<TEntity> Local { get; } = new ObservableCollection<TEntity>();
        Type IQueryable.ElementType => _queryable.ElementType;
        Expression IQueryable.Expression => _queryable.Expression;
        IQueryProvider IQueryable.Provider => _queryable.Provider;
        IEnumerator IEnumerable.GetEnumerator() => Local.GetEnumerator();
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => Local.GetEnumerator();
        TDerivedEntity IDbSet<TEntity>.Create<TDerivedEntity>() => throw new NotImplementedException();
        public TEntity Find(params object[] keyValues) => throw new NotImplementedException();
    }
}
