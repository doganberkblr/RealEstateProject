using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Hakkinda
    {
        [Key] 
        public int HakkindaID { get; set; }

        public string HakkindaBaslik { get; set; }

        public string HakkindaAltBaslik { get; set; }

        public string HakkindaIcerik { get; set; }

        public string HakkindaFotograf { get; set; }

        public bool HakkindaDurum { get; set; }
    }
}
