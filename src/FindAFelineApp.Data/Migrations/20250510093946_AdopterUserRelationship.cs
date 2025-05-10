using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindAFelineApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdopterUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Adopters",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Adopters_UserId",
                table: "Adopters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adopters_AspNetUsers_UserId",
                table: "Adopters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adopters_AspNetUsers_UserId",
                table: "Adopters");

            migrationBuilder.DropIndex(
                name: "IX_Adopters_UserId",
                table: "Adopters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Adopters");
        }
    }
}
