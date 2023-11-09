using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class correction3DbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartieGenre_Genre_genreId",
                table: "PartieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_PartieGenre_Partie_partieId",
                table: "PartieGenre");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "PartieGenre",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "partieId",
                table: "PartieGenre",
                newName: "PartieId");

            migrationBuilder.RenameIndex(
                name: "IX_PartieGenre_genreId",
                table: "PartieGenre",
                newName: "IX_PartieGenre_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartieGenre_Genre_GenreId",
                table: "PartieGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartieGenre_Partie_PartieId",
                table: "PartieGenre",
                column: "PartieId",
                principalTable: "Partie",
                principalColumn: "PartieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartieGenre_Genre_GenreId",
                table: "PartieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_PartieGenre_Partie_PartieId",
                table: "PartieGenre");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "PartieGenre",
                newName: "genreId");

            migrationBuilder.RenameColumn(
                name: "PartieId",
                table: "PartieGenre",
                newName: "partieId");

            migrationBuilder.RenameIndex(
                name: "IX_PartieGenre_GenreId",
                table: "PartieGenre",
                newName: "IX_PartieGenre_genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartieGenre_Genre_genreId",
                table: "PartieGenre",
                column: "genreId",
                principalTable: "Genre",
                principalColumn: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartieGenre_Partie_partieId",
                table: "PartieGenre",
                column: "partieId",
                principalTable: "Partie",
                principalColumn: "PartieId");
        }
    }
}
