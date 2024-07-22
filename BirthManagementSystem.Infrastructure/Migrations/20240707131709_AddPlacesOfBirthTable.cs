using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPlacesOfBirthTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlacesOfBirth",
                schema: "birth_management_system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    BabyId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesOfBirth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacesOfBirth_Babies_BabyId",
                        column: x => x.BabyId,
                        principalSchema: "birth_management_system",
                        principalTable: "Babies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacesOfBirth_BabyId",
                schema: "birth_management_system",
                table: "PlacesOfBirth",
                column: "BabyId",
                unique: true,
                filter: "[BabyId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacesOfBirth",
                schema: "birth_management_system");
        }
    }
}
