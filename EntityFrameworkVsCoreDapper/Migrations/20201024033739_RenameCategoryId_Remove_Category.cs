using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class RenameCategoryId_Remove_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_Customer_Id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ValueChoices_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Products",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Customer_Id",
                table: "Products",
                newName: "IX_Products_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Products",
                newName: "Customer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                newName: "IX_Products_Customer_Id");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_Customer_Id",
                table: "Products",
                column: "Customer_Id",
                principalTable: "Customers",
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
    }
}
