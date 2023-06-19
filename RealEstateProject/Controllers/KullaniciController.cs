using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class KullaniciController : Controller
    {
        KullaniciManager kt = new KullaniciManager(new EFKullaniciDAL());

        public IActionResult AdminKullaniciListeleme()
        {
            var kullanici = kt.TgetList();
            return View(kullanici);
        }
        public IActionResult AdminKullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminKullaniciEkle(Kullanici kullanici)
        {
            kt.Tadd(kullanici);
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

        public IActionResult AdminKullaniciDuzenle(int id)
        {
            Kullanici kullanici = kt.TgetByID(id);
            return View(kullanici);
        }

        [HttpPost]
        public IActionResult AdminKategoriDuzenle(Kullanici kullanici)
        {
            kt.Tupdate(kullanici);
            return RedirectToAction("AdminKullaniciListeleme", "Kullanici");
        }
    }
}

