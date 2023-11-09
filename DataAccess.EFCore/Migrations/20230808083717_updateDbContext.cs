using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class updateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_AspNetUsers_MeneurId",
                table: "Parties");

            migrationBuilder.DropForeignKey(
                name: "FK_Seances_Parties_PartieId",
                table: "Seances");

            migrationBuilder.DropTable(
                name: "GenrePartie");

            migrationBuilder.DropTable(
                name: "JdrUserPartie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seances",
                table: "Seances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parties",
                table: "Parties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "Duree",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "Frequence",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "NbSeances",
                table: "Parties");

            migrationBuilder.RenameTable(
                name: "Seances",
                newName: "Seance");

            migrationBuilder.RenameTable(
                name: "Parties",
                newName: "Partie");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "JdrUser");

            migrationBuilder.RenameIndex(
                name: "IX_Seances_PartieId",
                table: "Seance",
                newName: "IX_Seance_PartieId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_MeneurId",
                table: "Partie",
                newName: "IX_Partie_MeneurId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "JdrUser",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Seance",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fin",
                table: "Seance",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Debut",
                table: "Seance",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Vtt",
                table: "Partie",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UrlImage",
                table: "Partie",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titre",
                table: "Partie",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Systeme",
                table: "Partie",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Statut",
                table: "Partie",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Partie",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Applis",
                table: "Partie",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Genre",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UrlAvatar",
                table: "JdrUser",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pseudo",
                table: "JdrUser",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "JdrUser",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "JdrUser",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JdrUser",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateNaiss",
                table: "JdrUser",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreaCompte",
                table: "JdrUser",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seance",
                table: "Seance",
                column: "SeanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partie",
                table: "Partie",
                column: "PartieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JdrUser",
                table: "JdrUser",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "Campagne",
                columns: table => new
                {
                    PartieId = table.Column<long>(type: "bigint", nullable: false),
                    Duree = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Frequence = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campagne", x => x.PartieId);
                    table.ForeignKey(
                        name: "FK_Campagne_Partie_PartieId",
                        column: x => x.PartieId,
                        principalTable: "Partie",
                        principalColumn: "PartieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JoueurPartie",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoueurPartie", x => new { x.UserId, x.PartieId });
                    table.ForeignKey(
                        name: "FK_JoueurPartie_JdrUser_UserId",
                        column: x => x.UserId,
                        principalTable: "JdrUser",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_JoueurPartie_Partie_PartieId",
                        column: x => x.PartieId,
                        principalTable: "Partie",
                        principalColumn: "PartieId");
                });

            migrationBuilder.CreateTable(
                name: "Oneshots",
                columns: table => new
                {
                    PartieId = table.Column<long>(type: "bigint", nullable: false),
                    NbSeances = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oneshots", x => x.PartieId);
                    table.ForeignKey(
                        name: "FK_Oneshots_Partie_PartieId",
                        column: x => x.PartieId,
                        principalTable: "Partie",
                        principalColumn: "PartieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartieGenre",
                columns: table => new
                {
                    partieId = table.Column<long>(type: "bigint", nullable: false),
                    genreId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartieGenre", x => new { x.partieId, x.genreId });
                    table.ForeignKey(
                        name: "FK_PartieGenre_Genre_genreId",
                        column: x => x.genreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId");
                    table.ForeignKey(
                        name: "FK_PartieGenre_Partie_partieId",
                        column: x => x.partieId,
                        principalTable: "Partie",
                        principalColumn: "PartieId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoueurPartie_PartieId",
                table: "JoueurPartie",
                column: "PartieId");

            migrationBuilder.CreateIndex(
                name: "IX_PartieGenre_genreId",
                table: "PartieGenre",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_JdrUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "JdrUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_JdrUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "JdrUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_JdrUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "JdrUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_JdrUser_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "JdrUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partie_JdrUser_MeneurId",
                table: "Partie",
                column: "MeneurId",
                principalTable: "JdrUser",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Partie_PartieId",
                table: "Seance",
                column: "PartieId",
                principalTable: "Partie",
                principalColumn: "PartieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_JdrUser_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_JdrUser_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_JdrUser_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_JdrUser_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Partie_JdrUser_MeneurId",
                table: "Partie");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Partie_PartieId",
                table: "Seance");

            migrationBuilder.DropTable(
                name: "Campagne");

            migrationBuilder.DropTable(
                name: "JoueurPartie");

            migrationBuilder.DropTable(
                name: "Oneshots");

            migrationBuilder.DropTable(
                name: "PartieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seance",
                table: "Seance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partie",
                table: "Partie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JdrUser",
                table: "JdrUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Seance",
                newName: "Seances");

            migrationBuilder.RenameTable(
                name: "Partie",
                newName: "Parties");

            migrationBuilder.RenameTable(
                name: "JdrUser",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameIndex(
                name: "IX_Seance_PartieId",
                table: "Seances",
                newName: "IX_Seances_PartieId");

            migrationBuilder.RenameIndex(
                name: "IX_Partie_MeneurId",
                table: "Parties",
                newName: "IX_Parties_MeneurId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Seances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fin",
                table: "Seances",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Debut",
                table: "Seances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Vtt",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UrlImage",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titre",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Systeme",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Statut",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Applis",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duree",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequence",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "NbSeances",
                table: "Parties",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UrlAvatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pseudo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateNaiss",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreaCompte",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seances",
                table: "Seances",
                column: "SeanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parties",
                table: "Parties",
                column: "PartieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.CreateTable(
                name: "GenrePartie",
                columns: table => new
                {
                    GenresGenreId = table.Column<short>(type: "smallint", nullable: false),
                    PartiesPartieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenrePartie", x => new { x.GenresGenreId, x.PartiesPartieId });
                    table.ForeignKey(
                        name: "FK_GenrePartie_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenrePartie_Parties_PartiesPartieId",
                        column: x => x.PartiesPartieId,
                        principalTable: "Parties",
                        principalColumn: "PartieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JdrUserPartie",
                columns: table => new
                {
                    JoueursId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartiesJoueurPartieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JdrUserPartie", x => new { x.JoueursId, x.PartiesJoueurPartieId });
                    table.ForeignKey(
                        name: "FK_JdrUserPartie_AspNetUsers_JoueursId",
                        column: x => x.JoueursId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JdrUserPartie_Parties_PartiesJoueurPartieId",
                        column: x => x.PartiesJoueurPartieId,
                        principalTable: "Parties",
                        principalColumn: "PartieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenrePartie_PartiesPartieId",
                table: "GenrePartie",
                column: "PartiesPartieId");

            migrationBuilder.CreateIndex(
                name: "IX_JdrUserPartie_PartiesJoueurPartieId",
                table: "JdrUserPartie",
                column: "PartiesJoueurPartieId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_AspNetUsers_MeneurId",
                table: "Parties",
                column: "MeneurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_Parties_PartieId",
                table: "Seances",
                column: "PartieId",
                principalTable: "Parties",
                principalColumn: "PartieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
