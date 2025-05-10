using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindAFelineApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FosterParentSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FosterParentId",
                table: "Cats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cats_FosterParentId",
                table: "Cats",
                column: "FosterParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_FosterParents_FosterParentId",
                table: "Cats",
                column: "FosterParentId",
                principalTable: "FosterParents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_FosterParents_FosterParentId",
                table: "Cats");

            migrationBuilder.DropIndex(
                name: "IX_Cats_FosterParentId",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "FosterParentId",
                table: "Cats");
        }
    }
}
