using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using RealEstateProject.Models;
using X.PagedList;
using ClosedXML.Excel;

namespace RealEstateProject.Controllers
{
    public class KullaniciController : Controller
    {
        KullaniciManager kt = new KullaniciManager(new EFKullaniciDAL());

        public IActionResult AdminKullaniciListeleme(int sayfa=1)
        {
            var kullanici = kt.TgetList().ToPagedList(sayfa, 3);
            return View(kullanici);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminKullaniciEkle()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdminKullaniciEkle(KullaniciFotografEkle a)
        {
            Kullanici k=new Kullanici();
            if (a.KullaniciFotografAdi!=null)
            {
                var extension = Path.GetExtension(a.KullaniciFotografAdi.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/KullaniciFotograflari/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                a.KullaniciFotografAdi.CopyTo(stream);
                k.KullaniciFotografAdi = newimagename;
            }
            k.KullaniciAdi = a.KullaniciAdi;
            k.KullaniciSoyadi=a.KullaniciSoyadi;
            k.KullaniciDurumu = a.KullaniciDurumu;
            k.KullaniciEMail = a.KullaniciEMail;
            k.KullaniciSifre = a.KullaniciSifre;
            kt.Tadd(k);
            return RedirectToAction("AdminKullaniciListeleme", "Kullanici");
        }
        public IActionResult AdminKullaniciSil(int id)
        {
            var kullanici = kt.TgetByID(id);
            return View(kullanici);
        }
        [HttpPost]
        public IActionResult AdminKullaniciSil(Kullanici kullanici)
        {
            kt.Tdelete(kullanici);
            return RedirectToAction("AdminKullaniciListeleme", "Kullanici");
        }

        public IActionResult AdminKullaniciDetay(int id)
        {
            var kullanici = kt.TgetByID(id);
            return View(kullanici);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminKullaniciDuzenle(int id)
        {
            
            Kullanici kullanici = kt.TgetByID(id);
            if (kullanici == null)
            {
              
                return RedirectToAction("AdminKullaniciListeleme", "Kullanici");
            }

          
            return View(kullanici);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdminKullaniciDuzenle(KullaniciFotografEkle model)
        {
           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Kullanici kullanici = kt.TgetByID(model.KullaniciID);
            if (kullanici == null)
            {
              
                return RedirectToAction("AdminKullaniciListeleme", "Kullanici");
            }

      
            kullanici.KullaniciAdi = model.KullaniciAdi;
            kullanici.KullaniciSoyadi = model.KullaniciSoyadi;
            kullanici.KullaniciDurumu = model.KullaniciDurumu;
            kullanici.KullaniciEMail = model.KullaniciEMail;
            kullanici.KullaniciSifre = model.KullaniciSifre;

            if (model.KullaniciFotografAdi != null)
            {
                var extension = Path.GetExtension(model.KullaniciFotografAdi.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/KullaniciFotograflari/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.KullaniciFotografAdi.CopyTo(stream);
                kullanici.KullaniciFotografAdi = newimagename;
            }

     
            kt.Tupdate(kullanici);

            return RedirectToAction("AdminKullaniciListeleme", "Kullanici");
        }
        public IActionResult KullanicilariExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("Kullanicilar");
            calismaSayfasi.Cell(1, 1).Value = "Kullanıcı ID";
            calismaSayfasi.Cell(1, 2).Value = "Kullanıcı Adı";
            calismaSayfasi.Cell(1, 3).Value = "Kullanıcı Soyadı";
            calismaSayfasi.Cell(1, 4).Value = "E-Mail Adresi";
            calismaSayfasi.Cell(1, 5).Value = "Şifresi";
            int Satir = 2;
            foreach (var kullanici in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = kullanici.KullaniciID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = kullanici.KullaniciAdi.ToString();
                calismaSayfasi.Cell(Satir, 3).Value = kullanici.KullaniciSoyadi.ToString();
                calismaSayfasi.Cell(Satir, 4).Value = kullanici.KullaniciEMail.ToString();
                calismaSayfasi.Cell(Satir, 5).Value = kullanici.KullaniciSifre.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminKullaniciListesi.xlsx");
        }

    }
}

