using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindAFelineApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdoptionSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdopterId",
                table: "Cats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cats_AdopterId",
                table: "Cats",
                column: "AdopterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_Adopters_AdopterId",
                table: "Cats",
                column: "AdopterId",
                principalTable: "Adopters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_Adopters_AdopterId",
                table: "Cats");

            migrationBuilder.DropIndex(
                name: "IX_Cats_AdopterId",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "AdopterId",
                table: "Cats");
        }
    }
}
