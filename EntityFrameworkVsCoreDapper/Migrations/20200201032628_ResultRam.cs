using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class ResultRam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Ram",
                table: "Results",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Results");
        }
    }
}
