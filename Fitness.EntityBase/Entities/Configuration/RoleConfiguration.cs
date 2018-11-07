using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.Configuration
{
    class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Role").HasKey(u => u.Id).ForSqlServerIsClustered();
            builder.Property(u => u.Role).IsRequired().HasMaxLength(100);

            builder.HasData(new RoleEntity { Id = 1, Role = "user", Description = "simple user" });
            builder.HasData(new RoleEntity { Id = 2, Role = "admin", Description = "simple admin" });
            builder.HasData(new RoleEntity { Id = 3, Role = "trainer", Description = "simple trainer" });
        }
    }
}
