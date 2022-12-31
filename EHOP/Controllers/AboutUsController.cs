using Microsoft.AspNetCore.Mvc;

namespace EHOP.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult aboutUs()
        {
            return View();
        }
        public IActionResult contactUs()
        {
            return View();
        }
    }
}
