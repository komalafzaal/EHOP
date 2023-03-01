using EHOP.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EHOP.Models.Interfaces;
using System.Data;
using System.Diagnostics;
using System.Web;
using EHOP.Models.Repository;

namespace EHOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment Environment;


        public IActionResult homePage()
        {
            return View();
        }
        public IActionResult HomePageSeller()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
        
}