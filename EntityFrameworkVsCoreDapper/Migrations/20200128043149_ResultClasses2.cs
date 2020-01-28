using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkVsCoreDapper.Migrations
{
    public partial class ResultClasses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Score_DapperId",
                table: "ResultItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Score_Ef6Id",
                table: "ResultItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Score_EfCoreAsNoTrackingId",
                table: "ResultItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Score_EfCoreId",
                table: "ResultItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "Take",
                table: "Scores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeObject",
                table: "Scores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Scores_DapperId",
                table: "ResultItems",
                column: "DapperId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Scores_Ef6Id",
                table: "ResultItems",
                column: "Ef6Id",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Scores_EfCoreAsNoTrackingId",
                table: "ResultItems",
                column: "EfCoreAsNoTrackingId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Scores_EfCoreId",
                table: "ResultItems",
                column: "EfCoreId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Scores_DapperId",
                table: "ResultItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Scores_Ef6Id",
                table: "ResultItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Scores_EfCoreAsNoTrackingId",
                table: "ResultItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultItems_Scores_EfCoreId",
                table: "ResultItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Take",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "TypeObject",
                table: "Scores");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Score_DapperId",
                table: "ResultItems",
                column: "DapperId",
                principalTable: "Score",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Score_Ef6Id",
                table: "ResultItems",
                column: "Ef6Id",
                principalTable: "Score",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Score_EfCoreAsNoTrackingId",
                table: "ResultItems",
                column: "EfCoreAsNoTrackingId",
                principalTable: "Score",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultItems_Score_EfCoreId",
                table: "ResultItems",
                column: "EfCoreId",
                principalTable: "Score",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
