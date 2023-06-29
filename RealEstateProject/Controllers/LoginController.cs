using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Drawing;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using RealEstateProject.Models;
using System.Security.Claims;

namespace RealEstateProject.Controllers
{
    public class LoginController : Controller
    {

        KullaniciManager kt = new KullaniciManager(new EFKullaniciDAL());
        public IActionResult GirisYap()
        {
         
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(Kullanici kullanici)
        {
            try
            {
                Context context = new Context();
                var datavalue = context.Kullanicilar.FirstOrDefault(x => x.KullaniciEMail == kullanici.KullaniciEMail && x.KullaniciSifre == kullanici.KullaniciSifre);
				if (datavalue.KullaniciEMail=="admin@admin.com"&& datavalue.KullaniciSifre=="123")
                {
				
					return RedirectToAction("AdminAnaSayfa", "AnaSayfa");

                }
                else if (datavalue != null)
                {

                    return RedirectToAction("Index", "Default");
				}
                else
                {
                    string errorMessage = "Hatalı Giriş Yaptınız.";
                    return BadRequest(errorMessage);

                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("HataSayfasi", "Hata");
            }
        }
      
        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(KullaniciFotografEkle a)
        {
            try
            {
                Kullanici k = new Kullanici();
                if (a.KullaniciFotografAdi != null)
                {
                    var extension = Path.GetExtension(a.KullaniciFotografAdi.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/KullaniciFotograflari/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    a.KullaniciFotografAdi.CopyTo(stream);
                    k.KullaniciFotografAdi = newimagename;
                }
                k.KullaniciAdi = a.KullaniciAdi;
                k.KullaniciSoyadi = a.KullaniciSoyadi;
                k.KullaniciDurumu = true;
                k.KullaniciEMail = a.KullaniciEMail;
                k.KullaniciSifre = a.KullaniciSifre;
                kt.Tadd(k);
                return RedirectToAction("GirisYap", "Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("HataSayfasi", "Hata");
            }
        }
    }
}
