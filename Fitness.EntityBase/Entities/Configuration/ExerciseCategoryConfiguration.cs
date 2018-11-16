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
            builder.ToTable("ExerciseCategories").HasKey(ex => ex.Id).HasName("PK_ExerciseCategory").ForSqlServerIsClustered();
            builder.HasOne(ec => ec.Category).WithMany(c => c.Exercises).HasForeignKey(ec => ec.CategoryId).HasConstraintName("FR_ExerciseCategory_Exercises");
            builder.HasOne(ec => ec.Exercise).WithMany(c => c.Categories).HasForeignKey(ec => ec.ExerciseId).HasConstraintName("FR_ExerciseCategory_Categories");


            builder.HasData(new ExerciseCategoryEntity() { Id = 1, CategoryId = 1, ExerciseId = 1, Created = DateTime.UtcNow });
            builder.HasData(new ExerciseCategoryEntity() { Id = 2, CategoryId = 1, ExerciseId = 2, Created = DateTime.UtcNow });
            builder.HasData(new ExerciseCategoryEntity() { Id = 3, CategoryId = 1, ExerciseId = 3, Created = DateTime.UtcNow });
        }
    }
}
