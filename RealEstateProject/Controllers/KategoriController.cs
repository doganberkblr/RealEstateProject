using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class KategoriController : Controller
    {
        KategoriManager kt=new KategoriManager(new EFKategoriDAL());

        public IActionResult AdminKategoriListeleme()
        {
            var kategoriler = kt.TgetList();
            return View(kategoriler);
        }
        public IActionResult AdminKategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminKategoriEkle(Kategori kategori)
        {
            kt.Tadd(kategori);
            return RedirectToAction("AdminKategoriListeleme", "Kategori");
        }
        public IActionResult AdminKategoriSil(int id)
        {
            var kategori=kt.TgetByID(id);
            return View(kategori);
        }
        [HttpPost]      
        public IActionResult AdminKategoriSil(Kategori kategori)
        {
            kt.Tdelete(kategori);
            return RedirectToAction("AdminKategoriListeleme", "Kategori");
        }

        public IActionResult AdminKategoriDetay(int id)
        {
            var kategoriler=kt.TgetByID(id);
            return View(kategoriler);
        }

        public IActionResult AdminKategoriDuzenle(int id)
        {
            Kategori kategori = kt.TgetByID(id);
            return View(kategori);
        }

        [HttpPost]
        public IActionResult AdminKategoriDuzenle(Kategori kategori)
        {
            kt.Tupdate(kategori);
            return RedirectToAction("AdminKategoriListeleme", "Kategori");
        }
    }
}
