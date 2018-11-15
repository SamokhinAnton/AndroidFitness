using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.Configuration
{
    class ProgramExercisesConfiguration : IEntityTypeConfiguration<ProgramExercisesEntity>
    {
        public void Configure(EntityTypeBuilder<ProgramExercisesEntity> builder)
        {
            builder.HasKey(pe => pe.Id);
            builder.HasOne(pe => pe.Program).WithMany(p => p.ProgramExercises).HasConstraintName("FR_Program_ProgramExercises");
            builder.Property(pe => pe.Comment).HasMaxLength(512);
            builder.HasOne(pe => pe.Exercise).WithMany(e => e.ProgramExercises).HasConstraintName("FR_Exercise_ProgramExercises");
        }
    }
}
