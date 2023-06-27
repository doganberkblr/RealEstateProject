using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Models;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class HaberController : Controller
    {
        HaberManager kt = new HaberManager(new EFHaberDAL());

        public IActionResult AdminHaberListeleme(int sayfa=1)
        {
            var haberler = kt.TgetList().ToPagedList(sayfa, 2);
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
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("HataSayfasi", "Hata");
            }
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
        public IActionResult HaberleriExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("Haber");
            calismaSayfasi.Cell(1, 1).Value = "Haber ID";
            calismaSayfasi.Cell(1, 2).Value = "Haber Başlığı";
            calismaSayfasi.Cell(1, 3).Value = "Alt Başlık";
            calismaSayfasi.Cell(1, 4).Value = "Haber İçeriği";
            calismaSayfasi.Cell(1, 5).Value = "Haber Tarihi";
            int Satir = 2;
            foreach (var haber in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = haber.HaberID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = haber.HaberBaslik.ToString();
                calismaSayfasi.Cell(Satir, 3).Value = haber.HaberKisaIcerik.ToString();
                calismaSayfasi.Cell(Satir, 4).Value = haber.HaberUzunIcerik.ToString();
                calismaSayfasi.Cell(Satir, 5).Value = haber.HaberTarihi.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminHaberListesi.xlsx");
        }
    }

}

