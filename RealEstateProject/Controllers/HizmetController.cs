using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class HizmetController : Controller
    {
        HizmetManager kt = new HizmetManager(new EFHizmetDAL());

        public IActionResult AdminHizmetListeleme(int sayfa=1)
        {
            var hizmetler = kt.TgetList().ToPagedList(sayfa, 3);
            return View(hizmetler);
        }
        public IActionResult AdminHizmetEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminHizmetEkle(Hizmetler hizmet)
        {
            try
            {
                kt.Tadd(hizmet);
                return RedirectToAction("AdminHizmetListeleme", "Hizmet");
            }
            catch (Exception ex)
            {
                return RedirectToAction("HataSayfasi", "Hata");
            }
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
        public IActionResult HizmetleriExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("Hizmetler");
            calismaSayfasi.Cell(1, 1).Value = "Hizmet ID";
            calismaSayfasi.Cell(1, 2).Value = "Hizmet Adı";
            calismaSayfasi.Cell(1, 3).Value = "Hizmet Açıklaması";
            int Satir = 2;
            foreach (var hizmetler in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = hizmetler.HizmetID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = hizmetler.HizmetAdi.ToString();
                calismaSayfasi.Cell(Satir, 3).Value = hizmetler.HizmetAciklamasi.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminHizmetListesi.xlsx");
        }
    }
}

