using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Ilan
    {
        [Key]
        public int IlanID { get; set; }

        public int KullaniciID { get; set; }

        public int KategoriID { get; set; }

        public int KonutTipiID { get; set; }

        public int SehirID { get; set; }

        public string IlanBasligi { get; set; }

        public string IlanAciklamasi { get; set; }

        public int IlanFiyati { get; set; }

        public int IlanMetreKare { get; set; }

        public int IlanOdaSayisi { get; set; }

        public int IlanBinaYasi { get; set; }

        public string IlanFotografi { get; set; }

        public DateTime IlanTarihi { get; set; }

        public bool IlanEsyaliMİ { get; set; }

        public bool IlanDurumu { get; set; }

        public Kategori kategori { get; set; }

        public KonutTipi konutTipi { get; set;}

        public Sehir sehir { get; set; } 
        
        public Kullanici kullanici { get; set; }

    }
}
