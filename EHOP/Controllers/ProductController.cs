using EHOP.Models.Interfaces;
using EHOP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EHOP.Models.Repository;

namespace EHOP.Controllers
{
    public class ProductController : Controller
    {       
        private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";
        private const string _loggedInUserId = "e2eb8989-a81a-4151-8e86-eb95a7961da2";
        private readonly ILogger<ProductController> _logger;
        private readonly IProduct _productRepository;

        public ProductController(ILogger<ProductController> logger, IProduct productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult addProduct()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      

        [HttpPost]

        public IActionResult addProduct(Product p, List<IFormFile> postedFiles)
        {
            var fileName = "";
            string wwwPath = Directory.GetCurrentDirectory();
            string path = Path.Combine(wwwPath, "uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in postedFiles)
            {
                fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";

                }
            }
            p.imagename = fileName;
            string ? cookieValue = HttpContext.Request.Cookies["Id"].ToString();

            _productRepository.addProduct(p, cookieValue);

            //if (ModelState.IsValid)
            //{
            //komal? meet left ? acha...yar del wala kar lain? jo jo hota wo lr lain...updayewala h 

            //}
            return View();
        }


        public ViewResult showAllProducts()
        {
            List<Product> p = new List<Product>();
            p = _productRepository.GetWomenProducts();

            p = _productRepository.GetMenProducts();

            p = _productRepository.GetElectronicsProducts();

            p = _productRepository.GetBeautyProducts();

            p = _productRepository.GetHomeandDecorProducts();

            return View("products", p);


        }
    }
    //public IActionResult products()
    //    {
    //        return View();
    //    }
    //    public IActionResult search()
    //    {
    //        return View();
    //    }
    //}
}
