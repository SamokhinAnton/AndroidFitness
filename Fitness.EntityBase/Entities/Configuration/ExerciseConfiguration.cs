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

            builder.HasData(new ExerciseEntity() { Id = 1, Name = "Bench Press"});
            builder.HasData(new ExerciseEntity() { Id = 2, Name = "Deadlift" });
            builder.HasData(new ExerciseEntity() { Id = 3, Name = "Squats" });
            builder.HasData(new ExerciseEntity() { Id = 4, Name = "French Press" });
            builder.HasData(new ExerciseEntity() { Id = 5, Name = "Push-ups" });
            builder.HasData(new ExerciseEntity() { Id = 6, Name = "Clean & jerk" });
            builder.HasData(new ExerciseEntity() { Id = 7, Name = "Snatch" });
        }
    }
}
