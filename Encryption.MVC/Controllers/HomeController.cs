using Encryption.Hashing.Factories;
using Encryption.KeyGenerator.Factories;
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
        private readonly IKeyGeneratorFactory keyGeneratorFactory;
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, IHashingFactory hashingFactory, IKeyGeneratorFactory keyGeneratorFactory)
        {
            _logger = logger;
            this._hashingFactory = hashingFactory;
            this.keyGeneratorFactory = keyGeneratorFactory;
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
            if (model.Input == null)
            {
                return View(new HashingViewModel());
            }
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
            if (model.Input == null || model.SaltLength <= 0)
            {
                return View(new HashingWithSaltViewModel());
            }

            byte[] salt = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(model.SaltLength);
            string[] result = _hashingFactory.CreateHashing(model.SelectedHashingTypes).GetHashValueWithSalt(model.Input, salt);
            string outputHashedString = model.Input;            

            ModelState.Clear();            
            return View(new HashingWithSaltViewModel(result[0], outputHashedString, result[1]));
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
            if (model.Input == null || model.KeyLength <= 0)
            {
                return View(new HashingWithKeyViewModel());
            }
            
            var outputhashedString = model.Input;
            byte[] key = keyGeneratorFactory.CreateKeyGenerator().GenerateKey(model.KeyLength);
            var result = _hashingFactory.CreateHashing(model.SelectedHashingTypes).GetHashValueWithKey(model.Input, key);

            ModelState.Clear();
            return View(new HashingWithKeyViewModel(result[0], outputhashedString, result[1]));
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