using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addTablesBrouillon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Partie");

            migrationBuilder.CreateTable(
                name: "PartieBR",
                columns: table => new
                {
                    PartieBRId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Systeme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vtt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Applis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbPlacesDispo = table.Column<byte>(type: "tinyint", nullable: false),
                    MeneurId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeanceLibelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeanceDebut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeanceFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbSeances = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartieBR", x => x.PartieBRId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartieBR");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Partie",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
