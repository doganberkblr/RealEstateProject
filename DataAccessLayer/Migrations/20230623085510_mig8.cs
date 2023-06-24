using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sehirler_KonutTipleri_KonutTipiID",
                table: "Sehirler");

            migrationBuilder.DropIndex(
                name: "IX_Sehirler_KonutTipiID",
                table: "Sehirler");

            migrationBuilder.DropColumn(
                name: "KonutTipiID",
                table: "Sehirler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KonutTipiID",
                table: "Sehirler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sehirler_KonutTipiID",
                table: "Sehirler",
                column: "KonutTipiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sehirler_KonutTipleri_KonutTipiID",
                table: "Sehirler",
                column: "KonutTipiID",
                principalTable: "KonutTipleri",
                principalColumn: "KonutTipiID");
        }
    }
}
