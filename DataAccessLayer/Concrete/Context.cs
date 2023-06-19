using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-TOBK20I; database=RealEstateProjectDB; Integrated Security=True; TrustServerCertificate=True");
        }
        public DbSet<Haber> Haberler { get; set; }
        public DbSet<Hakkinda> Hakkindalar { get; set; }
        public DbSet<Ilan> Ilanlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KonutTipi> KonutTipleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<MusteriMesaj> MusteriMesajlar { get; set; }
        public DbSet<MusteriYorum> MusteriYorumlar { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Hizmetler> Hizmetler { get; set; }
    }
}
