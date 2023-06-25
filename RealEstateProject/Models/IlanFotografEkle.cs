using EntityLayer.Entities;
using System.ComponentModel;

namespace RealEstateProject.Models
{
    public class IlanFotografEkle
    {
        public int KategoriID { get; set; }

        public int KullaniciID { get; set; }

        public int KonutTipiID { get; set; }

        public int SehirID { get; set; }

        [DisplayName("İlan Başlığı ")]
        public string IlanBasligi { get; set; }

        [DisplayName("İlan Açıklaması ")]
        public string IlanAciklamasi { get; set; }

        [DisplayName("İlan Fiyatı ")]
        public int IlanFiyati { get; set; }

        [DisplayName("Metrekaresi ")]
        public int IlanMetreKare { get; set; }

        [DisplayName("Oda Sayısı ")]
        public int IlanOdaSayisi { get; set; }

        [DisplayName("Bina Yaşı ")]
        public int IlanBinaYasi { get; set; }

        [DisplayName("İlanın Fotoğrafı ")]
        public IFormFile IlanFotografi { get; set; }

        [DisplayName("İlanın Tarihi ")]
        public DateTime IlanTarihi { get; set; }

        [DisplayName("Eşyalı Mı? ")]
        public bool IlanEsyaliMİ { get; set; }

        [DisplayName("İlanın Durumu ")]
        public bool IlanDurumu { get; set; }
    }
}
