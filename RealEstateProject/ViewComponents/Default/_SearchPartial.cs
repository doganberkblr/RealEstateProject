using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.ViewComponents.Default
{
	public class _SearchPartial:ViewComponent
	{
		public IViewComponentResult Invoke() 
		{
		return View();
		}
	}
}
