using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.EntityBase.Migrations
{
    public partial class WorkoutTablesFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FR_ExerciseCategory_Exercises",
                table: "ExerciseCategories");

            migrationBuilder.DropForeignKey(
                name: "FR_ExerciseCategory_Categories",
                table: "ExerciseCategories");

            migrationBuilder.DropForeignKey(
                name: "FR_Exercise_ProgramExercises",
                table: "ProgramExercises");

            migrationBuilder.DropForeignKey(
                name: "FR_Program_ProgramExercises",
                table: "ProgramExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Sets_ProgramExercises_FK_Sets_ProgramExercises",
                table: "Sets");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 11, 6, 4, 565, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 10, 36, 14, 57, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "FK_Sets_ProgramExercises",
                table: "Sets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Sets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Programs",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Programs",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgramId",
                table: "ProgramExercises",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ProgramExercises",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ExerciseCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ExerciseCategories",
                columns: new[] { "Id", "CategoryId", "Created", "ExerciseId" },
                values: new object[] { 1, 1, new DateTime(2018, 11, 16, 11, 6, 4, 573, DateTimeKind.Utc), 1 });

            migrationBuilder.InsertData(
                table: "ExerciseCategories",
                columns: new[] { "Id", "CategoryId", "Created", "ExerciseId" },
                values: new object[] { 2, 1, new DateTime(2018, 11, 16, 11, 6, 4, 573, DateTimeKind.Utc), 2 });

            migrationBuilder.InsertData(
                table: "ExerciseCategories",
                columns: new[] { "Id", "CategoryId", "Created", "ExerciseId" },
                values: new object[] { 3, 1, new DateTime(2018, 11, 16, 11, 6, 4, 573, DateTimeKind.Utc), 3 });

            migrationBuilder.AddForeignKey(
                name: "FR_ExerciseCategory_Exercises",
                table: "ExerciseCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FR_ExerciseCategory_Categories",
                table: "ExerciseCategories",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FR_Exercise_ProgramExercises",
                table: "ProgramExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FR_Program_ProgramExercises",
                table: "ProgramExercises",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_ProgramExercises_FK_Sets_ProgramExercises",
                table: "Sets",
                column: "FK_Sets_ProgramExercises",
                principalTable: "ProgramExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FR_ExerciseCategory_Exercises",
                table: "ExerciseCategories");

            migrationBuilder.DropForeignKey(
                name: "FR_ExerciseCategory_Categories",
                table: "ExerciseCategories");

            migrationBuilder.DropForeignKey(
                name: "FR_Exercise_ProgramExercises",
                table: "ProgramExercises");

            migrationBuilder.DropForeignKey(
                name: "FR_Program_ProgramExercises",
                table: "ProgramExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Sets_ProgramExercises_FK_Sets_ProgramExercises",
                table: "Sets");

            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Sets");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 10, 36, 14, 57, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 11, 6, 4, 565, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "FK_Sets_ProgramExercises",
                table: "Sets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Programs",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Programs",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "ProgramId",
                table: "ProgramExercises",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ProgramExercises",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ExerciseCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FR_ExerciseCategory_Exercises",
                table: "ExerciseCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FR_ExerciseCategory_Categories",
                table: "ExerciseCategories",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FR_Exercise_ProgramExercises",
                table: "ProgramExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FR_Program_ProgramExercises",
                table: "ProgramExercises",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_ProgramExercises_FK_Sets_ProgramExercises",
                table: "Sets",
                column: "FK_Sets_ProgramExercises",
                principalTable: "ProgramExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
