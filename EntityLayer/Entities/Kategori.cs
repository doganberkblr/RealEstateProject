using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [DisplayName("Kategori Adı ")]
        public string KategoriAdi { get; set; }


        [DisplayName("Kategori Durumu ")]
        public bool KategoriDurumu { get; set; }

        public List<KonutTipi> konutTipleri { get; set; }

        public List<Ilan> ilanlar { get; set; }

    }
}
