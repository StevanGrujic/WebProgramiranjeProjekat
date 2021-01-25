using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmfiteatarIspit");

            migrationBuilder.DropTable(
                name: "AmfiteatarIspitniRok");

            migrationBuilder.DropTable(
                name: "IspitIspitniRok");

            migrationBuilder.DropTable(
                name: "IspitStudent");

            migrationBuilder.AddColumn<int>(
                name: "IspitSifra",
                table: "Studenti",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IspitniRokID",
                table: "Ispit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IspitSifra",
                table: "Amfiteatar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_IspitSifra",
                table: "Studenti",
                column: "IspitSifra");

            migrationBuilder.CreateIndex(
                name: "IX_Ispit_IspitniRokID",
                table: "Ispit",
                column: "IspitniRokID");

            migrationBuilder.CreateIndex(
                name: "IX_Amfiteatar_IspitSifra",
                table: "Amfiteatar",
                column: "IspitSifra");

            migrationBuilder.AddForeignKey(
                name: "FK_Amfiteatar_Ispit_IspitSifra",
                table: "Amfiteatar",
                column: "IspitSifra",
                principalTable: "Ispit",
                principalColumn: "Sifra",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit_Ispitni rok_IspitniRokID",
                table: "Ispit",
                column: "IspitniRokID",
                principalTable: "Ispitni rok",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Ispit_IspitSifra",
                table: "Studenti",
                column: "IspitSifra",
                principalTable: "Ispit",
                principalColumn: "Sifra",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amfiteatar_Ispit_IspitSifra",
                table: "Amfiteatar");

            migrationBuilder.DropForeignKey(
                name: "FK_Ispit_Ispitni rok_IspitniRokID",
                table: "Ispit");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Ispit_IspitSifra",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_IspitSifra",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Ispit_IspitniRokID",
                table: "Ispit");

            migrationBuilder.DropIndex(
                name: "IX_Amfiteatar_IspitSifra",
                table: "Amfiteatar");

            migrationBuilder.DropColumn(
                name: "IspitSifra",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "IspitniRokID",
                table: "Ispit");

            migrationBuilder.DropColumn(
                name: "IspitSifra",
                table: "Amfiteatar");

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
    }
}
