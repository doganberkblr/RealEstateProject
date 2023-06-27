using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace RealEstateProject.Controllers
{
    public class MusteriYorumlariController : Controller
    {
        MusteriYorumManager kt = new MusteriYorumManager(new EFMusteriYorumDAL(), new EFKullaniciDAL());
        public IActionResult AdminMusteriYorumListeleme(int sayfa=1)
        {
            var musteriYorumlari = kt.TgetList().ToPagedList(sayfa, 3);
            return View(musteriYorumlari);
        }
        public IActionResult AdminMusteriYorumSil(int id)
        {
            var yorum = kt.TgetByID(id);
            return View(yorum);
        }
        [HttpPost]
        public IActionResult AdminMusteriYorumSil(MusteriYorum musteriYorum)
        {
            kt.Tdelete(musteriYorum);
            return RedirectToAction("AdminMusteriYorumListeleme", "MusteriYorum");
        }
        public IActionResult AdminMusteriYorumDetay(int id)
        {
            var yorum = kt.TgetByID(id);
            return View(yorum);
        }
        public IActionResult MusteriYorumlariniExceleAktar()
        {
            XLWorkbook calismaKitabi = new XLWorkbook();
            var calismaSayfasi = calismaKitabi.Worksheets.Add("MusteriYorumlari");
            calismaSayfasi.Cell(1, 1).Value = "Müşteri Yorum ID";
            calismaSayfasi.Cell(1, 2).Value = "Kullanıcı Adı";
            calismaSayfasi.Cell(1, 3).Value = "Yorum Başlığı";
            calismaSayfasi.Cell(1, 4).Value = "Yorum";
            int Satir = 2;
            foreach (var musteriYorum in kt.TgetList())
            {
                calismaSayfasi.Cell(Satir, 1).Value = musteriYorum.MusteriYorumID.ToString();
                calismaSayfasi.Cell(Satir, 2).Value = musteriYorum.kullanici.KullaniciAdi.ToString();
                calismaSayfasi.Cell(Satir, 3).Value = musteriYorum.MusteriYorumBaslik.ToString();
                calismaSayfasi.Cell(Satir, 4).Value = musteriYorum.MusteriYorumIcerik.ToString();
                Satir++;
            }
            MemoryStream ms = new MemoryStream();
            calismaKitabi.SaveAs(ms);
            var icerik = ms.ToArray();
            return File(icerik, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminMusteriYorumListesi.xlsx");
        }
    }
}
