using EHOP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.Xml;

namespace EHOP.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
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
