using Microsoft.EntityFrameworkCore.Query;
using MostafaProject.Domain;
using System.Linq.Expressions;

namespace MostafaProject.infrastructure.Interface
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entites);
        Task<TEntity> FindAsync(
              Expression<Func<TEntity, bool>> filterPredicate
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,object>> Include = null
            , bool asNoTracking = false, Expression<Func<TEntity, TEntity>>? select = null, bool asSplit = false);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
        Task<IEnumerable<TEntity>> GetAllAsync(
              Expression<Func<TEntity, bool>> filterPredicate
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? Include = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            , Expression<Func<TEntity, TEntity>>? select = null,int? take = null);
        Task<IQueryable<TEntity>> GetAllQueryableAsync(
              Expression<Func<TEntity, bool>> filterPredicate
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Include = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<(IEnumerable<TEntity>, int)> GetPaginatedAsync(
              Expression<Func<TEntity, bool>>? filterPredicate = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? Include = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Pagination? pagentation = null
            , Expression<Func<TEntity, TEntity>>? select = null, bool asSplit = false);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entites);
        Task<bool> IsExists(Expression<Func<TEntity, bool>> filterPredicate);
        Task<int> MaxAsync(Expression<Func<TEntity, int>> filterPredicate, Expression<Func<TEntity, bool>>? filter = null);
        Task<ulong> MaxAsync(Expression<Func<TEntity, ulong>> filterPredicate, Expression<Func<TEntity, bool>>? filter = null);
        void Delete(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
