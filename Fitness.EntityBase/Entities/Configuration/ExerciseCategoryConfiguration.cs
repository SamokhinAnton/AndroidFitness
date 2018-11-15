using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.EntityBase.Entities.Configuration
{
    public class ExerciseCategoryConfiguration : IEntityTypeConfiguration<ExerciseCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseCategoryEntity> builder)
        {
            builder.ToTable("ExerciseCategories").HasKey(ex => ex.Id);
            builder.HasOne(ec => ec.Category).WithMany(c => c.Exercises).HasConstraintName("FR_ExerciseCategory_Exercises");
            builder.HasOne(ec => ec.Exercise).WithMany(c => c.Categories).HasConstraintName("FR_ExerciseCategory_Categories");
        }
    }
}
