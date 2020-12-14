using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class name_table_changement_remove_index_id_mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "efdp_address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    number = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    city = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    country = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    zip_code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    administrative_region = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_efdp_address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "efdp_product_page",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    small_description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    full_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    image_link = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_efdp_product_page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeTransaction = table.Column<int>(type: "int", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TempoMin = table.Column<TimeSpan>(type: "time", nullable: false),
                    TempoMax = table.Column<TimeSpan>(type: "time", nullable: false),
                    RamMin = table.Column<double>(type: "float", nullable: false),
                    RamMax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "efdp_customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_efdp_customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_efdp_customer_efdp_address_address_id",
                        column: x => x.address_id,
                        principalTable: "efdp_address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "efdp_product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    old_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    product_page_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_efdp_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_efdp_product_efdp_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "efdp_customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_efdp_product_efdp_product_page_product_page_id",
                        column: x => x.product_page_id,
                        principalTable: "efdp_product_page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_efdp_customer_address_id",
                table: "efdp_customer",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_efdp_customer_email",
                table: "efdp_customer",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_efdp_product_customer_id",
                table: "efdp_product",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_efdp_product_name",
                table: "efdp_product",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_efdp_product_product_page_id",
                table: "efdp_product",
                column: "product_page_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "efdp_product");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "efdp_customer");

            migrationBuilder.DropTable(
                name: "efdp_product_page");

            migrationBuilder.DropTable(
                name: "efdp_address");
        }
    }
}
