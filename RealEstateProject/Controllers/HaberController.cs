using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Models;

namespace RealEstateProject.Controllers
{
    public class HaberController : Controller
    {
        HaberManager kt = new HaberManager(new EFHaberDAL());

        public IActionResult AdminHaberListeleme()
        {
            var haberler = kt.TgetList();
            return View(haberler);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminHaberEkle()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdminHaberEkle(HaberFotografEkle a)
        {
            Haber k = new Haber();
            if (a.HaberFotografi != null)
            {
                var extension = Path.GetExtension(a.HaberFotografi.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HaberFotograflari/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                a.HaberFotografi.CopyTo(stream);
                k.HaberFotografi = newimagename;
            }
            k.HaberBaslik = a.HaberBaslik;
            k.HaberKisaIcerik = a.HaberKisaIcerik;
            k.HaberUzunIcerik = a.HaberUzunIcerik;
            k.HaberTarihi = a.HaberTarihi;
            k.HaberDurumu = a.HaberDurumu;
            kt.Tadd(k);
            return RedirectToAction("AdminHaberListeleme", "Haber");
        }
        public IActionResult AdminHaberSil(int id)
        {
            var haberler = kt.TgetByID(id);
            return View(haberler);
        }
        [HttpPost]
        public IActionResult AdminHaberSil(Haber haberler)
        {
            kt.Tdelete(haberler);
            return RedirectToAction("AdminHaberListeleme", "Haber");
        }

        public IActionResult AdminHaberDetay(int id)
        {
            var haberler = kt.TgetByID(id);
            return View(haberler);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminHaberDuzenle(int id)
        {

            Haber haberler = kt.TgetByID(id);
            if (haberler == null)
            {

                return RedirectToAction("AdminHaberListeleme", "Haber");
            }


            return View(haberler);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdminHaberDuzenle(HaberFotografEkle model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Haber haber = kt.TgetByID(model.HaberID);
            if (haber == null)
            {

                return RedirectToAction("AdminHaberListeleme", "Haber");
            }


            haber.HaberBaslik = model.HaberBaslik;
            haber.HaberKisaIcerik = model.HaberKisaIcerik;
            haber.HaberUzunIcerik = model.HaberUzunIcerik;
            haber.HaberDurumu = model.HaberDurumu;
            haber.HaberTarihi = model.HaberTarihi;

            if (model.HaberFotografi != null)
            {
                var extension = Path.GetExtension(model.HaberFotografi.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HaberFotograflari/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.HaberFotografi.CopyTo(stream);
                haber.HaberFotografi = newimagename;
            }


            kt.Tupdate(haber);

            return RedirectToAction("AdminHaberListeleme", "Haber");
        }
    }

}

