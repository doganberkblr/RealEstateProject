using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class HakkindaController : Controller
    {
		HakkindaManager kt = new HakkindaManager(new EFHakkindaDAL());

		public IActionResult AdminHakkindaListeleme()
		{
			var hakkindalar = kt.TgetList();
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
	}
}
