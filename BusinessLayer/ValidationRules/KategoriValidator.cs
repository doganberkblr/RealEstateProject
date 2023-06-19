using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class KategoriValidator:AbstractValidator<Kategori>
    {
        public KategoriValidator()
        {
            
            RuleFor(x => x.KategoriAdi).NotEmpty().WithMessage("Kategori Adı Kısmı Boş Geçilemez.");
            RuleFor(x => x.KategoriDurumu).NotEmpty().WithMessage("Kategori Durumu Kısmı Boş Geçilemez.");
        
        }
    }
}
