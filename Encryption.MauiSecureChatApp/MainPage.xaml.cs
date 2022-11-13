namespace Encryption.MauiSecureChatApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            var name = userName;
            await Shell.Current.GoToAsync(nameof(ChatPage));
        }
    }
}