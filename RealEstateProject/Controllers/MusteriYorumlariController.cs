using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class MusteriYorumlariController : Controller
    {
        MusteriYorumManager kt = new MusteriYorumManager(new EFMusteriYorumDAL(), new EFKullaniciDAL());
        public IActionResult AdminMusteriYorumListeleme()
        {
            var musteriYorumlari = kt.TgetList();
            return View(musteriYorumlari);
        }
        public IActionResult AdminMusteriYorumSil(int id)
        {
            var yorum = kt.TgetByID(id);
            return View(yorum);
        }
        [HttpPost]
        public IActionResult AdminMusteriYorumSil(MusteriYorum musteriYorum)
        {
            kt.Tdelete(musteriYorum);
            return RedirectToAction("AdminMusteriYorumListeleme", "MusteriYorum");
        }
        public IActionResult AdminMusteriYorumDetay(int id)
        {
            var yorum = kt.TgetByID(id);
            return View(yorum);
        }
    }
}
