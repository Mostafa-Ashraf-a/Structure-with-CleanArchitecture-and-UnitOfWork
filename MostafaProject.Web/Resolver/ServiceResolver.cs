using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MostafaProject.Application.Implementation;
using MostafaProject.Application.Interfaces;
using MostafaProject.Infrastructure.Implemntation;
using MostafaProject.Infrastructure.Interface;

namespace MostafaProject.Web.Resolver
{
    public static class ServiceResolver
    {
        public static void AddApplicationServices ( this IServiceCollection services)
        {
            services.AddScoped<IDemoService, DemoService>();
            services.AddScoped<IMapper, Mapper>();
        }
    }
}
