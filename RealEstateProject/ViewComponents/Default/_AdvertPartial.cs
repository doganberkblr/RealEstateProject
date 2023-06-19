using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _AdvertPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{ return View(); }
	}
}
