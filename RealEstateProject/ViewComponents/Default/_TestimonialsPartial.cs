using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _TestimonialsPartial:ViewComponent	
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
