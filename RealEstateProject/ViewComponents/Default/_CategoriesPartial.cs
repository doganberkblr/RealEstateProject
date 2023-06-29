using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _CategoriesPartial:ViewComponent
	{
		IlanManager kt = new IlanManager(new EFIlanDAL(), new EFKullaniciDAL(), new EFKategoriDAL(), new EFKonutTipiDAL(), new EFSehirDAL());
		public IViewComponentResult Invoke()
		{
			var values = kt.TgetList();
			return View(values);
		}
	}
}
