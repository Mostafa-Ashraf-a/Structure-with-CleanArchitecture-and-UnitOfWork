using Microsoft.EntityFrameworkCore;
using MostafaProject.Domain.Entities;

namespace MostafaProject.infrastructure.Seed
{
    public static class Seed
    {
        public static void SetSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demo>().HasData(
                new Demo
                {
                    Id = Guid.NewGuid(),
                    Created_At = DateTime.Now,
                    Description = "Demo Discription",
                    Notes = "Demo Note",
                    Name = "Demo Name",
                }
            );
        }
    }
}
