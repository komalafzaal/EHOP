using EHOP.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Web;

namespace EHOP.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWebHostEnvironment Environment;

        public IActionResult homePage()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult HomePageSeller()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HomePageSeller(List<IFormFile> postedFiles)
        {
            string wwwPath = Directory.GetCurrentDirectory();
            string path = Path.Combine(wwwPath, "uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in postedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";
                }
            }
            return View();
        }

    }
}