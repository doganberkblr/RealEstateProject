using Microsoft.AspNetCore.Mvc;

namespace RealEstateProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
