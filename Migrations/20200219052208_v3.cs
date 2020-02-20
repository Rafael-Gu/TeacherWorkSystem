using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWork.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birth",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Teacher");

            migrationBuilder.AddColumn<int>(
                name: "PeriodTsk",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Task",
                table: "Course",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodTsk",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Task",
                table: "Course");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birth",
                table: "Teacher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
