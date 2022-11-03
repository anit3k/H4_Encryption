using Encryption.Hashing;
using Encryption.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Encryption.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region fields
        private readonly ILogger<HomeController> _logger;
        private readonly IHashingFactory _hashingFactory;
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, IHashingFactory hashingFactory)
        {
            _logger = logger;
            this._hashingFactory = hashingFactory;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region SingleWayHashing
        [HttpGet]
        public IActionResult Hashing()
        {
            return View(new HashingViewModel());
        }

        [HttpPost]
        public IActionResult Hashing(HashingViewModel model)
        {
            var outputHashValue = _hashingFactory.CreateHashing(model.SelectedHashingTypes).GetHashValue(model.Input);
            var outputHashString = model.Input;

            ModelState.Clear();

            return View(new HashingViewModel(outputHashString, outputHashValue));
        }
        #endregion

        #region HashingWithSalt
        [HttpGet]
        public IActionResult HashingWithSalt()
        {
            return View(new HashingWithSaltViewModel());
        }
        [HttpPost]
        public IActionResult HashingWithSalt(HashingWithSaltViewModel model)
        {
            var outputHashedString = model.Input;
            var outputHashValue = _hashingFactory.CreateHashing(model.SelectedHashingTypes).GetHashValue(model.Input);
            var saltString = "insert salt string here!";

            ModelState.Clear();
            
            return View(new HashingWithSaltViewModel(saltString, outputHashedString, outputHashValue));
        }
        #endregion

        #region HashingWithKey
        [HttpGet]
        public IActionResult HashingWithKey()
        {
            return View(new HashingWithKeyViewModel());
        }
        [HttpPost]
        public IActionResult HashingWithKey(HashingWithKeyViewModel model)
        {
            var outputhashedString = model.Input;
            var outputHashValue = _hashingFactory.CreateHashing(model.SelectedHashingTypes).GetHashValue(model.Input);
            var key = "insert key string here!";

            ModelState.Clear();
            return View(new HashingWithKeyViewModel(key, outputhashedString, outputHashValue));
        }
        #endregion

        #region Default
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}