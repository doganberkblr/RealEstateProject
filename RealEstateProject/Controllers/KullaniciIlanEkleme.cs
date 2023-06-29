using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateProject.Models;

namespace RealEstateProject.Controllers
{
	public class KullanıcıIlanEkleme : Controller
	{
		IlanManager kt = new IlanManager(new EFIlanDAL(), new EFKullaniciDAL(), new EFKategoriDAL(), new EFKonutTipiDAL(), new EFSehirDAL());
		Context c = new Context();
		[HttpGet]
		public IActionResult IlanEkle()
		{
            
            List<SelectListItem> KullaniciValues = (from x in c.Kullanicilar.ToList()
													select new SelectListItem
													{
														Text = x.KullaniciAdi,
														Value = x.KullaniciID.ToString()
													}).ToList();
			ViewBag.v1 = KullaniciValues;
			List<SelectListItem> KategoriValues = (from x in c.Kategoriler.ToList()
												   select new SelectListItem
												   {
													   Text = x.KategoriAdi,
													   Value = x.KategoriID.ToString()
												   }).ToList();
			ViewBag.v2 = KategoriValues;
			List<SelectListItem> KonutTipiValues = (from x in c.KonutTipleri.ToList()
													select new SelectListItem
													{
														Text = x.KonutTipiAdi,
														Value = x.KonutTipiID.ToString()
													}).ToList();
			ViewBag.v3 = KonutTipiValues;
			List<SelectListItem> SehirValues = (from x in c.Sehirler.ToList()
												select new SelectListItem
												{
													Text = x.SehirAdi,
													Value = x.SehirID.ToString()
												}).ToList();
			ViewBag.v4 = SehirValues;
			return View();
		}
		[HttpPost]
		public IActionResult IlanEkle(IlanFotografEkle a)
		{
			try
			{
				Ilan k = new Ilan();
				if (a.IlanFotografi != null)
				{
					var extension = Path.GetExtension(a.IlanFotografi.FileName);
					var newimagename = Guid.NewGuid() + extension;
					var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/IlanFotograflari/", newimagename);
					var stream = new FileStream(location, FileMode.Create);
					a.IlanFotografi.CopyTo(stream);
					k.IlanFotografi = newimagename;
				}
				k.KonutTipiID = a.KonutTipiID;
				k.SehirID = a.SehirID;
				k.KullaniciID = a.KullaniciID;
				k.KategoriID = a.KategoriID;
				k.IlanBasligi = a.IlanBasligi;
				k.IlanAciklamasi = a.IlanAciklamasi;
				k.IlanFiyati = a.IlanFiyati;
				k.IlanMetreKare = a.IlanMetreKare;
				k.IlanOdaSayisi = a.IlanOdaSayisi;
				k.IlanBinaYasi = a.IlanBinaYasi;
				k.IlanTarihi = a.IlanTarihi;
				k.IlanEsyaliMİ = a.IlanEsyaliMİ;
				k.IlanDurumu = a.IlanDurumu;
				kt.Tadd(k);
				return RedirectToAction("Index", "Default");
			}
			catch (Exception ex)
			{
				return RedirectToAction("HataSayfasi", "Hata");
			}
		}
	}
}
