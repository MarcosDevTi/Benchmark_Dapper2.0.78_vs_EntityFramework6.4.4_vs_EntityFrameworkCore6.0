using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class ResultChangement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Results_ResultId",
                table: "ResultItems");

            migrationBuilder.DropIndex(
                name: "IX_ResultItems_ResultId",
                table: "ResultItems");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "ResultItems");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Results",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Results",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperationType",
                table: "Results",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Tempo",
                table: "Results",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TypeTransaction",
                table: "Results",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Tempo",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TypeTransaction",
                table: "Results");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Results",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ResultId",
                table: "ResultItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultItems_ResultId",
                table: "ResultItems",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Results_ResultId",
                table: "ResultItems",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
