using MostafaProject.Domain;
using MostafaProject.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using MostafaProject.infrastructure.Interface;
using MostafaProject.infrastructure.Implementation;

namespace MostafaProject.Infrastructure.Implemntation
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext
    {
        private Dictionary<Type, object> _repositories;
        public TContext Context { get; }
        public UnitOfWork(TContext context)
        {
            Context = context;
            _repositories = new Dictionary<Type, object>();
        }
        public void ClearTracker()
        {
            Context.ChangeTracker.Clear();
        }

        public void Dispose()
        {
            Context.Dispose();
            _repositories.Clear();
            _repositories = null;
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new GenericRepository<T, TContext>(Context);
            return (IGenericRepository<T>)_repositories[type];
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
