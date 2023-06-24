﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Entities.Haber", b =>
                {
                    b.Property<int>("HaberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HaberID"));

                    b.Property<string>("HaberBaslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HaberDurumu")
                        .HasColumnType("bit");

                    b.Property<string>("HaberFotografi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HaberKisaIcerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HaberTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("HaberUzunIcerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HaberID");

                    b.ToTable("Haberler");
                });

            modelBuilder.Entity("EntityLayer.Entities.Hakkinda", b =>
                {
                    b.Property<int>("HakkindaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HakkindaID"));

                    b.Property<string>("HakkindaAltBaslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HakkindaBaslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HakkindaDurum")
                        .HasColumnType("bit");

                    b.Property<string>("HakkindaFotograf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HakkindaIcerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HakkindaID");

                    b.ToTable("Hakkindalar");
                });

            modelBuilder.Entity("EntityLayer.Entities.Hizmetler", b =>
                {
                    b.Property<int>("HizmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HizmetID"));

                    b.Property<string>("HizmetAciklamasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HizmetAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HizmetDurumu")
                        .HasColumnType("bit");

                    b.HasKey("HizmetID");

                    b.ToTable("Hizmetler");
                });

            modelBuilder.Entity("EntityLayer.Entities.Ilan", b =>
                {
                    b.Property<int>("IlanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IlanID"));

                    b.Property<string>("IlanAciklamasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IlanBasligi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IlanBinaYasi")
                        .HasColumnType("int");

                    b.Property<bool>("IlanDurumu")
                        .HasColumnType("bit");

                    b.Property<bool>("IlanEsyaliMİ")
                        .HasColumnType("bit");

                    b.Property<int>("IlanFiyati")
                        .HasColumnType("int");

                    b.Property<string>("IlanFotografi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IlanMetreKare")
                        .HasColumnType("int");

                    b.Property<int>("IlanOdaSayisi")
                        .HasColumnType("int");

                    b.Property<DateTime>("IlanTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<int>("KonutTipiID")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.Property<int>("SehirID")
                        .HasColumnType("int");

                    b.HasKey("IlanID");

                    b.HasIndex("KategoriID");

                    b.HasIndex("KonutTipiID");

                    b.HasIndex("KullaniciID");

                    b.HasIndex("SehirID");

                    b.ToTable("Ilanlar");
                });

            modelBuilder.Entity("EntityLayer.Entities.Kategori", b =>
                {
                    b.Property<int>("KategoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriID"));

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("KategoriDurumu")
                        .HasColumnType("bit");

                    b.HasKey("KategoriID");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("EntityLayer.Entities.KonutTipi", b =>
                {
                    b.Property<int>("KonutTipiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KonutTipiID"));

                    b.Property<string>("KonutTipiAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("KonutTipiDurumu")
                        .HasColumnType("bit");

                    b.HasKey("KonutTipiID");

                    b.ToTable("KonutTipleri");
                });

            modelBuilder.Entity("EntityLayer.Entities.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciID"));

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("KullaniciDurumu")
                        .HasColumnType("bit");

                    b.Property<string>("KullaniciEMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciFotografAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciSifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("EntityLayer.Entities.MusteriMesaj", b =>
                {
                    b.Property<int>("MusteriMesajID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MusteriMesajID"));

                    b.Property<string>("MusteriAdiSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusteriEMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusteriMesajIcerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusteriMesajID");

                    b.ToTable("MusteriMesajlar");
                });

            modelBuilder.Entity("EntityLayer.Entities.MusteriYorum", b =>
                {
                    b.Property<int>("MusteriYorumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MusteriYorumID"));

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.Property<string>("MusteriYorumBaslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MusteriYorumDurumu")
                        .HasColumnType("bit");

                    b.Property<string>("MusteriYorumIcerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MusteriYorumTarih")
                        .HasColumnType("datetime2");

                    b.HasKey("MusteriYorumID");

                    b.HasIndex("KullaniciID");

                    b.ToTable("MusteriYorumlar");
                });

            modelBuilder.Entity("EntityLayer.Entities.Sehir", b =>
                {
                    b.Property<int>("SehirID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SehirID"));

                    b.Property<string>("SehirAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SehirDurumu")
                        .HasColumnType("bit");

                    b.HasKey("SehirID");

                    b.ToTable("Sehirler");
                });

            modelBuilder.Entity("KategoriKonutTipi", b =>
                {
                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<int>("konutTipleriKonutTipiID")
                        .HasColumnType("int");

                    b.HasKey("KategoriID", "konutTipleriKonutTipiID");

                    b.HasIndex("konutTipleriKonutTipiID");

                    b.ToTable("KategoriKonutTipi");
                });

            modelBuilder.Entity("EntityLayer.Entities.Ilan", b =>
                {
                    b.HasOne("EntityLayer.Entities.Kategori", "kategori")
                        .WithMany("ilanlar")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.KonutTipi", "konutTipi")
                        .WithMany("ılanlar")
                        .HasForeignKey("KonutTipiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.Kullanici", "kullanici")
                        .WithMany("ılanlar")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.Sehir", "sehir")
                        .WithMany("ılanlar")
                        .HasForeignKey("SehirID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kategori");

                    b.Navigation("konutTipi");

                    b.Navigation("kullanici");

                    b.Navigation("sehir");
                });

            modelBuilder.Entity("EntityLayer.Entities.MusteriYorum", b =>
                {
                    b.HasOne("EntityLayer.Entities.Kullanici", "kullanici")
                        .WithMany("MusteriYorumlar")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kullanici");
                });

            modelBuilder.Entity("KategoriKonutTipi", b =>
                {
                    b.HasOne("EntityLayer.Entities.Kategori", null)
                        .WithMany()
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.KonutTipi", null)
                        .WithMany()
                        .HasForeignKey("konutTipleriKonutTipiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Entities.Kategori", b =>
                {
                    b.Navigation("ilanlar");
                });

            modelBuilder.Entity("EntityLayer.Entities.KonutTipi", b =>
                {
                    b.Navigation("ılanlar");
                });

            modelBuilder.Entity("EntityLayer.Entities.Kullanici", b =>
                {
                    b.Navigation("MusteriYorumlar");

                    b.Navigation("ılanlar");
                });

            modelBuilder.Entity("EntityLayer.Entities.Sehir", b =>
                {
                    b.Navigation("ılanlar");
                });
#pragma warning restore 612, 618
        }
    }
}
