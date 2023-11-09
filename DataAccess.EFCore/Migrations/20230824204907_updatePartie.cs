using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class updatePartie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartieBR");

            migrationBuilder.DropColumn(
                name: "DatePubli",
                table: "Partie");

            migrationBuilder.DropColumn(
                name: "DateNaiss",
                table: "JdrUser");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "JdrUser");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "JdrUser");

            migrationBuilder.RenameColumn(
                name: "NbPlacesDispo",
                table: "Partie",
                newName: "NbPlacesTot");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Partie",
                newName: "Descrip");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "JdrUser",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "JdrUser",
                newName: "Presentation");

            migrationBuilder.AlterColumn<string>(
                name: "Vtt",
                table: "Partie",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Titre",
                table: "Partie",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Systeme",
                table: "Partie",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Applis",
                table: "Partie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreaPartie",
                table: "Partie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UrlAvatar",
                table: "JdrUser",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pseudo",
                table: "JdrUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreaCompte",
                table: "JdrUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreaPartie",
                table: "Partie");

            migrationBuilder.RenameColumn(
                name: "NbPlacesTot",
                table: "Partie",
                newName: "NbPlacesDispo");

            migrationBuilder.RenameColumn(
                name: "Descrip",
                table: "Partie",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "JdrUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Presentation",
                table: "JdrUser",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Vtt",
                table: "Partie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Titre",
                table: "Partie",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Systeme",
                table: "Partie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Applis",
                table: "Partie",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePubli",
                table: "Partie",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UrlAvatar",
                table: "JdrUser",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Pseudo",
                table: "JdrUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreaCompte",
                table: "JdrUser",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaiss",
                table: "JdrUser",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "JdrUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "JdrUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PartieBR",
                columns: table => new
                {
                    PartieBRId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeneurId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbPlacesDispo = table.Column<byte>(type: "tinyint", nullable: false),
                    SeanceDebut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeanceFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeanceLibelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Systeme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vtt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbSeances = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartieBR", x => x.PartieBRId);
                });
        }
    }
}
