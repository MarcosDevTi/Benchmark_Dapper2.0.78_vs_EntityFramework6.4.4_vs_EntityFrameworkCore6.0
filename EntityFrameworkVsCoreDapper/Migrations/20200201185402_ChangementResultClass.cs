using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class ChangementResultClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Tempo",
                table: "Results");

            migrationBuilder.AddColumn<double>(
                name: "RamMax",
                table: "Results",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RamMin",
                table: "Results",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoMax",
                table: "Results",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoMin",
                table: "Results",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RamMax",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "RamMin",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TempoMax",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TempoMin",
                table: "Results");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Ram",
                table: "Results",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Tempo",
                table: "Results",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
