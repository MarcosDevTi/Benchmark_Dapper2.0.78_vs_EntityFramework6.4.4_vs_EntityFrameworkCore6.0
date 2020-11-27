using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class Customer_Id_Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_Customer_Id",
                table: "Products",
                column: "Customer_Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_Customer_Id",
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
    }
}
