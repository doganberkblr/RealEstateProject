using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
   
    public class _AdvertPartial : ViewComponent
	{
        IlanManager ilanManager = new IlanManager(new EFIlanDAL());
        public IViewComponentResult Invoke()
		{ 
			var values=ilanManager.TgetList();
			return View(values); 
		}
	}
}
