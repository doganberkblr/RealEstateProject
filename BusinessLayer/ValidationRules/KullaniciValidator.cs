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
            RuleFor(x => x.KullaniciSifre).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz.").Must(IsPasswordValid).WithMessage("Parolanız En Az Sekiz Karakter, En Az Bir Harf ve Bir Sayı İçermelidir!");
            RuleFor(x => x.KullaniciEMail).EmailAddress().WithMessage("Lütfen Geçerli Bir E-posta Giriniz!").When(i => !string.IsNullOrEmpty(i.KullaniciEMail)).NotEmpty().WithMessage("Lütfen Bir E-posta Giriniz.");
        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
