using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MusteriYorumValidator:AbstractValidator<MusteriYorum>
    {
        public MusteriYorumValidator()
        {
            RuleFor(x => x.MusteriYorumBaslik).NotEmpty().WithMessage("Başlık Kısmı Geçilemez.");
            RuleFor(x => x.MusteriYorumIcerik).NotEmpty().WithMessage("Yorum İçeriği Kısmı Geçilemez.");
            RuleFor(x => x.MusteriYorumIcerik).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakterlik Yorum İçeriği Yazınız.");
            RuleFor(x => x.MusteriYorumIcerik).MaximumLength(500).WithMessage("En Fazla 500 Karakterlik Yorum İçeriği Yazabilirsiniz.");
        }
    }
}
