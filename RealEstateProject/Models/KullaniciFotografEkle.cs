using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace RealEstateProject.Models
{
    public class KullaniciFotografEkle
    {
        [Key]
        public int KullaniciID { get; set; }

        [DisplayName("Kullanıcı Adı ")]
        public string KullaniciAdi { get; set; }

        [DisplayName("Kullanıcı Soyadı ")]
        public string KullaniciSoyadi { get; set; }

        [DisplayName("Kullanıcı E-mail ")]
        public string KullaniciEMail { get; set; }


        [DisplayName("Kullanıcı Fotoğrafı ")]
        [AllowNull]
        public IFormFile KullaniciFotografAdi { get; set; }

        [DisplayName("Kullanıcı Şifre ")]
        public string KullaniciSifre { get; set; }

        [DisplayName("Kullanıcı Durumu ")]
        public bool KullaniciDurumu { get; set; }
    }
}
