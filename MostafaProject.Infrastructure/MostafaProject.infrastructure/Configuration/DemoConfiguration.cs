using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MostafaProject.Domain.Entities;
using MostafaProject.infrastructure.Interface;

namespace MostafaProject.infrastructure.Configuration
{
    public class DemoConfiguration : BaseConfiguration<Book> , IEntityConfiguration
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);
            builder.Property( e => e.Name ).IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Notes)
               .HasMaxLength(int.MaxValue);
            builder.Property(e => e.Description)
               .HasMaxLength(1000);

        }
    }
}
