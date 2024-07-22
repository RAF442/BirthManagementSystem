using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFkBabiesApgarScoresApgarScoreId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApgarScoreId",
                schema: "birth_management_system",
                table: "Babies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Babies_ApgarScoreId",
                schema: "birth_management_system",
                table: "Babies",
                column: "ApgarScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Babies_ApgarScores_ApgarScoreId",
                schema: "birth_management_system",
                table: "Babies",
                column: "ApgarScoreId",
                principalSchema: "birth_management_system",
                principalTable: "ApgarScores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Babies_ApgarScores_ApgarScoreId",
                schema: "birth_management_system",
                table: "Babies");

            migrationBuilder.DropIndex(
                name: "IX_Babies_ApgarScoreId",
                schema: "birth_management_system",
                table: "Babies");

            migrationBuilder.DropColumn(
                name: "ApgarScoreId",
                schema: "birth_management_system",
                table: "Babies");
        }
    }
}
