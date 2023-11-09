using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class updateJdrContextFluentAPIJdrUserPartie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NbPlacesTot",
                table: "Partie",
                newName: "NbPlacesTotal");

            migrationBuilder.RenameColumn(
                name: "Descrip",
                table: "Partie",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "JdrUser",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UrlAvatar",
                table: "JdrUser",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreaCompte",
                table: "JdrUser",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NbPlacesTotal",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreaCompte",
                table: "JdrUser",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
