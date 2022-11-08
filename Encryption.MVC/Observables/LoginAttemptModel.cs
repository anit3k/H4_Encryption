using Encryption.MVC.Models;

namespace Encryption.MVC.Observables
{
    public class LoginFailureModel
    {
        
        public LoginFailureModel(string username)
        {            
            Username = username;
            DateTime = DateTime.Now;
        }

        public string  Username { get; set; }

        public DateTime DateTime { get; set; }

    }
}
