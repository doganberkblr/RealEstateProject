﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string IlanFotografi { get; set; }

        [DisplayName("İlanın Tarihi ")]
        public DateTime IlanTarihi { get; set; }

        [DisplayName("Eşyalı Mı? ")]
        public bool IlanEsyaliMİ { get; set; }

        [DisplayName("İlanın Durumu ")]
        public bool IlanDurumu { get; set; }

        [DisplayName("Kategorisi ")]
        public Kategori kategori { get; set; }

        [DisplayName("Konut Tipi ")]
        public KonutTipi konutTipi { get; set;}

        [DisplayName("İlanın Şehri ")]
        public Sehir sehir { get; set; }

        [DisplayName("İlan Sahibi ")]
        public Kullanici kullanici { get; set; }

    }
}
