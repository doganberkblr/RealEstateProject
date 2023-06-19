using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class KonutTipiController : Controller
    {
        KonutTipiManager kt = new KonutTipiManager(new EFKonutTipiDAL());

        public IActionResult AdminKonutTipiListeleme()
        {
            var konutTipleri = kt.TgetList();
            return View(konutTipleri);
        }
        public IActionResult AdminKonutTipiEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminKonutTipiEkle(KonutTipi konutTipi)
        {
            kt.Tadd(konutTipi);
            return RedirectToAction("AdminKonutTipiListeleme", "KonutTipi");
        }
        public IActionResult AdminKonutTipiSil(int id)
        {
            var konutTipi = kt.TgetByID(id);
            return View(konutTipi);
        }
        [HttpPost]
        public IActionResult AdminKonutTipiSil(KonutTipi konutTipi)
        {
            kt.Tdelete(konutTipi);
            return RedirectToAction("AdminKategoriListeleme", "Kategori");
        }

        public IActionResult AdminKonutTipiDetay(int id)
        {
            var konutTipi = kt.TgetByID(id);
            return View(konutTipi);
        }

        public IActionResult AdminKonutTipiDuzenle(int id)
        {
            KonutTipi konutTipi = kt.TgetByID(id);
            return View(konutTipi);
        }

        [HttpPost]
        public IActionResult AdminKonutTipiDuzenle(KonutTipi konutTipi)
        {
            kt.Tupdate(konutTipi);
            return RedirectToAction("AdminKonutTipiListeleme", "KonutTipi");
        }
    }
}

