using System;
using System.Collections.Generic;
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

        public string MusteriYorumBaslik { get; set; }

        public string MusteriYorumIcerik { get; set; }

        public DateTime MusteriYorumTarih { get; set; }

        public bool MusteriYorumDurumu { get; set; }

        public Kullanici kullanici { get; set; }

    }
}
