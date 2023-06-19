using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KonutTipleri_Kategoriler_KategoriID",
                table: "KonutTipleri");

            migrationBuilder.DropIndex(
                name: "IX_KonutTipleri_KategoriID",
                table: "KonutTipleri");

            migrationBuilder.DropColumn(
                name: "KategoriID",
                table: "KonutTipleri");

            migrationBuilder.AddColumn<int>(
                name: "KonutTipiID",
                table: "Sehirler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KategoriKonutTipi",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    konutTipleriKonutTipiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriKonutTipi", x => new { x.KategoriID, x.konutTipleriKonutTipiID });
                    table.ForeignKey(
                        name: "FK_KategoriKonutTipi_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategoriKonutTipi_KonutTipleri_konutTipleriKonutTipiID",
                        column: x => x.konutTipleriKonutTipiID,
                        principalTable: "KonutTipleri",
                        principalColumn: "KonutTipiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sehirler_KonutTipiID",
                table: "Sehirler",
                column: "KonutTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriKonutTipi_konutTipleriKonutTipiID",
                table: "KategoriKonutTipi",
                column: "konutTipleriKonutTipiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sehirler_KonutTipleri_KonutTipiID",
                table: "Sehirler",
                column: "KonutTipiID",
                principalTable: "KonutTipleri",
                principalColumn: "KonutTipiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sehirler_KonutTipleri_KonutTipiID",
                table: "Sehirler");

            migrationBuilder.DropTable(
                name: "KategoriKonutTipi");

            migrationBuilder.DropIndex(
                name: "IX_Sehirler_KonutTipiID",
                table: "Sehirler");

            migrationBuilder.DropColumn(
                name: "KonutTipiID",
                table: "Sehirler");

            migrationBuilder.AddColumn<int>(
                name: "KategoriID",
                table: "KonutTipleri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KonutTipleri_KategoriID",
                table: "KonutTipleri",
                column: "KategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_KonutTipleri_Kategoriler_KategoriID",
                table: "KonutTipleri",
                column: "KategoriID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriID");
        }
    }
}
