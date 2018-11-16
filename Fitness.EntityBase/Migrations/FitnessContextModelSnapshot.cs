﻿// <auto-generated />
using System;
using Fitness.EntityBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fitness.EntityBase.Migrations
{
    [DbContext(typeof(FitnessContext))]
    partial class FitnessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id")
                        .HasName("PK_Category")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Image = "pw.jpg", Name = "Powerlifting" },
                        new { Id = 2, Image = "bb.jpg", Name = "Bodybuilding" },
                        new { Id = 3, Image = "wl.jpg", Name = "WightLifting" }
                    );
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.ExerciseCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("Created");

                    b.Property<int>("ExerciseId");

                    b.HasKey("Id")
                        .HasName("PK_ExerciseCategory")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("CategoryId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseCategories");

                    b.HasData(
                        new { Id = 1, CategoryId = 1, Created = new DateTime(2018, 11, 16, 11, 9, 31, 76, DateTimeKind.Utc), ExerciseId = 1 },
                        new { Id = 2, CategoryId = 1, Created = new DateTime(2018, 11, 16, 11, 9, 31, 76, DateTimeKind.Utc), ExerciseId = 2 },
                        new { Id = 3, CategoryId = 1, Created = new DateTime(2018, 11, 16, 11, 9, 31, 76, DateTimeKind.Utc), ExerciseId = 3 }
                    );
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.ExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new { Id = 1, Name = "Bench Press" },
                        new { Id = 2, Name = "Deadlift" },
                        new { Id = 3, Name = "Squats" },
                        new { Id = 4, Name = "French Press" },
                        new { Id = 5, Name = "Push-ups" },
                        new { Id = 6, Name = "Clean & jerk" },
                        new { Id = 7, Name = "Snatch" }
                    );
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.ProgramEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(512);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<Guid>("OwnerId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.ProgramExercisesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(512);

                    b.Property<DateTime>("Created");

                    b.Property<int>("ExerciseId");

                    b.Property<int>("ProgramId");

                    b.Property<DateTime>("Scheduled");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramExercises");
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Role");

                    b.HasData(
                        new { Id = 1, Description = "simple user", Role = "user" },
                        new { Id = 2, Description = "simple admin", Role = "admin" },
                        new { Id = 3, Description = "simple trainer", Role = "trainer" }
                    );
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.SetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActualReps");

                    b.Property<double>("ActualWeight");

                    b.Property<string>("Comment")
                        .HasMaxLength(512);

                    b.Property<DateTime>("Done");

                    b.Property<int>("ExerciseId");

                    b.Property<int>("PlannedReps");

                    b.Property<double>("PlannedWeight");

                    b.Property<string>("Video");

                    b.Property<bool>("isMissed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2018, 11, 16, 11, 9, 31, 68, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("LastName");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("Soil");

                    b.Property<bool>("isActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("isBanned")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.ExerciseCategoryEntity", b =>
                {
                    b.HasOne("Fitness.EntityBase.Entities.dbo.CategoryEntity", "Category")
                        .WithMany("Exercises")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FR_ExerciseCategory_Exercises")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fitness.EntityBase.Entities.dbo.ExerciseEntity", "Exercise")
                        .WithMany("Categories")
                        .HasForeignKey("ExerciseId")
                        .HasConstraintName("FR_ExerciseCategory_Categories")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.ProgramEntity", b =>
                {
                    b.HasOne("Fitness.EntityBase.Entities.dbo.UserEntity", "Owner")
                        .WithMany("CreatedPrograms")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_Program_Owner")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Fitness.EntityBase.Entities.dbo.UserEntity", "User")
                        .WithMany("MyPrograms")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Program_MyPrograms")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.ProgramExercisesEntity", b =>
                {
                    b.HasOne("Fitness.EntityBase.Entities.dbo.ExerciseEntity", "Exercise")
                        .WithMany("ProgramExercises")
                        .HasForeignKey("ExerciseId")
                        .HasConstraintName("FR_Exercise_ProgramExercises")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fitness.EntityBase.Entities.dbo.ProgramEntity", "Program")
                        .WithMany("ProgramExercises")
                        .HasForeignKey("ProgramId")
                        .HasConstraintName("FR_Program_ProgramExercises")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.SetEntity", b =>
                {
                    b.HasOne("Fitness.EntityBase.Entities.dbo.ProgramExercisesEntity", "Exercise")
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId")
                        .HasConstraintName("FK_Sets_ProgramExercises")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fitness.EntityBase.Entities.dbo.UserEntity", b =>
                {
                    b.HasOne("Fitness.EntityBase.Entities.dbo.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_User_Role")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
