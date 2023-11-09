using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class correctionDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campagne");

            migrationBuilder.DropTable(
                name: "Oneshots");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Partie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duree",
                table: "Partie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequence",
                table: "Partie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "NbSeances",
                table: "Partie",
                type: "tinyint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Partie");

            migrationBuilder.DropColumn(
                name: "Duree",
                table: "Partie");

            migrationBuilder.DropColumn(
                name: "Frequence",
                table: "Partie");

            migrationBuilder.DropColumn(
                name: "NbSeances",
                table: "Partie");

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
        }
    }
}
