using EHOP.Models;
using EHOP.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.Xml;

namespace EHOP.Controllers
{
    public class LoginController : Controller
    {
        public int sellerId;
        private readonly ILogger<LoginController> _logger;
        private readonly ISeller _sellerRepository;

        public LoginController(ILogger<LoginController> logger, ISeller sellerRepository)
        {
            _logger = logger;
            _sellerRepository = sellerRepository;
        }
        
        public IActionResult BuyerLogin()
        {
            object data;
            if (HttpContext.Request.Cookies.ContainsKey("User"))
            {
                string? firstVisitedDateTime = HttpContext.Request.Cookies["User"];
                data = "Welcome back " + firstVisitedDateTime;
            }
            else
            {
                data = "visiting first time";
                HttpContext.Response.Cookies.Append("User",data.ToString());
            }
            return View(data);
        }


        [HttpPost]
        public IActionResult BuyerLogin(Buyer b)
        {
            EhopContext db = new EhopContext();
            using (db)  
            {
                if (db.Buyers.Where(u => u.Email == b.Email && u.Password == b.Password).Count() == 0)
                   // var user = db.Buyers.Single(u => u.Email == b.Email && u.Password == b.Password);
                //if (user==null)
                {
                    ViewBag.b = "Incorrect Email or Password";
                }
                else
                {
                    HttpContext.Response.Cookies.Append("User", b.Email.ToString());
                    //string cookie= HttpContext.Request.Cookies["User"];
                    //ViewBag.cookie = cookie;
                    return RedirectToAction(actionName: "HomePage", controllerName: "Home");
                   
                }
            }
            return View();
        }

		public IActionResult SellerLogin()
		{
            object data;
            if (HttpContext.Request.Cookies.ContainsKey("User"))
            {
                string? firstVisitedDateTime = HttpContext.Request.Cookies["User"];
                data = "Welcome back " + firstVisitedDateTime;
            }
            else
            {
                data = "visiting first time";
                HttpContext.Response.Cookies.Append("User", data.ToString());
            }
            

            return View();
		}

		[HttpPost]
		public IActionResult SellerLogin(Seller b)
		{
            EhopContext db = new EhopContext();
            using (db)
            {
                Console.WriteLine("Entered the function");
                if (db.Sellers.Where(u => u.Email == b.Email && u.Password == b.Password).Count() == 0)
                {
					ViewBag.b = "Incorrect Email or Password";
                }
                else
                {
                    HttpContext.Response.Cookies.Append("User", b.Email.ToString());
                    //HttpContext.Response.Cookies.Append("Id", b.Id.ToString());

                    return RedirectToAction(actionName: "HomePageSeller", controllerName: "Home");
                }
            }
            return View();
		}

		public IActionResult Remove()
        {
            HttpContext.Response.Cookies.Delete("User");
            return View("BuyerLogin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
