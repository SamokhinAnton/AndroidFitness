using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitness.EntityBase.Entities.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories").HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Image).IsRequired();
        }
    }
}
