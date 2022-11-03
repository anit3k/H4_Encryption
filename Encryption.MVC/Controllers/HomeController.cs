using Encryption.Hashing;
using Encryption.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Encryption.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHashingFactory _hashingFactory;

        public HomeController(ILogger<HomeController> logger, IHashingFactory hashingFactory)
        {
            _logger = logger;
            this._hashingFactory = hashingFactory;
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
            model.Output = _hashingFactory.CreateHashing(model.SelectedHashingTypes).GetHashValue(model.Input);
            return View(model);
        }
        [HttpGet]
        public IActionResult HashingWithSalt()
        {
            return View(new HashingWithSaltViewModel());
        }
        [HttpPost]
        public IActionResult HashingWithSalt(HashingWithSaltViewModel model)
        {
            model.Output = _hashingFactory.CreateHashing(model.SelectedHashingTypes).GetHashValue(model.Input);
            return View(model);
        }
        [HttpGet]
        public IActionResult HashingWithKey()
        {
            return View(new HashingWithKeyViewModel());
        }
        [HttpPost]
        public IActionResult HashingWithKey(HashingWithKeyViewModel model)
        {
            model.Output = _hashingFactory.CreateHashing(model.SelectedHashingTypes).GetHashValue(model.Input);
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