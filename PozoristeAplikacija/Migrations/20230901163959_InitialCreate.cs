using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PozoristeAplikacija.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikAplikacije",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikAplikacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KorisnikAplikacije_Adrese_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adrese",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pozorista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotografija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresaId = table.Column<int>(type: "int", nullable: true),
                    KorisnikAplikacijeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozorista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pozorista_Adrese_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adrese",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pozorista_KorisnikAplikacije_KorisnikAplikacijeId",
                        column: x => x.KorisnikAplikacijeId,
                        principalTable: "KorisnikAplikacije",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Predstave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fotografija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rezija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trajanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VrstaPredstave = table.Column<int>(type: "int", nullable: false),
                    KorisnikAplikacijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PozoristeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predstave_KorisnikAplikacije_KorisnikAplikacijeId",
                        column: x => x.KorisnikAplikacijeId,
                        principalTable: "KorisnikAplikacije",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Predstave_Pozorista_PozoristeId",
                        column: x => x.PozoristeId,
                        principalTable: "Pozorista",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenaKarte = table.Column<int>(type: "int", nullable: false),
                    VremeIzvodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Placeno = table.Column<bool>(type: "bit", nullable: false),
                    KorisnikAplikacijeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PredstavaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacije_KorisnikAplikacije_KorisnikAplikacijeId",
                        column: x => x.KorisnikAplikacijeId,
                        principalTable: "KorisnikAplikacije",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezervacije_Predstave_PredstavaId",
                        column: x => x.PredstavaId,
                        principalTable: "Predstave",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikAplikacije_AdresaId",
                table: "KorisnikAplikacije",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pozorista_AdresaId",
                table: "Pozorista",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pozorista_KorisnikAplikacijeId",
                table: "Pozorista",
                column: "KorisnikAplikacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Predstave_KorisnikAplikacijeId",
                table: "Predstave",
                column: "KorisnikAplikacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Predstave_PozoristeId",
                table: "Predstave",
                column: "PozoristeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikAplikacijeId",
                table: "Rezervacije",
                column: "KorisnikAplikacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_PredstavaId",
                table: "Rezervacije",
                column: "PredstavaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Predstave");

            migrationBuilder.DropTable(
                name: "Pozorista");

            migrationBuilder.DropTable(
                name: "KorisnikAplikacije");

            migrationBuilder.DropTable(
                name: "Adrese");
        }
    }
}
