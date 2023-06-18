using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Sehir
    {
        [Key]
        public int SehirID { get; set; }

        public string SehirAdi { get; set; }

        public bool SehirDurumu { get; set; }

        public List<Ilan> ılanlar { get; set; }   

    }
}
