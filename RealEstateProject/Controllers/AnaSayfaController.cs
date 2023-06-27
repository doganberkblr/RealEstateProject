using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
  
    public class AnaSayfaController : Controller
    {
        IlanManager kt = new IlanManager(new EFIlanDAL(), new EFKullaniciDAL(), new EFKategoriDAL(), new EFKonutTipiDAL(), new EFSehirDAL());
        Context c = new Context();
        public IActionResult AdminAnaSayfa()
        {

            var ilanlar = kt.TgetList();
            return View(ilanlar);
        }
    }
}
