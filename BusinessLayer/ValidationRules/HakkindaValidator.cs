using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HakkindaValidator:AbstractValidator<Hakkinda>
    {
        public HakkindaValidator()
        {
            RuleFor(x=>x.HakkindaBaslik).NotEmpty().WithMessage("Başlık Kısmı Boş Geçilemez.");    
            RuleFor(x=>x.HakkindaAltBaslik).NotEmpty().WithMessage("Alt Başlık Kısmı Boş Geçilemez.");    
            RuleFor(x=>x.HakkindaIcerik).NotEmpty().WithMessage("İçerik Kısmı Boş Geçilemez.");
            RuleFor(x => x.HakkindaIcerik).MinimumLength(50).WithMessage("Lütfen En Az 50 Karakterlik İçerik Yazınız.");
            RuleFor(x => x.HakkindaIcerik).MaximumLength(700).WithMessage("En Fazla 700 Karakterlik İçerik Yazabilirsiniz.");
            RuleFor(x=>x.HakkindaFotograf).NotEmpty().WithMessage("Lütfen Bir Görsel Seçiniz.");    
        }
    }
}
