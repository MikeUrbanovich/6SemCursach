using Microsoft.EntityFrameworkCore.Migrations;

namespace _6SemCursach.Data.Migrations
{
    public partial class add_money_for_student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Money",
                table: "Students",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "Students");
        }
    }
}
