using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _CategoriesPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{ return View(); }
	}
}
