using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class MusteriMesajController : Controller
    {
        MusteriMesajManager kt=new MusteriMesajManager(new EFMusteriMesajDAL());
		public IActionResult MusteriMesajGonder()
		{
			return View();
			
		}
		[HttpPost]
		public IActionResult MusteriMesajGonder(MusteriMesaj musteriMesaj)
		{
			try
			{
				kt.Tadd(musteriMesaj);
				return RedirectToAction("LoginIndex", "Default");


			}
			catch (Exception ex)
			{
				return RedirectToAction("HataSayfasi", "Hata");
			}
		}
        public IActionResult KullaniciMesajGonder()
        {
            return View();

        }
        [HttpPost]
        public IActionResult KullaniciMesajGonder(MusteriMesaj musteriMesaj)
        {
            try
            {
                kt.Tadd(musteriMesaj);
                return RedirectToAction("Index", "Default");


            }
            catch (Exception ex)
            {
                return RedirectToAction("HataSayfasi", "Hata");
            }
        }
        public IActionResult AdminMusteriMesajListeleme(int sayfa=1)
        {
            var musteriMesajlari = kt.TgetList().ToPagedList(sayfa, 3);
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
        public IActionResult MusteriMesajExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("MusteriMesaj");
            calismaSayfasi.Cell(1, 1).Value = "Mesaj ID";
            calismaSayfasi.Cell(1, 2).Value = "Müşteri Adı-Soyadı";
            calismaSayfasi.Cell(1, 3).Value = "E-Mail Adresi";
            calismaSayfasi.Cell(1, 4).Value = "Müşterinin Mesajı";
            int Satir = 2;
            foreach (var musteriMesaj in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = musteriMesaj.MusteriMesajID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = musteriMesaj.MusteriAdiSoyadi.ToString();
                calismaSayfasi.Cell(Satir, 3).Value = musteriMesaj.MusteriEMail.ToString();
                calismaSayfasi.Cell(Satir, 4).Value = musteriMesaj.MusteriMesajIcerik.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminMusteriMesajListesi.xlsx");
        }
    }
}
