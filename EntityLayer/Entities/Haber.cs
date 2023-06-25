using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Haber
    {
        [Key]
        public int HaberID { get; set; }

        [DisplayName("Haber Başlığı")]
        public string HaberBaslik { get; set; }

        [DisplayName("Haberin Alt Başlığı")]
        public string HaberKisaIcerik { get; set; }

        [DisplayName("Haber İçeriği")]
        public string HaberUzunIcerik { get; set; }

        [DisplayName("Haberin Fotoğrafı")]
        public string HaberFotografi { get; set; }

        [DisplayName("Haber Tarihi")]
        public DateTime HaberTarihi { get; set; }

        [DisplayName("Haberin Durumu")]
        public bool HaberDurumu { get; set; }
    }
}
