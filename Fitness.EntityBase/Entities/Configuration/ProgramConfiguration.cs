using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.Configuration
{
    public class ProgramConfiguration : IEntityTypeConfiguration<ProgramEntity>
    {
        public void Configure(EntityTypeBuilder<ProgramEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(128).IsRequired();
            builder.Property(p => p.Comment).HasMaxLength(512);
            builder.HasOne(p => p.Owner).WithMany(u => u.CreatedPrograms).HasConstraintName("FK_Program_Owner").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.User).WithMany(u => u.MyPrograms).HasConstraintName("FK_Program_MyPrograms").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
