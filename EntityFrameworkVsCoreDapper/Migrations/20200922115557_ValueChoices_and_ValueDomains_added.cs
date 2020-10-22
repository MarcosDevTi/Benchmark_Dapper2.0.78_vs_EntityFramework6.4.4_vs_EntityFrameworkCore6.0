using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class ValueChoices_and_ValueDomains_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "ProductPages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ValueDomains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueDomains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValueChoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OrderPresentation = table.Column<int>(type: "int", nullable: false),
                    ValueDomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValueChoices_ValueDomains_ValueDomainId",
                        column: x => x.ValueDomainId,
                        principalTable: "ValueDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPages_TypeId",
                table: "ProductPages",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ValueChoices_ValueDomainId",
                table: "ValueChoices",
                column: "ValueDomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPages_ValueChoices_TypeId",
                table: "ProductPages",
                column: "TypeId",
                principalTable: "ValueChoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ValueChoices_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ValueChoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPages_ValueChoices_TypeId",
                table: "ProductPages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ValueChoices_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ValueChoices");

            migrationBuilder.DropTable(
                name: "ValueDomains");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductPages_TypeId",
                table: "ProductPages");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "ProductPages");
        }
    }
}
