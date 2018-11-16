using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.EntityBase.Migrations
{
    public partial class WorkoutTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 10, 36, 14, 57, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2018, 11, 7, 13, 48, 54, 18, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 512, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Program_Owner",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Program_MyPrograms",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExerciseId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategory", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FR_ExerciseCategory_Exercises",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FR_ExerciseCategory_Categories",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramExercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProgramId = table.Column<int>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Scheduled = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FR_Exercise_ProgramExercises",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FR_Program_ProgramExercises",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_Sets_ProgramExercises = table.Column<int>(nullable: true),
                    PlannedWeight = table.Column<double>(nullable: false),
                    PlannedReps = table.Column<int>(nullable: false),
                    ActualWeight = table.Column<double>(nullable: false),
                    ActualReps = table.Column<int>(nullable: false),
                    isMissed = table.Column<bool>(type: "bit", nullable: false),
                    Video = table.Column<string>(nullable: true),
                    Done = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_ProgramExercises_FK_Sets_ProgramExercises",
                        column: x => x.FK_Sets_ProgramExercises,
                        principalTable: "ProgramExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, null, "pw.jpg", "Powerlifting" },
                    { 2, null, "bb.jpg", "Bodybuilding" },
                    { 3, null, "wl.jpg", "WightLifting" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Bench Press" },
                    { 2, null, "Deadlift" },
                    { 3, null, "Squats" },
                    { 4, null, "French Press" },
                    { 5, null, "Push-ups" },
                    { 6, null, "Clean & jerk" },
                    { 7, null, "Snatch" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategories_CategoryId",
                table: "ExerciseCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategories_ExerciseId",
                table: "ExerciseCategories",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramExercises_ExerciseId",
                table: "ProgramExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramExercises_ProgramId",
                table: "ProgramExercises",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_OwnerId",
                table: "Programs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_UserId",
                table: "Programs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_FK_Sets_ProgramExercises",
                table: "Sets",
                column: "FK_Sets_ProgramExercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseCategories");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProgramExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 7, 13, 48, 54, 18, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 10, 36, 14, 57, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
