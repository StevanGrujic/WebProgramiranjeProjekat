using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amfiteatar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amfiteatar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ispit",
                columns: table => new
                {
                    Sifra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit", x => x.Sifra);
                });

            migrationBuilder.CreateTable(
                name: "Ispitni rok",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispitni rok", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BrojIndeksa = table.Column<int>(type: "int", nullable: false),
                    Godinastudija = table.Column<int>(name: "Godina studija", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AmfiteatarIspit",
                columns: table => new
                {
                    AmfiteatriID = table.Column<int>(type: "int", nullable: false),
                    IspitiSifra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmfiteatarIspit", x => new { x.AmfiteatriID, x.IspitiSifra });
                    table.ForeignKey(
                        name: "FK_AmfiteatarIspit_Amfiteatar_AmfiteatriID",
                        column: x => x.AmfiteatriID,
                        principalTable: "Amfiteatar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmfiteatarIspit_Ispit_IspitiSifra",
                        column: x => x.IspitiSifra,
                        principalTable: "Ispit",
                        principalColumn: "Sifra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmfiteatarIspitniRok",
                columns: table => new
                {
                    AmfiteatriID = table.Column<int>(type: "int", nullable: false),
                    IspitniRokoviID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmfiteatarIspitniRok", x => new { x.AmfiteatriID, x.IspitniRokoviID });
                    table.ForeignKey(
                        name: "FK_AmfiteatarIspitniRok_Amfiteatar_AmfiteatriID",
                        column: x => x.AmfiteatriID,
                        principalTable: "Amfiteatar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmfiteatarIspitniRok_Ispitni rok_IspitniRokoviID",
                        column: x => x.IspitniRokoviID,
                        principalTable: "Ispitni rok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IspitIspitniRok",
                columns: table => new
                {
                    IspitniRokoviID = table.Column<int>(type: "int", nullable: false),
                    listaIspitaSifra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IspitIspitniRok", x => new { x.IspitniRokoviID, x.listaIspitaSifra });
                    table.ForeignKey(
                        name: "FK_IspitIspitniRok_Ispit_listaIspitaSifra",
                        column: x => x.listaIspitaSifra,
                        principalTable: "Ispit",
                        principalColumn: "Sifra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IspitIspitniRok_Ispitni rok_IspitniRokoviID",
                        column: x => x.IspitniRokoviID,
                        principalTable: "Ispitni rok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IspitStudent",
                columns: table => new
                {
                    IspitiSifra = table.Column<int>(type: "int", nullable: false),
                    listaStudenataID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IspitStudent", x => new { x.IspitiSifra, x.listaStudenataID });
                    table.ForeignKey(
                        name: "FK_IspitStudent_Ispit_IspitiSifra",
                        column: x => x.IspitiSifra,
                        principalTable: "Ispit",
                        principalColumn: "Sifra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IspitStudent_Studenti_listaStudenataID",
                        column: x => x.listaStudenataID,
                        principalTable: "Studenti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmfiteatarIspit_IspitiSifra",
                table: "AmfiteatarIspit",
                column: "IspitiSifra");

            migrationBuilder.CreateIndex(
                name: "IX_AmfiteatarIspitniRok_IspitniRokoviID",
                table: "AmfiteatarIspitniRok",
                column: "IspitniRokoviID");

            migrationBuilder.CreateIndex(
                name: "IX_IspitIspitniRok_listaIspitaSifra",
                table: "IspitIspitniRok",
                column: "listaIspitaSifra");

            migrationBuilder.CreateIndex(
                name: "IX_IspitStudent_listaStudenataID",
                table: "IspitStudent",
                column: "listaStudenataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmfiteatarIspit");

            migrationBuilder.DropTable(
                name: "AmfiteatarIspitniRok");

            migrationBuilder.DropTable(
                name: "IspitIspitniRok");

            migrationBuilder.DropTable(
                name: "IspitStudent");

            migrationBuilder.DropTable(
                name: "Amfiteatar");

            migrationBuilder.DropTable(
                name: "Ispitni rok");

            migrationBuilder.DropTable(
                name: "Ispit");

            migrationBuilder.DropTable(
                name: "Studenti");
        }
    }
}
