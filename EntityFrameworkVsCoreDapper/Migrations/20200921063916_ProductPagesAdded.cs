using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class ProductPagesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductPageId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductPageId",
                table: "Products",
                column: "ProductPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductPages_ProductPageId",
                table: "Products",
                column: "ProductPageId",
                principalTable: "ProductPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductPages_ProductPageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductPages");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductPageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPageId",
                table: "Products");
        }
    }
}
