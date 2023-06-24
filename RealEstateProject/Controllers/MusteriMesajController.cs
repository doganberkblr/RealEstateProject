using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class MusteriMesajController : Controller
    {
        MusteriMesajManager kt=new MusteriMesajManager(new EFMusteriMesajDAL());
        public IActionResult AdminMusteriMesajListeleme()
        {
            var musteriMesajlari = kt.TgetList();
            return View(musteriMesajlari);
        }
        public IActionResult AdminMusteriMesajSil(int id)
        {
            var mesaj = kt.TgetByID(id);
            return View(mesaj);
        }
        [HttpPost]
        public IActionResult AdminMusteriMesajSil(MusteriMesaj musteriMesaj)
        {
            kt.Tdelete(musteriMesaj);
            return RedirectToAction("AdminMusteriMesajListeleme", "MusteriMesaj");
        }
        public IActionResult AdminMusteriMesajDetay(int id)
        {
            var mesaj = kt.TgetByID(id);
            return View(mesaj);
        }
    }
}
