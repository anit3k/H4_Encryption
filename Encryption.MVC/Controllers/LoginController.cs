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
        #region fields
        private readonly IHashingFactory _hashingFactory;
        private readonly IKeyGeneratorFactory _keyGeneratorFactory;
        private readonly DataContext _dataContext;
        private LoginAttemptPublisher _publisher = new LoginAttemptPublisher();
        private LoginAttemptSubscriber _subscriber = new LoginAttemptSubscriber();
        int _loginFailureCounter;
        #endregion

        #region Constructor
        public LoginController(IHashingFactory hashingFactory, IKeyGeneratorFactory keyGeneratorFactory, DataContext dataContext)
        {
            _hashingFactory = hashingFactory;
            _keyGeneratorFactory = keyGeneratorFactory;
            _dataContext = dataContext;
            _publisher.Subscribe(_subscriber);
        }
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            User? user = GetUser(model);
            if (user != null)
            {
                if (IsUserLocked(model))
                {
                    return RedirectToAction("Failure");
                }
                else if (user.Password.Equals(GetCorrespondingHash(model, user)))
                {
                    CreateNewSaltToUser(model, user);
                    return RedirectToAction("Succes");
                }
               AddLoginFailureToDb(model);
            }
            return View(model);
        }

        private User? GetUser(LoginViewModel model)
        {
            return _dataContext.Users.FirstOrDefault(x => x.UserName.Equals(model.UserName));
        }       
         
        private bool IsUserLocked(LoginViewModel model)
        {
            var currentFailures = GetCurrentFailures(model);
            _loginFailureCounter = 0;

            foreach (var failure in currentFailures)
            {
                if (IsFailureInLast2Minutes(failure))
                {
                    _loginFailureCounter++;
                }
            }
            return IsMaxAttempts();
        }

        private IQueryable<LoginFailure> GetCurrentFailures(LoginViewModel model)
        {
            return _dataContext.LoginFailures.Where(x => x.Username.Equals(model.UserName));
        }

        private static bool IsFailureInLast2Minutes(LoginFailure failure)
        {
            return failure.DateTime > DateTime.Now.AddMinutes(-1) && failure.DateTime <= DateTime.Now;
        }

        private bool IsMaxAttempts()
        {
            return _loginFailureCounter >= 3;
        }       

        private string GetCorrespondingHash(LoginViewModel model, User user)
        {
            return _hashingFactory.CreateAlgorithm("SHA256").GetHashValueWithSalt(model.Password, user.Salt)[1];
        }

        private void CreateNewSaltToUser(LoginViewModel model, User? user)
        {
            user.Salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);
            user.Password = _hashingFactory.CreateAlgorithm("SHA256").GetHashValueWithSalt(model.Password, user.Salt)[1];
            _dataContext.Update(user);
            _dataContext.SaveChanges();
        }

        private void AddLoginFailureToDb(LoginViewModel model)
        {
            _publisher.LoginAttempt(new LoginFailureModel(model.UserName));
        }
        #endregion

        #region Success/Failure
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
        #endregion

        #region AddNewUser
        [HttpGet]
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewUser(NewUserViewModel model)
        {
            CreateNewUser(model);
            return RedirectToAction("Index");
        }

        private void CreateNewUser(NewUserViewModel model)
        {
            User newUser = new User();
            newUser.FullName = model.FullName;
            newUser.UserName = model.UserName;
            newUser.Salt = _keyGeneratorFactory.CreateKeyGenerator().GenerateKey(8);
            newUser.Password = _hashingFactory.CreateAlgorithm("SHA256").GetHashValueWithSalt(model.Password, newUser.Salt)[1];
            _dataContext.Add(newUser);
            _dataContext.SaveChanges();
        }
        #endregion
    }
}
