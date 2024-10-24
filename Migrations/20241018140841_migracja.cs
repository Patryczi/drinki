using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace drinki.Migrations
{
    /// <inheritdoc />
    public partial class migracja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    KategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.KategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Drinki",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", nullable: false),
                    Cena = table.Column<decimal>(type: "TEXT", nullable: false),
                    KategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinki", x => x.DrinkId);
                    table.ForeignKey(
                        name: "FK_Drinki_Kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "KategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oceny",
                columns: table => new
                {
                    OcenaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wartosc = table.Column<int>(type: "INTEGER", nullable: false),
                    Komentarz = table.Column<string>(type: "TEXT", nullable: false),
                    DrinkId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oceny", x => x.OcenaId);
                    table.ForeignKey(
                        name: "FK_Oceny_Drinki_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinki",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skladniki",
                columns: table => new
                {
                    SkladnikId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    DrinkId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladniki", x => x.SkladnikId);
                    table.ForeignKey(
                        name: "FK_Skladniki_Drinki_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinki",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drinki_KategoriaId",
                table: "Drinki",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oceny_DrinkId",
                table: "Oceny",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Skladniki_DrinkId",
                table: "Skladniki",
                column: "DrinkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oceny");

            migrationBuilder.DropTable(
                name: "Skladniki");

            migrationBuilder.DropTable(
                name: "Drinki");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
