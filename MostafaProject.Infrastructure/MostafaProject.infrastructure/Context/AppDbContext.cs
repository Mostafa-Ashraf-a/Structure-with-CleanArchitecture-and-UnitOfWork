using Microsoft.EntityFrameworkCore;
using MostafaProject.Domain.Entities;
using MostafaProject.infrastructure.Interface;
using MostafaProject.infrastructure.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MostafaProject.infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var type = typeof(IEntityConfiguration);
            // Get All configuration classes that's inherit from IEntityConfiguration interface
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), a => a.GetInterfaces().Contains(type));
            // Add Demo Data In Demo Entity
            modelBuilder.SetSeed();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
            configurationBuilder.Properties<decimal>().HaveColumnType("decimal(8,2)");
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }
    }
}
