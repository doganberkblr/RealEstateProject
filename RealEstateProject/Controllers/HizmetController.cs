using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class HizmetController : Controller
    {
        HizmetManager kt = new HizmetManager(new EFHizmetDAL());

        public IActionResult AdminHizmetListeleme()
        {
            var hizmetler = kt.TgetList();
            return View(hizmetler);
        }
        public IActionResult AdminHizmetEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminHizmetEkle(Hizmetler hizmet)
        {
            kt.Tadd(hizmet);
            return RedirectToAction("AdminHizmetListeleme", "Hizmet");
        }
        public IActionResult AdminHizmetSil(int id)
        {
            var hizmetler = kt.TgetByID(id);
            return View(hizmetler);
        }
        [HttpPost]
        public IActionResult AdminHizmetSil(Hizmetler hizmet)
        {
            kt.Tdelete(hizmet);
            return RedirectToAction("AdminHizmetListeleme", "Hizmet");
        }

        public IActionResult AdminHizmetDetay(int id)
        {
            var hizmetler = kt.TgetByID(id);
            return View(hizmetler);
        }

        public IActionResult AdminHizmetDuzenle(int id)
        {
            Hizmetler hizmet = kt.TgetByID(id);
            return View(hizmet);
        }

        [HttpPost]
        public IActionResult AdminHizmetDuzenle(Hizmetler hizmet)
        {
            kt.Tupdate(hizmet);
            return RedirectToAction("AdminHizmetListeleme", "Hizmet");
        }
    }
}

