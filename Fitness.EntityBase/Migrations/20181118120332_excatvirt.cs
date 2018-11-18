using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.EntityBase.Migrations
{
    public partial class excatvirt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 18, 12, 3, 31, 937, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 11, 9, 31, 68, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2018, 11, 18, 12, 3, 31, 946, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2018, 11, 18, 12, 3, 31, 947, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ExerciseCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2018, 11, 18, 12, 3, 31, 947, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 16, 11, 9, 31, 68, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2018, 11, 18, 12, 3, 31, 937, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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
        }
    }
}
