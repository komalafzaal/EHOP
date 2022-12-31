using Microsoft.AspNetCore.Mvc;

namespace EHOP.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult products()
        {
            return View();
        }
        public IActionResult search()
        {
            return View();
        }
    }
}
