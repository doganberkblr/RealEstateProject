using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _CategoriesPartial:ViewComponent
	{
		KategoriManager kategoriManager=new KategoriManager(new EFKategoriDAL());
		public IViewComponentResult Invoke()
		{
			var values=kategoriManager.TgetList();
			return View(values); 
		}
	}
}
