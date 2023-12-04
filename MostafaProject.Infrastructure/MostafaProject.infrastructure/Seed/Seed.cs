using Microsoft.EntityFrameworkCore;
using MostafaProject.Domain.Entities;

namespace MostafaProject.infrastructure.Seed
{
    public static class Seed
    {
        public static void SetSeed(this ModelBuilder modelBuilder)
        {
            var auther = new Auther
            {
                Id = Guid.NewGuid(),
                Name = "Mostafa",

            };
            modelBuilder.Entity<Auther>().HasData(auther);

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Name = "Mostafa's Book",
                Barcode = "68745952314",
                Description = "Demo Discription",
                AutherId = auther.Id
            };
            modelBuilder.Entity<Book>().HasData(book);
        }
            
    }
}
