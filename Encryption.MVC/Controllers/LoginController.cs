using Encryption.Data;
using Encryption.Data.Models;
using Encryption.Hashing.Factories;
using Encryption.KeyGenerator.Factories;
using Encryption.MVC.Models;
using Encryption.MVC.Observables;
using Microsoft.AspNetCore.Mvc;

namespace Encryption.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHashingFactory _hashingFactory;
        private readonly IKeyGeneratorFactory _keyGeneratorFactory;
        private readonly DataContext _dataContext;
        private LoginAttemptPublisher _publisher = new LoginAttemptPublisher();
        private LoginAttemptSubscriber _subscriber = new LoginAttemptSubscriber();



        public LoginController(IHashingFactory hashingFactory, IKeyGeneratorFactory keyGeneratorFactory, DataContext dataContext)
        {
            _hashingFactory = hashingFactory;
            _keyGeneratorFactory = keyGeneratorFactory;
            _dataContext = dataContext;
            _publisher.Subscribe(_subscriber);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {

            Data.Models.User? user = _dataContext.Users.FirstOrDefault(x => x.UserName.Equals(model.UserName));
            if (user != null)
            {
                var createNewHash = _hashingFactory.CreateAlgorithm("SHA256").GetHashValueWithSalt(model.Password, user.Salt);
                if (user.Password.Equals(createNewHash[1]))
                {
                    return RedirectToAction("Succes");
                }
                else
                {
                    _publisher.LoginAttempt(new LoginFailureModel(model.UserName));
                    var currentFailures = _dataContext.LoginFailures.Where(x => x.Username.Equals(model.UserName));
                    var attemptsInLastFiveMinuttes = 0;

                    foreach (var failure in currentFailures)
                    {
                        if (failure.DateTime > DateTime.Now.AddMinutes(-1) && failure.DateTime <= DateTime.Now )
                        {
                            attemptsInLastFiveMinuttes++;
                        }
                    }

                    if (attemptsInLastFiveMinuttes >= 3)
                    {
                        return RedirectToAction("Failure"); 
                    }
                }
            }

            return View(model);
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

        [HttpGet]
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewUser(NewUserViewModel model)
        {
            User newUser = new User();
            newUser.FullName = model.FullName;
            newUser.UserName = model.UserName;
            newUser.Salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);
            //var temp = _hashingFactory.CreateAlgorithm("SHA256").GetHashValueWithSalt(model.Password, newUser.Salt);
            newUser.Password = _hashingFactory.CreateAlgorithm("SHA256").GetHashValueWithSalt(model.Password, newUser.Salt)[1];
            _dataContext.Add(newUser);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
