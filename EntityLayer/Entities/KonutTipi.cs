using System;
using System.Collections.Generic;
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

        public string KonutTipiAdi { get; set; }

        public bool KonutTipiDurumu { get; set; }

        public List<Ilan> ılanlar { get; set; }

    }
}
