using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class ProductUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductNumber",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
