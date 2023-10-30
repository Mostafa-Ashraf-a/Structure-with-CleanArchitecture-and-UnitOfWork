using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MostafaProject.Domain;

namespace MostafaProject.infrastructure
{
    public class BaseConfiguration<Entity> : IEntityTypeConfiguration<Entity> where Entity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Is_Deleted);
            builder.HasIndex(e => e.Created_At);
        }
    }
}
