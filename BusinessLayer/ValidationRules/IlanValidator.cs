using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class IlanValidator:AbstractValidator<Ilan>
    {
        public IlanValidator()
        {
            RuleFor(x => x.IlanBasligi).NotEmpty().WithMessage("İlan Başlığı Boş Geçilemez.");
            RuleFor(x => x.IlanAciklamasi).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez.");
            RuleFor(x => x.IlanFiyati).NotEmpty().WithMessage("İlan Fiyatı Boş Geçilemez.");
            RuleFor(x => x.IlanAciklamasi).MinimumLength(50).WithMessage("Lütfen En Az 50 Karakterlik İlan Açıklaması Yazınız.");
            RuleFor(x => x.IlanAciklamasi).MaximumLength(1000).WithMessage("En Fazla 1000 Karakterlik İlan Açıklaması Yazabilirsiniz.");
            RuleFor(x => x.IlanMetreKare).NotEmpty().WithMessage("Lütfen Metrekare Bilgisini Giriniz.");
            RuleFor(x => x.IlanOdaSayisi).NotEmpty().WithMessage("Lütfen Oda Sayısını Giriniz.");
            RuleFor(x => x.IlanBinaYasi).NotEmpty().WithMessage("Lütfen Bina Yaşı Bilgisini Giriniz.");
            RuleFor(x => x.IlanFotografi).NotEmpty().WithMessage("Lütfen İlana Ait Görsel Yükleyiniz.");
            RuleFor(x => x.IlanEsyaliMİ).NotEmpty().WithMessage("Lütfen İlanınızın Eşyalı yada Eşyasız Olup Olmadığını Belirtiniz.");

            
        }
    }
}
