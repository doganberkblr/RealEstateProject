using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HaberValidator:AbstractValidator<Haber>
    {
        public HaberValidator()
        {
            RuleFor(x => x.HaberBaslik).NotEmpty().WithMessage("Haber Başlığı Kısmı Boş Geçilemez.");
            RuleFor(x => x.HaberKisaIcerik).NotEmpty().WithMessage("Özet Kısmı Boş Geçilemez.");
            RuleFor(x => x.HaberUzunIcerik).NotEmpty().WithMessage("Haber İçeriği Kısmı Boş Geçilemez.");
            RuleFor(x => x.HaberUzunIcerik).MinimumLength(50).WithMessage("Lütfen En Az 50 Karakterlik Haber İçeriği Yazınız.");
            RuleFor(x => x.HaberUzunIcerik).MaximumLength(500).WithMessage("En Fazla 500 Karakterlik Haber İçeriği Yazabilirsiniz.");
            RuleFor(x => x.HaberFotografi).NotEmpty().WithMessage("Lütfen Habere Ait Görsel Seçiniz.");
            RuleFor(x => x.HaberTarihi).NotEmpty().WithMessage("Lütfen Haber Tarihini Giriniz.");
        }
    }
}
