using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.EntityBase.Migrations
{
    public partial class UserNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "User",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2018, 11, 7, 13, 48, 54, 18, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isBanned",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "User");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "User");

            migrationBuilder.DropColumn(
                name: "isBanned",
                table: "User");
        }
    }
}
