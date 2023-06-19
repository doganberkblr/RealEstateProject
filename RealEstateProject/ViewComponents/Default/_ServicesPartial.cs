using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _ServicesPartial:ViewComponent
	{
        HizmetManager hizmetManager = new HizmetManager(new EFHizmetDAL());
        public IViewComponentResult Invoke()
		{
			var values=hizmetManager.TgetList();
			return View(values);
		}
	}
}
