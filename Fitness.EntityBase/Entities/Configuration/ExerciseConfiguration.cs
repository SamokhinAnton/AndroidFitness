using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<ExerciseEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseEntity> builder)
        {
            builder.ToTable("Exercises").HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(1024);
        }
    }
}
