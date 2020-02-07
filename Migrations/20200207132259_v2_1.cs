using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWork.Migrations
{
    public partial class v2_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Profession = table.Column<string>(nullable: false),
                    Index = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => new { x.Profession, x.Index });
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<string>(nullable: false),
                    TeacherID = table.Column<string>(nullable: false),
                    StartYear = table.Column<int>(nullable: false),
                    EndYear = table.Column<int>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Credit = table.Column<decimal>(nullable: false),
                    PeriodThr = table.Column<int>(nullable: false),
                    PeriodExp = table.Column<int>(nullable: false),
                    CountNormal = table.Column<int>(nullable: false),
                    CountNonRetake = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    ExamType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubjectID",
                table: "Course",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherID",
                table: "Course",
                column: "TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
