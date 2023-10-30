using MostafaProject.Domain;
using Microsoft.EntityFrameworkCore;
using MostafaProject.infrastructure.Interface;

namespace MostafaProject.Infrastructure.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
        void ClearTracker();
    }
    public interface IUnitOfWork<Tcontext>:IUnitOfWork where Tcontext : DbContext 
    {
        Tcontext Context { get; }
    }
}
