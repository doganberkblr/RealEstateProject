using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class MusteriMesaj
    {
        [Key]
        public int MusteriMesajID { get; set; }

        public string MusteriAdiSoyadi { get; set; }

        public string MusteriEMail { get; set; }

        public string MusteriMesajIcerik { get; set; }

    }
}
