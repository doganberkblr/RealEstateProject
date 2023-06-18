using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haberler",
                columns: table => new
                {
                    HaberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HaberBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaberKisaIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaberUzunIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaberFotografi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaberTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HaberDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haberler", x => x.HaberID);
                });

            migrationBuilder.CreateTable(
                name: "Hakkindalar",
                columns: table => new
                {
                    HakkindaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HakkindaBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkindaAltBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkindaIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkindaFotograf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkindaDurum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkindalar", x => x.HakkindaID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciEMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciSifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "MusteriMesajlar",
                columns: table => new
                {
                    MusteriMesajID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriEMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriMesajIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriMesajlar", x => x.MusteriMesajID);
                });

            migrationBuilder.CreateTable(
                name: "Sehirler",
                columns: table => new
                {
                    SehirID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SehirDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirler", x => x.SehirID);
                });

            migrationBuilder.CreateTable(
                name: "KonutTipleri",
                columns: table => new
                {
                    KonutTipiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonutTipiAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonutTipiDurumu = table.Column<bool>(type: "bit", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonutTipleri", x => x.KonutTipiID);
                    table.ForeignKey(
                        name: "FK_KonutTipleri_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID");
                });

            migrationBuilder.CreateTable(
                name: "MusteriYorumlar",
                columns: table => new
                {
                    MusteriYorumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    MusteriYorumBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriYorumIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriYorumTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MusteriYorumDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriYorumlar", x => x.MusteriYorumID);
                    table.ForeignKey(
                        name: "FK_MusteriYorumlar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ilanlar",
                columns: table => new
                {
                    IlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    KonutTipiID = table.Column<int>(type: "int", nullable: false),
                    SehirID = table.Column<int>(type: "int", nullable: false),
                    IlanBasligi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlanAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlanFiyati = table.Column<int>(type: "int", nullable: false),
                    IlanMetreKare = table.Column<int>(type: "int", nullable: false),
                    IlanOdaSayisi = table.Column<int>(type: "int", nullable: false),
                    IlanBinaYasi = table.Column<int>(type: "int", nullable: false),
                    IlanFotografi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlanTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IlanEsyaliMİ = table.Column<bool>(type: "bit", nullable: false),
                    IlanDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilanlar", x => x.IlanID);
                    table.ForeignKey(
                        name: "FK_Ilanlar_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ilanlar_KonutTipleri_KonutTipiID",
                        column: x => x.KonutTipiID,
                        principalTable: "KonutTipleri",
                        principalColumn: "KonutTipiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ilanlar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ilanlar_Sehirler_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehirler",
                        principalColumn: "SehirID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_KategoriID",
                table: "Ilanlar",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_KonutTipiID",
                table: "Ilanlar",
                column: "KonutTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_KullaniciID",
                table: "Ilanlar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_SehirID",
                table: "Ilanlar",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_KonutTipleri_KategoriID",
                table: "KonutTipleri",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriYorumlar_KullaniciID",
                table: "MusteriYorumlar",
                column: "KullaniciID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Haberler");

            migrationBuilder.DropTable(
                name: "Hakkindalar");

            migrationBuilder.DropTable(
                name: "Ilanlar");

            migrationBuilder.DropTable(
                name: "MusteriMesajlar");

            migrationBuilder.DropTable(
                name: "MusteriYorumlar");

            migrationBuilder.DropTable(
                name: "KonutTipleri");

            migrationBuilder.DropTable(
                name: "Sehirler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
