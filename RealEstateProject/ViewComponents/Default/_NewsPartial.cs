using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _NewsPartial:ViewComponent
	{
		HaberManager haberManager=new HaberManager(new EFHaberDAL());
		public IViewComponentResult Invoke()
		{
			var values=haberManager.TgetList();
			return View(values); 
		}
	}
}
