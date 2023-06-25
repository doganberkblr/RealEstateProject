using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Hakkında Başlığı")]
        public string HakkindaBaslik { get; set; }

        [DisplayName("Hakkında Alt Başlığı")]
        public string HakkindaAltBaslik { get; set; }

        [DisplayName("Hakkında İçeriği")]
        public string HakkindaIcerik { get; set; }

        [DisplayName("Hakkında Durumu")]
        public bool HakkindaDurum { get; set; }
    }
}
