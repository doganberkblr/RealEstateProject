using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Hizmetler
    {
        [Key] 
        public int HizmetID { get; set; }

        public string HizmetAdi { get; set; }

        public string HizmetAciklamasi { get; set; } 

        public bool HizmetDurumu { get; set; }

    }
}
