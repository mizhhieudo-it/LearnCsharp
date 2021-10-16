using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bai033_WebASP_USING_DI.Models;

namespace Bai033_WebASP_USING_DI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productSV ;

        public HomeController(ILogger<HomeController> logger,ProductService productService)
        {
            _logger = logger;
            _productSV = productService;
        }
        public IActionResult ProductInfo(string productID){
            Console.WriteLine(productID);
            var sp = _productSV.FindProduct(productID);
            return View(sp);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
