using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitness.EntityBase.Entities.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories").HasKey(c => c.Id).ForSqlServerIsClustered().HasName("PK_Category");
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Image).IsRequired();

            builder.HasData(new CategoryEntity() { Id = 1, Name = "Powerlifting", Image = "pw.jpg" });
            builder.HasData(new CategoryEntity() { Id = 2, Name = "Bodybuilding", Image = "bb.jpg" });
            builder.HasData(new CategoryEntity() { Id = 3, Name = "WightLifting", Image = "wl.jpg" });
        }
    }
}
