using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class createJdrUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partie_Joueur_meneurID",
                table: "Partie");

            migrationBuilder.DropTable(
                name: "JoueurPartie");

            migrationBuilder.DropTable(
                name: "JoueurRole");

            migrationBuilder.DropTable(
                name: "Joueur");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "meneurID",
                table: "Partie",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "JdrUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaiss = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UrlAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreaCompte = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JdrUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JdrUser_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JdrUserPartie",
                columns: table => new
                {
                    JoueursId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartiesPartieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JdrUserPartie", x => new { x.JoueursId, x.PartiesPartieId });
                    table.ForeignKey(
                        name: "FK_JdrUserPartie_JdrUser_JoueursId",
                        column: x => x.JoueursId,
                        principalTable: "JdrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JdrUserPartie_Partie_PartiesPartieId",
                        column: x => x.PartiesPartieId,
                        principalTable: "Partie",
                        principalColumn: "partieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JdrUserPartie_PartiesPartieId",
                table: "JdrUserPartie",
                column: "PartiesPartieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partie_JdrUser_meneurID",
                table: "Partie",
                column: "meneurID",
                principalTable: "JdrUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partie_JdrUser_meneurID",
                table: "Partie");

            migrationBuilder.DropTable(
                name: "JdrUserPartie");

            migrationBuilder.DropTable(
                name: "JdrUser");

            migrationBuilder.AlterColumn<long>(
                name: "meneurID",
                table: "Partie",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    joueurID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateCreaCompte = table.Column<DateTime>(type: "date", nullable: false),
                    dateNaiss = table.Column<DateTime>(type: "date", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    nom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    prenom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pseudo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    urlAvatar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.joueurID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "JoueurPartie",
                columns: table => new
                {
                    joueurID = table.Column<long>(type: "bigint", nullable: false),
                    partieID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoueurPartie", x => new { x.joueurID, x.partieID });
                    table.ForeignKey(
                        name: "FK_JoueurPartie_Joueur_joueurID",
                        column: x => x.joueurID,
                        principalTable: "Joueur",
                        principalColumn: "joueurID");
                    table.ForeignKey(
                        name: "FK_JoueurPartie_Partie_partieID",
                        column: x => x.partieID,
                        principalTable: "Partie",
                        principalColumn: "partieID");
                });

            migrationBuilder.CreateTable(
                name: "JoueurRole",
                columns: table => new
                {
                    joueurID = table.Column<long>(type: "bigint", nullable: false),
                    roleID = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoueurRole", x => new { x.joueurID, x.roleID });
                    table.ForeignKey(
                        name: "FK_JoueurRole_Joueur_joueurID",
                        column: x => x.joueurID,
                        principalTable: "Joueur",
                        principalColumn: "joueurID");
                    table.ForeignKey(
                        name: "FK_JoueurRole_Role_roleID",
                        column: x => x.roleID,
                        principalTable: "Role",
                        principalColumn: "roleID");
                });

            migrationBuilder.CreateIndex(
                name: "UC_Joueur_email",
                table: "Joueur",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JoueurPartie_partieID",
                table: "JoueurPartie",
                column: "partieID");

            migrationBuilder.CreateIndex(
                name: "IX_JoueurRole_roleID",
                table: "JoueurRole",
                column: "roleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Partie_Joueur_meneurID",
                table: "Partie",
                column: "meneurID",
                principalTable: "Joueur",
                principalColumn: "joueurID");
        }
    }
}
