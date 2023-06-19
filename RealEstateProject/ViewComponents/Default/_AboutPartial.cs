using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _AboutPartial:ViewComponent
	{
		HakkindaManager hakkindaManager=new HakkindaManager(new EFHakkindaDAL());
		public IViewComponentResult Invoke()
		{
			var values=hakkindaManager.TgetList();
			return View(values);
		}
	}
}
