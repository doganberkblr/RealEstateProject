using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Kullanici
    {
        [Key] 
        public int KullaniciID { get; set; }

        [DisplayName("Kullanıcı Adı ")]
        public string KullaniciAdi { get; set; }

        [DisplayName("Kullanıcı Soyadı ")]
        public string KullaniciSoyadi { get; set; }

        [DisplayName("Kullanıcı E-mail ")]
        public string KullaniciEMail { get; set; }

        [DisplayName("Kullanıcı Şifre ")]
        public string KullaniciSifre { get; set; }

        [DisplayName("Kullanıcı Durumu ")]
        public bool KullaniciDurumu { get; set; }

        public List<MusteriYorum> MusteriYorumlar { get; set; }

        public List<Ilan> ılanlar { get; set; }
    }
}
