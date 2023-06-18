using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MusteriMesajValidator:AbstractValidator<MusteriMesaj>
    {
        public MusteriMesajValidator()
        {
            RuleFor(x => x.MusteriAdiSoyadi).NotEmpty().WithMessage("Ad, Soy Ad Kısmı Boş Geçilemez.");
            RuleFor(x => x.MusteriEMail).NotEmpty().WithMessage("E-mail Kısmı Boş Geçilemez.");
            RuleFor(x => x.MusteriMesajIcerik).NotEmpty().WithMessage("Gönderilecek Mesaj Kısmı Boş Geçilemez.");
            RuleFor(x => x.MusteriMesajIcerik).MinimumLength(10).WithMessage("Lütfen En Az 10 Karakterlik Mesaj İçeriği Yazınız.");
            RuleFor(x => x.MusteriMesajIcerik).MaximumLength(500).WithMessage("En Fazla 500 Karakterlik Mesaj İçeriği Yazabilirsiniz.");

        }
    }
}
