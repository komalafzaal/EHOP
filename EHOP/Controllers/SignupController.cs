using EHOP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EHOP.Controllers
{
    public class SignupController : Controller
    {
        private readonly ILogger<SignupController> _logger;

        public SignupController(ILogger<SignupController> logger)
        {
            _logger = logger;
        }

        public IActionResult BuyerSignup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BuyerSignup(Buyer b)
        {
            if (ModelState.IsValid)
            {
                EhopContext db = new EhopContext();
                using (db)
                {
                    if (db.Buyers.Where(u => u.Email == b.Email).Count() > 0)
                    {
                        ViewBag.b = "Email already exsists";
                    }
                    else
                    {
                        db.Buyers.Add(b);
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.b = "Registered Succesfully!";
                    }
                  
                }
              
            }
            return View();
        }




     
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
