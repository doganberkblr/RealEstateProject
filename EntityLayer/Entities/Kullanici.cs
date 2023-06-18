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

        public string KullaniciAdi { get; set; }

        public string KullaniciSoyadi { get; set; }

        public string KullaniciEMail { get; set; }

        public string KullaniciSifre { get; set; }

        public bool KullaniciDurumu { get; set; }

        public List<MusteriYorum> MusteriYorumlar { get; set; }

        public List<Ilan> ılanlar { get; set; }
    }
}
