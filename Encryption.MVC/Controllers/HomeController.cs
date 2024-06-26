﻿using Encryption.CaesarCipher.Factories;
using Encryption.Data;
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
        private readonly IKeyGeneratorFactory _keyGeneratorFactory;
        private readonly ICaesarCipherFactory _caesarCipherFactory;
        private static List<PreviousCiphers> _previousCiphers = new List<PreviousCiphers>();
        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger, IHashingFactory hashingFactory, IKeyGeneratorFactory keyGeneratorFactory, 
            ICaesarCipherFactory caesarCipherFactory)
        {
            _logger = logger;
            this._hashingFactory = hashingFactory;
            this._keyGeneratorFactory = keyGeneratorFactory;
            this._caesarCipherFactory = caesarCipherFactory;
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
            var outputHashValue = _hashingFactory.CreateAlgorithm(model.SelectedHashingTypes).GetHashValue(model.Input);
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

            string salt = String.Empty;
            if (model.InputSalt != null)
            {
                salt = model.InputSalt;
            }
            else
            {
                salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(model.SaltLength);
            }
            string[] result = _hashingFactory.CreateAlgorithm(model.SelectedHashingTypes).GetHashValueWithSalt(model.Input, salt);
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

            string key = String.Empty;
            if (model.InputKey != null)
            {
                key = model.InputKey;
            }
            else
            {
                key = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(model.KeyLength);
            }
            var outputhashedString = model.Input;
            var result = _hashingFactory.CreateAlgorithm(model.SelectedHashingTypes).GetHashValueWithKey(model.Input, key);

            ModelState.Clear();
            return View(new HashingWithKeyViewModel(result[0], outputhashedString, result[1]));
        }
        #endregion

        #region Caesar Cipher
        [HttpGet]
        public IActionResult CaesarCipher()
        {
            _previousCiphers.Clear();
            return View(new CaesarCipherViewModel());
        }
        [HttpPost]
        public IActionResult CaesarCipher(CaesarCipherViewModel model)
        {
            var result = _caesarCipherFactory.Create().CipherText(model.Input, Convert.ToInt32(model.SelectedChiperIndex), Convert.ToBoolean(model.SelectedEncryptDecrypt));
            model.SelectedEncryptDecrypt = model.SelectedEncryptDecrypt == "false" ? "Encrypt" : "Decrypt";

            _previousCiphers.Add(new PreviousCiphers( result, model.Input, model.SelectedEncryptDecrypt, model.SelectedChiperIndex));
            return View(new CaesarCipherViewModel(_previousCiphers));
        }
        #endregion

        #region AsymmetricEncryption
        [HttpGet]
        public IActionResult Asymmetric()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Asymmetric(AsymmetricViewModel model)
        {
            return View();
        }
        #endregion

        #region SymmetricEncryption
        [HttpGet]
        public IActionResult Symmetric()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Symmetric(SymmetricViewModel model)
        {
            return View();
        }
        #endregion

        #region Documentation
        public IActionResult Documentation()
        {
            return View();
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