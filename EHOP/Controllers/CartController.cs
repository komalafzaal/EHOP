using Microsoft.AspNetCore.Mvc;

namespace EHOP.Controllers
{
    public class CartController : Controller
    {
        public IActionResult showCart()
        {
            return View();
        }
    }
}
