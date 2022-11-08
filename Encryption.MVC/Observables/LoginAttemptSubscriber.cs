using Encryption.Data;
using Encryption.Data.Models;
using Encryption.MVC.Models;
using Microsoft.AspNetCore.Mvc.Localization;

namespace Encryption.MVC.Observables
{
    public class LoginAttemptSubscriber : IObserver<LoginFailureModel>
    {
        private IDisposable unsubscriber;
        private readonly DataContext _context = new DataContext();       
       
        public virtual void Subscribe(IObservable<LoginFailureModel> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }
        public virtual void OnCompleted()
        {
            Console.WriteLine("The Subscriber has been completed");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("Error in subscriber");
        }

        public virtual void OnNext(LoginFailureModel value)
        {
            _context.LoginFailures.Add(new LoginFailure() { Username = value.Username, DateTime = value.DateTime});
            _context.SaveChanges();
            Console.WriteLine("In next method");
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }        
    }
}
