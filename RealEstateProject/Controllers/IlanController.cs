using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateProject.Models;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class IlanController : Controller
    {
        IlanManager kt = new IlanManager(new EFIlanDAL(),new EFKullaniciDAL(),new EFKategoriDAL(),new EFKonutTipiDAL(),new EFSehirDAL());
        Context c=new Context();
        public IActionResult AdminIlanListeleme(int sayfa=1)
        {
            var ilanlar = kt.TgetList().ToPagedList(sayfa, 3);
            return View(ilanlar);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminIlanEkle()
        {
            List<SelectListItem> KullaniciValues=(from x in c.Kullanicilar.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.KullaniciAdi,
                                             Value=x.KullaniciID.ToString()
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
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdminIlanEkle(IlanFotografEkle a)
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
            k.KonutTipiID= a.KonutTipiID;   
            k.SehirID= a.SehirID;
            k.KullaniciID= a.KullaniciID;
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
            return RedirectToAction("AdminIlanListeleme", "Ilan");

        }
        public IActionResult AdminIlanSil(int id)
        {
            var ilanlar = kt.TgetByID(id);
            return View(ilanlar);
        }
        [HttpPost]
        public IActionResult AdminIlanSil(Ilan ilanlar)
        {
            kt.Tdelete(ilanlar);
            return RedirectToAction("AdminIlanListeleme", "Ilan");
        }

        public IActionResult AdminIlanDetay(int id)
        {
            var ilanlar = kt.TgetByID(id);
            return View(ilanlar);
        }

        [HttpGet]
        public IActionResult AdminIlanDuzenle(int id)
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
            Ilan ilanlar = kt.TgetByID(id);
            return View(ilanlar);
        }

        [HttpPost]
        public IActionResult AdminIlanDuzenle(Ilan ilanlar)
        {
            kt.Tupdate(ilanlar);
            return RedirectToAction("AdminIlanListeleme", "Ilan");
        }
        public IActionResult IlanlariExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("Ilanlar");
            calismaSayfasi.Cell(1, 1).Value = "İlan ID";
            calismaSayfasi.Cell(1, 2).Value = "Kullanıcı Adı";
            calismaSayfasi.Cell(1, 3).Value = "Kategori Adı";
            calismaSayfasi.Cell(1, 4).Value = "Konut Tipi";
            calismaSayfasi.Cell(1, 5).Value = "Şehri";
            calismaSayfasi.Cell(1, 6).Value = "İlanın Başlığı";
            calismaSayfasi.Cell(1, 7).Value = "İlanın Açıklaması";
            calismaSayfasi.Cell(1, 8).Value = "İlanın Fiyatı";
            calismaSayfasi.Cell(1, 9).Value = "İlanın Tarihi";
            int Satir = 2;
            foreach (var ilan in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = ilan.IlanID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = ilan.kullanici.KullaniciAdi.ToString();
                calismaSayfasi.Cell(Satir, 3).Value = ilan.kategori.KategoriAdi.ToString();
                calismaSayfasi.Cell(Satir, 4).Value = ilan.konutTipi.KonutTipiAdi.ToString();
                calismaSayfasi.Cell(Satir, 5).Value = ilan.sehir.SehirAdi.ToString();
                calismaSayfasi.Cell(Satir, 6).Value = ilan.IlanBasligi.ToString();
                calismaSayfasi.Cell(Satir, 7).Value = ilan.IlanAciklamasi.ToString();
                calismaSayfasi.Cell(Satir, 8).Value = ilan.IlanFiyati.ToString();
                calismaSayfasi.Cell(Satir, 9).Value = ilan.IlanTarihi.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminIlanListesi.xlsx");
        }
    }
}

