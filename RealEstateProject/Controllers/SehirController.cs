using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class SehirController : Controller
    {
        SehirManager kt = new SehirManager(new EFSehirDAL());

   

        public IActionResult AdminSehirListeleme(int sayfa=1)
        {
            var sehir = kt.TgetList().ToPagedList(sayfa, 3);
            return View(sehir);
        }
        public IActionResult AdminSehirEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminSehirEkle(Sehir sehir)
        {
            try
            {
                kt.Tadd(sehir);
                return RedirectToAction("AdminSehirListeleme", "Sehir");
            }
            catch (Exception ex)
            {
                return RedirectToAction("HataSayfasi", "Hata");
            }
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
        public IActionResult SehirleriExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("Sehir");
            calismaSayfasi.Cell(1, 1).Value = "Şehir ID";
            calismaSayfasi.Cell(1, 2).Value = "Şehir Adı";
            int Satir = 2;
            foreach (var sehir in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = sehir.SehirID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = sehir.SehirAdi.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminSehirListesi.xlsx");
        }
    }
}
