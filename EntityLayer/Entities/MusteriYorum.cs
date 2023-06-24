using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class MusteriYorum
    {
        [Key]
        public int MusteriYorumID { get; set; }

        public int KullaniciID { get; set; }

        [DisplayName("Yorum Başlığı ")]
        public string MusteriYorumBaslik { get; set; }

        [DisplayName("Yorum İçeriği ")]
        public string MusteriYorumIcerik { get; set; }

        [DisplayName("Yorum Tarihi ")]
        public DateTime MusteriYorumTarih { get; set; }

        [DisplayName("Yorum Durumu ")]
        public bool MusteriYorumDurumu { get; set; }

        [DisplayName("Kullanıcı ")]
        public Kullanici kullanici { get; set; }

    }
}
