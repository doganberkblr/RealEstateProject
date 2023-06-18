using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Haber
    {
        [Key]
        public int HaberID { get; set; }

        public string HaberBaslik { get; set; }

        public string HaberKisaIcerik { get; set; }

        public string HaberUzunIcerik { get; set; }

        public string HaberFotografi { get; set; }

        public DateTime HaberTarihi { get; set; }

        public bool HaberDurumu { get; set; }
    }
}
