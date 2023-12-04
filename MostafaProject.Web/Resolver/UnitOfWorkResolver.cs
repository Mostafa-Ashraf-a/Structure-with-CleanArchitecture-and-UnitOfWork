using Microsoft.EntityFrameworkCore;
using MostafaProject.Domain;
using MostafaProject.infrastructure.Implementation;
using MostafaProject.infrastructure.Interface;
using MostafaProject.Infrastructure.Implemntation;
using MostafaProject.Infrastructure.Interface;

namespace MostafaProject.Web.Resolver
{
    public static class UnitOfWorkResolver
    {
        public static void RegisterUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
        }
    }
}
