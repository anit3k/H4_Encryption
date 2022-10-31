using Encryption.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Encryption.MVC.Controllers
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
            return View();
        }
        [HttpGet]
        public IActionResult Hashing()
        {
            return View(new HashingViewModel());
        }

        [HttpPost]
        public IActionResult Hashing(HashingViewModel model)
        {
            model.Output = model.Input + " --> Output here";
            return View(model);
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