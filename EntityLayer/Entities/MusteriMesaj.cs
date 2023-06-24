using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Müşteri Adı ve Soyadı ")]
        public string MusteriAdiSoyadi { get; set; }
        [DisplayName("Müşteri E-mail Adresi ")]
        public string MusteriEMail { get; set; }
        [DisplayName("Müşterinin Mesajı ")]
        public string MusteriMesajIcerik { get; set; }

    }
}
