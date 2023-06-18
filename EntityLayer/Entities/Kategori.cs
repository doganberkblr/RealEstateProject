using System;
using System.Collections.Generic;
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

        public string KategoriAdi { get; set; }

        public bool KategoriDurumu { get; set; }

        public List<KonutTipi> konutTipleri { get; set; }

        public List<Ilan> ılanlar { get; set; }

    }
}
