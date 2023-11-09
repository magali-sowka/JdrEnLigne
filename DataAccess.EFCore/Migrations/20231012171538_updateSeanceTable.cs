using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class updateSeanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fin",
                table: "Seance");

            migrationBuilder.AddColumn<string>(
                name: "Duree",
                table: "Seance",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duree",
                table: "Seance");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fin",
                table: "Seance",
                type: "datetime",
                nullable: true);
        }
    }
}
