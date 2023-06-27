using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class KullaniciValidator:AbstractValidator<Kullanici>
    {
        public KullaniciValidator()
        {
            RuleFor(x => x.KullaniciAdi).NotEmpty().WithMessage("Lütfen Adınızı Giriniz.");
            RuleFor(x => x.KullaniciSoyadi).NotEmpty().WithMessage("Lütfen Soy Adınızı Giriniz.");
            RuleFor(x => x.KullaniciSifre).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz.");
            RuleFor(x => x.KullaniciEMail).EmailAddress().WithMessage("Lütfen Geçerli Bir E-posta Giriniz!").When(i => !string.IsNullOrEmpty(i.KullaniciEMail)).NotEmpty().WithMessage("Lütfen Bir E-posta Giriniz.");
            RuleFor(x => x.KullaniciFotografAdi).NotEmpty().WithMessage("Lütfen Fotoğraf Seçiniz");
        }
    
    }
}
