using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class KonutTipiController : Controller
    {
        KonutTipiManager kt = new KonutTipiManager(new EFKonutTipiDAL());

        public IActionResult AdminKonutTipiListeleme(int sayfa=1)
        {
            var konutTipleri = kt.TgetList().ToPagedList(sayfa, 3);
            return View(konutTipleri);
        }
        public IActionResult AdminKonutTipiEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminKonutTipiEkle(KonutTipi konutTipi)
        {
            try
            {
                kt.Tadd(konutTipi);
                return RedirectToAction("AdminKonutTipiListeleme", "KonutTipi");
            }
            catch (Exception ex)
            {
                return RedirectToAction("HataSayfasi", "Hata");
            }
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
        public IActionResult KonutTipleriniExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("KonutTipi");
            calismaSayfasi.Cell(1, 1).Value = "Konut Tipi ID";
            calismaSayfasi.Cell(1, 2).Value = "Konut Tipi Adı";
            int Satir = 2;
            foreach (var konutTipi in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = konutTipi.KonutTipiID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = konutTipi.KonutTipiAdi.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminKonutTipiListesi.xlsx");
        }
    }
}

