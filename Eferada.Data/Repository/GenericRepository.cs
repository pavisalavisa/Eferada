using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Eferada.Common.Exceptions;
using Eferada.Data.DatabaseContext;
using Eferada.Data.Model.Entities;

namespace Eferada.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity:class,IEntity
    {
        private readonly IEferadaDbContext _context;

        protected DbSet<TEntity> Set => _context.Set<TEntity>();

        public TEntity Create()
        {
            return Set.Create();
        }

        public TEntity Add(TEntity entity)
        {
            return Set.Add(entity);
        }

        public TEntity Remove(TEntity entity)
        {
            return Set.Remove(entity);
        }

        public Task<int> BatchDelete(Expression<Func<TEntity, bool>> predicate)
        {
            //return Set.Where(predicate).DeleteAsync();
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            var existing = _context.Set<TEntity>().Find(entity.Id);
            if (existing == null)
            {
                throw new DatabaseException(DatabaseErrorCode.EntityNotFound, $"Entity with id {entity.Id} not found");
            }

            _context.Entry(existing).CurrentValues.SetValues(entity);
            return existing;
        }

        public Task<int> Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> newValue)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(int id)
        {
            return Set.FindAsync(id);
        }

        public IQueryable<TEntity> Query()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetPagingAsync(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetPagingAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await GetQuery(filter, orderBy, null, null, includeProperties)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetQuery(filter, orderBy, null, null, includeProperties)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> FilterBy<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TResult>> FilterByAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool All(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AllAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> MaxAsync<TResult>(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TResult>> selector = null)
        {
            throw new NotImplementedException();
        }

        private IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip, int? take, Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Set;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            query = orderBy != null ? orderBy(query) : query;

            if (take != null && skip != null)
                query = query.Skip(skip.Value).Take(take.Value);

            return query;
        }
    }
}