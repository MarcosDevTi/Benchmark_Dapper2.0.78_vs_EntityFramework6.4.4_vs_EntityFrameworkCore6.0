using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class ResultClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tempo = table.Column<TimeSpan>(nullable: false),
                    Ram = table.Column<double>(nullable: false),
                    TypeTransaction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DapperId = table.Column<Guid>(nullable: true),
                    Ef6Id = table.Column<Guid>(nullable: true),
                    EfCoreId = table.Column<Guid>(nullable: true),
                    EfCoreAsNoTrackingId = table.Column<Guid>(nullable: true),
                    ResultId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultItems_Score_DapperId",
                        column: x => x.DapperId,
                        principalTable: "Score",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultItems_Score_Ef6Id",
                        column: x => x.Ef6Id,
                        principalTable: "Score",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultItems_Score_EfCoreAsNoTrackingId",
                        column: x => x.EfCoreAsNoTrackingId,
                        principalTable: "Score",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultItems_Score_EfCoreId",
                        column: x => x.EfCoreId,
                        principalTable: "Score",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultItems_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultItems_DapperId",
                table: "ResultItems",
                column: "DapperId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultItems_Ef6Id",
                table: "ResultItems",
                column: "Ef6Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResultItems_EfCoreAsNoTrackingId",
                table: "ResultItems",
                column: "EfCoreAsNoTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultItems_EfCoreId",
                table: "ResultItems",
                column: "EfCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultItems_ResultId",
                table: "ResultItems",
                column: "ResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultItems");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
