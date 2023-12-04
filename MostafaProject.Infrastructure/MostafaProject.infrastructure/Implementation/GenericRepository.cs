using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MostafaProject.infrastructure.Interface;
using MostafaProject.Domain;

namespace MostafaProject.infrastructure.Implementation
{
    public class GenericRepository<TEntity, Tcontext> : IGenericRepository<TEntity> where TEntity : BaseEntity where Tcontext : DbContext
    {
        private readonly Tcontext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(Tcontext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public Task AddAsync(TEntity entity)
        {
            return Task.FromResult(_dbSet.AddAsync(entity));
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entites)
        {
            return _dbSet.AddRangeAsync(entites);
        }
        /// <summary>
        /// used if you want to search on entity in database
        /// </summary>
        /// <param name="filterPredicate">Filter</param>
        /// <param name="Include"></param>
        /// <param name="asNoTracking"></param>
        /// <param name="select"></param>
        /// <param name="asSplit"></param>
        /// <returns>A single entity from EF</returns>
        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filterPredicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? Include = null, bool asNoTracking = false,
            Expression<Func<TEntity, TEntity>>? select = null,
           bool asSplit = false)
        {
            var query = _dbSet.AsQueryable();

            query = query.Where(a => !a.Is_Deleted).Where(filterPredicate);


            if (Include is not null)
                query = Include(query);
            if (asNoTracking)
                query = query.AsNoTracking();
            if (select is not null)
                query = query.Select(select);
            if (asSplit)
                query = query.AsSplitQuery();

            return query.FirstOrDefaultAsync();

        }
        public Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            var query = _dbSet.AsQueryable();

            if (orderBy is not null)
                query = orderBy(query);

            return (Task<IEnumerable<TEntity>>)query.Where(a => !a.Is_Deleted).AsAsyncEnumerable();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filterPredicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,
                object>>? Include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Expression<Func<TEntity, TEntity>>? select = null, int? take = null)
        {
            var query = _dbSet.AsQueryable();
            query = query.Where(a => !a.Is_Deleted).Where(filterPredicate);
            if (Include is not null)
                query = Include(query);
            if (orderBy is not null)
                query = orderBy(query);
            if (take is not null)
                query = query.Take(take.Value);
            if (select is not null)
                query = query.Select(select);

            //added to enhance performance
            query = query.Take(300);

            return (Task<IEnumerable<TEntity>>)query.AsAsyncEnumerable();
        }

        public async Task<IQueryable<TEntity>> GetAllQueryableAsync(Expression<Func<TEntity, bool>> filterPredicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            var query = _dbSet.AsQueryable();

            if (Include is not null)
                query = Include(query);
            if (orderBy is not null)
                query = orderBy(query);

            return await Task.FromResult(query.Where(a => !a.Is_Deleted).Where(filterPredicate));
        }
        public async Task<(IEnumerable<TEntity>, int)> GetPaginatedAsync(Expression<Func<TEntity, bool>>? filterPredicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? Include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Pagination? pagentation = null,
            Expression<Func<TEntity, TEntity>>? select = null, bool asSplit = false)
        {
            int count = 0;
            var query = _dbSet.AsNoTracking().AsQueryable();
            query = query.Where(a => !a.Is_Deleted);
            if (asSplit)
                query = query.AsSingleQuery();
            if (Include is not null)
                query = Include(query);
            if (orderBy is not null)
                query = orderBy(query);

            if (filterPredicate != null)
                query = query.Where(filterPredicate);
            if (select is not null)
                query = query.Select(select);
            if (pagentation is not null)
            {
                count = await query.CountAsync();
                query = query.Skip((pagentation.PageNumber - 1) * pagentation.PageSize).Take(pagentation.PageSize);
            }
            return (await query.ToListAsync(), count);
        }


        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public void Remove(TEntity entity)
        {

            _dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entites)
        {
            _dbSet.RemoveRange(entites);
        }
        public Task<bool> IsExists(Expression<Func<TEntity, bool>> filterPredicate)
        {
            return _dbSet.Where(a => !a.Is_Deleted).AnyAsync(filterPredicate);
        }
        public Task<int> MaxAsync(Expression<Func<TEntity, int>> filterPredicate, Expression<Func<TEntity, bool>>? filter = null)
        {

            var query = _dbSet.AsQueryable();

            if (filter is not null)
                query = query.Where(filter);
            return query.DefaultIfEmpty()
                .Select(filterPredicate)
                .DefaultIfEmpty()
                .MaxAsync();
        }
        public Task<ulong> MaxAsync(Expression<Func<TEntity, ulong>> filterPredicate, Expression<Func<TEntity, bool>>? filter = null)
        {

            var query = _dbSet.AsQueryable();

            if (filter is not null)
                query = query.Where(filter);
            return query.DefaultIfEmpty()
                .Select(filterPredicate)
                .DefaultIfEmpty()
                .MaxAsync();
        }
        public void Delete(TEntity entity)
        {
            entity.Is_Deleted = true;
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await FindAsync(a => a.Id == id);
            entity.Is_Deleted = true;
        }
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }




        
    }
}
