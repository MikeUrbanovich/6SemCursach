using Microsoft.EntityFrameworkCore.Migrations;

namespace _6SemCursach.Data.Migrations
{
    public partial class DeleteFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursStud_Semesters_SemesterFK",
                table: "CoursStud");

            migrationBuilder.DropIndex(
                name: "IX_CoursStud_SemesterFK",
                table: "CoursStud");

            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "CoursStud",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursStud_SemesterId",
                table: "CoursStud",
                column: "SemesterId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CoursStud_Semesters_SemesterId",
            //    table: "CoursStud",
            //    column: "SemesterId",
            //    principalTable: "Semesters",
            //    principalColumn: "SemesterId",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursStud_Semesters_SemesterId",
                table: "CoursStud");

            migrationBuilder.DropIndex(
                name: "IX_CoursStud_SemesterId",
                table: "CoursStud");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "CoursStud");

            migrationBuilder.CreateIndex(
                name: "IX_CoursStud_SemesterFK",
                table: "CoursStud",
                column: "SemesterFK");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursStud_Semesters_SemesterFK",
                table: "CoursStud",
                column: "SemesterFK",
                principalTable: "Semesters",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
