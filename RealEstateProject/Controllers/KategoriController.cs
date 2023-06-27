using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class KategoriController : Controller
    {
        KategoriManager kt=new KategoriManager(new EFKategoriDAL());

        public IActionResult AdminKategoriListeleme(int sayfa=1)
        {
            var kategoriler = kt.TgetList().ToPagedList(sayfa, 3);
            return View(kategoriler);
        }
        public IActionResult AdminKategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminKategoriEkle(Kategori kategori)
        {
            try
            {
                kt.Tadd(kategori);
                return RedirectToAction("AdminKategoriListeleme", "Kategori");
            }
            catch (Exception ex)
            {
                return RedirectToAction("HataSayfasi", "Hata");
            }
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
        public IActionResult KategorileriExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("Kategoriler");
            calismaSayfasi.Cell(1, 1).Value = "Kategori ID";
            calismaSayfasi.Cell(1, 2).Value = "Kategori Adı";
            int Satir = 2;
            foreach (var kategori in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = kategori.KategoriID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = kategori.KategoriAdi.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminKategoriListesi.xlsx");
        }
    }
}
