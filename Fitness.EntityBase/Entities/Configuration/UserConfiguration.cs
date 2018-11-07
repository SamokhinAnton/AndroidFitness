using Fitness.EntityBase.Entities.dbo;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User").HasKey(u => u.Id).ForSqlServerIsClustered();
            builder.Property(u => u.Login).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Name).IsRequired().IsUnicode().HasMaxLength(256);
            builder.HasOne(u => u.Role).WithMany(r => r.Users).HasConstraintName("FK_User_Role").OnDelete(DeleteBehavior.Restrict); //.HasForeignKey(u => u.Role)
            builder.Property(u => u.Soil).IsRequired().HasValueGenerator<SoilGenerator>();
        }

        public class SoilGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => true;

            protected override object NextValue(EntityEntry entry)
            {
                return "asdfg";
            }
        }
    }
}
