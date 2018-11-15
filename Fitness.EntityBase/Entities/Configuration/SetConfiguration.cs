using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.Configuration
{
    public class SetConfiguration : IEntityTypeConfiguration<SetEntity>
    {
        public void Configure(EntityTypeBuilder<SetEntity> builder)
        {
            builder.ToTable("Sets").HasKey(s => s.Id);
            builder.Property(s => s.isMissed).HasColumnType("bit").IsRequired();
            builder.Property(s => s.Comment).HasMaxLength(512);
            builder.HasOne(s => s.Exercise).WithMany(e => e.Sets).HasForeignKey("FK_Sets_ProgramExercises");

            builder.Property(s => s.PlannedReps).IsRequired();
            builder.Property(s => s.PlannedWeight).IsRequired();
        }
    }
}
