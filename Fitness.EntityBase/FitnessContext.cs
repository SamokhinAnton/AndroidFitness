using Fitness.EntityBase.Entities.Configuration;
using Fitness.EntityBase.Entities.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;

namespace Fitness.EntityBase
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options)
            : base(options)
        { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ExerciseCategoryEntity> ExerciseCategories { get; set; }
        public DbSet<ExerciseEntity> Exercises { get; set; }
        public DbSet<ProgramEntity> Programs { get; set; }
        public DbSet<ProgramExercisesEntity> ProgramExercises { get; set; }
        public DbSet<SetEntity> Sets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new ExerciseCategoryConfiguration());
            builder.ApplyConfiguration(new ProgramConfiguration());
            builder.ApplyConfiguration(new ProgramExercisesConfiguration());
            builder.ApplyConfiguration(new SetConfiguration());
        }

    }
}
