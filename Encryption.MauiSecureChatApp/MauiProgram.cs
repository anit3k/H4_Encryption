using Encryption.Asymmetric.Factories;
using Encryption.MauiSecureChatApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Encryption.Symmetric.Factories;

namespace Encryption.MauiSecureChatApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // pages and models
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<ChatPage>();
            builder.Services.AddSingleton<ChatViewModel>();

            // injected services to be used
            builder.Services.AddScoped<IRSAFactory, RSAFactoryImplementation>();
            builder.Services.AddScoped<ISymmetricFactory, SymmetricFactoryImplementation>();
            builder.Services.AddSingleton<ICryptographicSetupFactory, CryptographicSetupFactoryImplmentation>();

            return builder.Build();
        }
    }
}