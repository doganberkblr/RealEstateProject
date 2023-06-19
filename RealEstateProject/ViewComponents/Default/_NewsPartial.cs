using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _NewsPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{ return View(); }
	}
}
