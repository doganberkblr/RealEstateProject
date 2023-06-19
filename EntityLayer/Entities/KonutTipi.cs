using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class KonutTipi
    {
        [Key]   
        public int KonutTipiID { get; set; }

        [DisplayName("Konut Tipi Adı : ")]
        public string KonutTipiAdi { get; set; }

        [DisplayName("Konut Tipi Durumu : ")]
        public bool KonutTipiDurumu { get; set; }

        public List<Ilan> ılanlar { get; set; }

        public List<Kategori> kategori { get; set; }    

        public List<Sehir> sehir { get; set; }

    }
}
