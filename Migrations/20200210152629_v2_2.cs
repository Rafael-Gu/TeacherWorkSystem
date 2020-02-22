using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWork.Migrations
{
	public partial class v2_2 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ExamType",
				table: "Course");

			migrationBuilder.AddColumn<int>(
				name: "Assessment",
				table: "Course",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<string>(
				name: "Attribute",
				table: "Course",
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "IsSQE",
				table: "Course",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Assessment",
				table: "Course");

			migrationBuilder.DropColumn(
				name: "Attribute",
				table: "Course");

			migrationBuilder.DropColumn(
				name: "IsSQE",
				table: "Course");

			migrationBuilder.AddColumn<string>(
				name: "ExamType",
				table: "Course",
				type: "nvarchar(max)",
				nullable: true);
		}
	}
}
