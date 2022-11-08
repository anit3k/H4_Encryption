namespace Encryption.MVC.Observables
{
    public class LoginAttemptPublisher : IObservable<LoginFailureModel>
    {
        private List<IObserver<LoginFailureModel>> _subscribers;

        public LoginAttemptPublisher()
        {
            _subscribers = new List<IObserver<LoginFailureModel>>();           
        }
        public IDisposable Subscribe(IObserver<LoginFailureModel> subscriber)
        {
            if (!_subscribers.Contains(subscriber))
                _subscribers.Add(subscriber);
            return new Unsubscriber(_subscribers, subscriber);
        }
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<LoginFailureModel>> _observers;
            private IObserver<LoginFailureModel> _observer;

            public Unsubscriber(List<IObserver<LoginFailureModel>> observers, IObserver<LoginFailureModel> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void LoginAttempt(LoginFailureModel model)
        {
            
            foreach (var observer in _subscribers)
            {
                observer.OnNext(model);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in _subscribers.ToArray())
                if (_subscribers.Contains(observer))
                    observer.OnCompleted();

            _subscribers.Clear();
        }
    }
    public class LoginAttemprUnknownException : Exception
    {
        internal LoginAttemprUnknownException()
        { }
    }
}
