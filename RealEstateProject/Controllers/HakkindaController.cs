using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class HakkindaController : Controller
    {
		HakkindaManager kt = new HakkindaManager(new EFHakkindaDAL());

		public IActionResult AdminHakkindaListeleme(int sayfa=1)
		{
			var hakkindalar = kt.TgetList().ToPagedList(sayfa, 3);
            return View(hakkindalar);
		}
		public IActionResult AdminHakkindaEkle()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AdminHakkindaEkle(Hakkinda hakkinda)
		{
			kt.Tadd(hakkinda);
			return RedirectToAction("AdminHakkindaListeleme", "Hakkinda");
		}
		public IActionResult AdminHakkindaSil(int id)
		{
			var hakkinda = kt.TgetByID(id);
			return View(hakkinda);
		}
		[HttpPost]
		public IActionResult AdminHakkindaSil(Hakkinda hakkinda)
		{
			kt.Tdelete(hakkinda);
			return RedirectToAction("AdminHakkindaListeleme", "Hakkinda");
		}

		public IActionResult AdminHakkindaDetay(int id)
		{
			var hakkinda = kt.TgetByID(id);
			return View(hakkinda);
		}

		public IActionResult AdminHakkindaDuzenle(int id)
		{
			Hakkinda hakkinda = kt.TgetByID(id);
			return View(hakkinda);
		}

		[HttpPost]
		public IActionResult AdminHakkindaDuzenle(Hakkinda hakkinda)
		{
			kt.Tupdate(hakkinda);
			return RedirectToAction("AdminHakkindaListeleme", "Hakkinda");
		}
        public IActionResult HakkindalariExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("Hakkinda");
            calismaSayfasi.Cell(1, 1).Value = "Hakkinda ID";
            calismaSayfasi.Cell(1, 2).Value = "Hakkında Başlığı";
            calismaSayfasi.Cell(1, 3).Value = "Hakkında Alt Başlığı";
            calismaSayfasi.Cell(1, 4).Value = "Hakkında İçeriği";
            int Satir = 2;
            foreach (var hakkinda in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = hakkinda.HakkindaID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = hakkinda.HakkindaBaslik.ToString();
                calismaSayfasi.Cell(Satir, 3).Value = hakkinda.HakkindaAltBaslik.ToString();
                calismaSayfasi.Cell(Satir, 4).Value = hakkinda.HakkindaIcerik.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminHakkindaListesi.xlsx");
        }
    }
}
