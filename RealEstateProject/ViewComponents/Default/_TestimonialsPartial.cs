using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _TestimonialsPartial:ViewComponent	
	{
		MusteriYorumManager musteriYorumManager=new MusteriYorumManager(new EFMusteriYorumDAL());
		public IViewComponentResult Invoke()
		{
			var values=musteriYorumManager.TgetList();
			return View(values);
		}
	}
}
