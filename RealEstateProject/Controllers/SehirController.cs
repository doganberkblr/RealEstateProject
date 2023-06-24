using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class SehirController : Controller
    {
        SehirManager kt = new SehirManager(new EFSehirDAL());

        public IActionResult AdminSehirListeleme()
        {
            var sehir = kt.TgetList();
            return View(sehir);
        }
        public IActionResult AdminSehirEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminSehirEkle(Sehir sehir)
        {
            kt.Tadd(sehir);
            return RedirectToAction("AdminSehirListeleme", "Sehir");
        }
        public IActionResult AdminSehirSil(int id)
        {
            var sehir = kt.TgetByID(id);
            return View(sehir);
        }
        [HttpPost]
        public IActionResult AdminSehirSil(Sehir sehir)
        {
            kt.Tdelete(sehir);
            return RedirectToAction("AdminSehirListeleme", "Sehir");
        }

        public IActionResult AdminSehirDetay(int id)
        {
            var sehir = kt.TgetByID(id);
            return View(sehir);
        }

        public IActionResult AdminSehirDuzenle(int id)
        {
            Sehir sehir = kt.TgetByID(id);
            return View(sehir);
        }

        [HttpPost]
        public IActionResult AdminSehirDuzenle(Sehir sehir)
        {
            kt.Tupdate(sehir);
            return RedirectToAction("AdminSehirListeleme", "Sehir");
        }
    }
}
