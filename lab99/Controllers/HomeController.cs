using lab99.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab99.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ComponentModel> list = new List<ComponentModel>
            {
                new ComponentModel {Id = 1, Name = "Apple", Price = 1f },
                new ComponentModel {Id = 2, Name = "Banana", Price = 3.5f },
                new ComponentModel {Id = 3, Name = "Orange", Price = 13f }
            };

            return View(list);
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
