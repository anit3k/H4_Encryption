using Encryption.Data;
using Encryption.Hashing.Factories;
using Encryption.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Encryption.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHashingFactory _hashingFactory;
        private readonly DataContext _dataContext;

        public LoginController(IHashingFactory hashingFactory,  DataContext dataContext)
        {
            _hashingFactory = hashingFactory;
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            Data.Models.User? user = _dataContext.Users.FirstOrDefault( x => x.UserName.Equals(model.UserName));
            if (user != null)
            {
                var createNewHash = _hashingFactory.CreateAlgorithm("SHA256").GetHashValueWithSalt(model.Password, user.Salt);
                if (user.Password.Equals(createNewHash[1]))
                    return RedirectToAction("Succes"); 
            }


            return RedirectToAction("Failure");
        }

        [HttpGet]
        public IActionResult Succes()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Failure()
        {
            return View();
        }
    }
}
