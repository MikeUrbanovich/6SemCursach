using Microsoft.EntityFrameworkCore.Migrations;

namespace _6SemCursach.Data.Migrations
{
    public partial class delete_fk_teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherFK",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherFK",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherFK",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "TeacherFK",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherFK",
                table: "Courses",
                column: "TeacherFK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherFK",
                table: "Courses",
                column: "TeacherFK",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
