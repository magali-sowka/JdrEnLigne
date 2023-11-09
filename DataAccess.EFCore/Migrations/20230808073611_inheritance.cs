using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class inheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_JdrUserPartie_JdrUser_JoueursId",
                table: "JdrUserPartie");

            migrationBuilder.DropForeignKey(
                name: "FK_JdrUserPartie_Partie_PartiesPartieId",
                table: "JdrUserPartie");

            migrationBuilder.DropForeignKey(
                name: "FK_Partie_JdrUser_meneurID",
                table: "Partie");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Partie_partieID",
                table: "Seance");

            migrationBuilder.DropTable(
                name: "Campagne");

            migrationBuilder.DropTable(
                name: "Oneshot");

            migrationBuilder.DropTable(
                name: "PartieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "seanceID",
                table: "Seance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partie",
                table: "Partie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JdrUser",
                table: "JdrUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Genre__3C5476A23ECF750A",
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

            migrationBuilder.RenameColumn(
                name: "PartiesPartieId",
                table: "JdrUserPartie",
                newName: "PartiesJoueurPartieId");

            migrationBuilder.RenameIndex(
                name: "IX_JdrUserPartie_PartiesPartieId",
                table: "JdrUserPartie",
                newName: "IX_JdrUserPartie_PartiesJoueurPartieId");

            migrationBuilder.RenameColumn(
                name: "partieID",
                table: "Seances",
                newName: "PartieId");

            migrationBuilder.RenameColumn(
                name: "libelle",
                table: "Seances",
                newName: "Libelle");

            migrationBuilder.RenameColumn(
                name: "fin",
                table: "Seances",
                newName: "Fin");

            migrationBuilder.RenameColumn(
                name: "debut",
                table: "Seances",
                newName: "Debut");

            migrationBuilder.RenameColumn(
                name: "seanceID",
                table: "Seances",
                newName: "SeanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Seance_partieID",
                table: "Seances",
                newName: "IX_Seances_PartieId");

            migrationBuilder.RenameColumn(
                name: "vtt",
                table: "Parties",
                newName: "Vtt");

            migrationBuilder.RenameColumn(
                name: "visible",
                table: "Parties",
                newName: "Visible");

            migrationBuilder.RenameColumn(
                name: "urlImage",
                table: "Parties",
                newName: "UrlImage");

            migrationBuilder.RenameColumn(
                name: "titre",
                table: "Parties",
                newName: "Titre");

            migrationBuilder.RenameColumn(
                name: "systeme",
                table: "Parties",
                newName: "Systeme");

            migrationBuilder.RenameColumn(
                name: "statut",
                table: "Parties",
                newName: "Statut");

            migrationBuilder.RenameColumn(
                name: "nbPlacesDispo",
                table: "Parties",
                newName: "NbPlacesDispo");

            migrationBuilder.RenameColumn(
                name: "meneurID",
                table: "Parties",
                newName: "MeneurId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Parties",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "applis",
                table: "Parties",
                newName: "Applis");

            migrationBuilder.RenameColumn(
                name: "partieID",
                table: "Parties",
                newName: "PartieId");

            migrationBuilder.RenameIndex(
                name: "IX_Partie_meneurID",
                table: "Parties",
                newName: "IX_Parties_MeneurId");

            migrationBuilder.RenameColumn(
                name: "libelle",
                table: "Genres",
                newName: "Libelle");

            migrationBuilder.RenameColumn(
                name: "genreID",
                table: "Genres",
                newName: "GenreId");

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
                oldUnicode: false);

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

            migrationBuilder.CreateIndex(
                name: "IX_GenrePartie_PartiesPartieId",
                table: "GenrePartie",
                column: "PartiesPartieId");

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
                name: "FK_JdrUserPartie_AspNetUsers_JoueursId",
                table: "JdrUserPartie",
                column: "JoueursId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JdrUserPartie_Parties_PartiesJoueurPartieId",
                table: "JdrUserPartie",
                column: "PartiesJoueurPartieId",
                principalTable: "Parties",
                principalColumn: "PartieId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_JdrUserPartie_AspNetUsers_JoueursId",
                table: "JdrUserPartie");

            migrationBuilder.DropForeignKey(
                name: "FK_JdrUserPartie_Parties_PartiesJoueurPartieId",
                table: "JdrUserPartie");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_AspNetUsers_MeneurId",
                table: "Parties");

            migrationBuilder.DropForeignKey(
                name: "FK_Seances_Parties_PartieId",
                table: "Seances");

            migrationBuilder.DropTable(
                name: "GenrePartie");

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

            migrationBuilder.RenameColumn(
                name: "PartiesJoueurPartieId",
                table: "JdrUserPartie",
                newName: "PartiesPartieId");

            migrationBuilder.RenameIndex(
                name: "IX_JdrUserPartie_PartiesJoueurPartieId",
                table: "JdrUserPartie",
                newName: "IX_JdrUserPartie_PartiesPartieId");

            migrationBuilder.RenameColumn(
                name: "PartieId",
                table: "Seance",
                newName: "partieID");

            migrationBuilder.RenameColumn(
                name: "Libelle",
                table: "Seance",
                newName: "libelle");

            migrationBuilder.RenameColumn(
                name: "Fin",
                table: "Seance",
                newName: "fin");

            migrationBuilder.RenameColumn(
                name: "Debut",
                table: "Seance",
                newName: "debut");

            migrationBuilder.RenameColumn(
                name: "SeanceId",
                table: "Seance",
                newName: "seanceID");

            migrationBuilder.RenameIndex(
                name: "IX_Seances_PartieId",
                table: "Seance",
                newName: "IX_Seance_partieID");

            migrationBuilder.RenameColumn(
                name: "Vtt",
                table: "Partie",
                newName: "vtt");

            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "Partie",
                newName: "visible");

            migrationBuilder.RenameColumn(
                name: "UrlImage",
                table: "Partie",
                newName: "urlImage");

            migrationBuilder.RenameColumn(
                name: "Titre",
                table: "Partie",
                newName: "titre");

            migrationBuilder.RenameColumn(
                name: "Systeme",
                table: "Partie",
                newName: "systeme");

            migrationBuilder.RenameColumn(
                name: "Statut",
                table: "Partie",
                newName: "statut");

            migrationBuilder.RenameColumn(
                name: "NbPlacesDispo",
                table: "Partie",
                newName: "nbPlacesDispo");

            migrationBuilder.RenameColumn(
                name: "MeneurId",
                table: "Partie",
                newName: "meneurID");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Partie",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Applis",
                table: "Partie",
                newName: "applis");

            migrationBuilder.RenameColumn(
                name: "PartieId",
                table: "Partie",
                newName: "partieID");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_MeneurId",
                table: "Partie",
                newName: "IX_Partie_meneurID");

            migrationBuilder.RenameColumn(
                name: "Libelle",
                table: "Genre",
                newName: "libelle");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genre",
                newName: "genreID");

            migrationBuilder.AlterColumn<string>(
                name: "libelle",
                table: "Seance",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fin",
                table: "Seance",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "debut",
                table: "Seance",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "vtt",
                table: "Partie",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "urlImage",
                table: "Partie",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "titre",
                table: "Partie",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "systeme",
                table: "Partie",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "statut",
                table: "Partie",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Partie",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "applis",
                table: "Partie",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "libelle",
                table: "Genre",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "seanceID",
                table: "Seance",
                column: "seanceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partie",
                table: "Partie",
                column: "partieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Genre__3C5476A23ECF750A",
                table: "Genre",
                column: "genreID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JdrUser",
                table: "JdrUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Campagne",
                columns: table => new
                {
                    partieID = table.Column<long>(type: "bigint", nullable: false),
                    duree = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    frequence = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campagne", x => x.partieID);
                    table.ForeignKey(
                        name: "FK_Campagne_Partie_partieID",
                        column: x => x.partieID,
                        principalTable: "Partie",
                        principalColumn: "partieID");
                });

            migrationBuilder.CreateTable(
                name: "Oneshot",
                columns: table => new
                {
                    partieID = table.Column<long>(type: "bigint", nullable: false),
                    nbSeances = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oneshot", x => x.partieID);
                    table.ForeignKey(
                        name: "FK_Oneshot_Partie_partieID",
                        column: x => x.partieID,
                        principalTable: "Partie",
                        principalColumn: "partieID");
                });

            migrationBuilder.CreateTable(
                name: "PartieGenre",
                columns: table => new
                {
                    partieID = table.Column<long>(type: "bigint", nullable: false),
                    genreID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appartenir", x => new { x.partieID, x.genreID });
                    table.ForeignKey(
                        name: "FK_PartieGenre_Genre_genreID",
                        column: x => x.genreID,
                        principalTable: "Genre",
                        principalColumn: "genreID");
                    table.ForeignKey(
                        name: "FK_PartieGenre_Partie_partieID",
                        column: x => x.partieID,
                        principalTable: "Partie",
                        principalColumn: "partieID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartieGenre_genreID",
                table: "PartieGenre",
                column: "genreID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_JdrUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "JdrUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_JdrUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "JdrUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_JdrUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "JdrUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_JdrUser_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "JdrUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JdrUserPartie_JdrUser_JoueursId",
                table: "JdrUserPartie",
                column: "JoueursId",
                principalTable: "JdrUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JdrUserPartie_Partie_PartiesPartieId",
                table: "JdrUserPartie",
                column: "PartiesPartieId",
                principalTable: "Partie",
                principalColumn: "partieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partie_JdrUser_meneurID",
                table: "Partie",
                column: "meneurID",
                principalTable: "JdrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Partie_partieID",
                table: "Seance",
                column: "partieID",
                principalTable: "Partie",
                principalColumn: "partieID");
        }
    }
}
