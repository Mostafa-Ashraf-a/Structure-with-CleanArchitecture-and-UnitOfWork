using MostafaProject.Application.Implementation;
using MostafaProject.Application.Interfaces;
namespace MostafaProject.Web.Resolver
{
    public static class ServiceResolver
    {
        public static void AddApplicationServices ( this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
        }
    }
}
