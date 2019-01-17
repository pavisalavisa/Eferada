using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Eferada.Data.Model.Entities;

namespace Eferada.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create();

        TEntity Add(TEntity entity);

        TEntity Remove(TEntity entity);

        Task<int> BatchDelete(Expression<Func<TEntity, bool>> predicate);

        TEntity Update(TEntity entity);

        Task<int> Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> newValue);

        Task<TEntity> FindAsync(params object[] keyValues);

        Task<TEntity> GetAsync(int id);

        IQueryable<TEntity> Query();

        Task<IEnumerable<TEntity>> GetPagingAsync(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> GetPagingAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TResult> FilterBy<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector);
        Task<IEnumerable<TResult>> FilterByAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter = null);
        bool Exists(Expression<Func<TEntity, bool>> filter = null);

        bool All(Expression<Func<TEntity, bool>> filter);
        Task<bool> AllAsync(Expression<Func<TEntity, bool>> filter);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        int Count(Expression<Func<TEntity, bool>> filter = null);

        Task<TResult> MaxAsync<TResult>(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TResult>> selector = null);
    }
}
