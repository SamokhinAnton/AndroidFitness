using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.EntityBase.Migrations
{
    public partial class WorkoutTablesCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_ProgramExercises_FK_Sets_ProgramExercises",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Sets_FK_Sets_ProgramExercises",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "FK_Sets_ProgramExercises",
                table: "Sets");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 11, 9, 31, 68, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 11, 6, 4, 565, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2018, 11, 16, 11, 9, 31, 76, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2018, 11, 16, 11, 9, 31, 76, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2018, 11, 16, 11, 9, 31, 76, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Sets_ExerciseId",
                table: "Sets",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_ProgramExercises",
                table: "Sets",
                column: "ExerciseId",
                principalTable: "ProgramExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_ProgramExercises",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Sets_ExerciseId",
                table: "Sets");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 11, 6, 4, 565, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 11, 9, 31, 68, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "FK_Sets_ProgramExercises",
                table: "Sets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2018, 11, 16, 11, 6, 4, 573, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2018, 11, 16, 11, 6, 4, 573, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2018, 11, 16, 11, 6, 4, 573, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Sets_FK_Sets_ProgramExercises",
                table: "Sets",
                column: "FK_Sets_ProgramExercises");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_ProgramExercises_FK_Sets_ProgramExercises",
                table: "Sets",
                column: "FK_Sets_ProgramExercises",
                principalTable: "ProgramExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
