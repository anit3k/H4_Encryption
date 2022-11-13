using Encryption.Asymmetric.Factories;
using Encryption.KeyGenerator.Factories;
using Encryption.SignalRHub.Hubs;
using Encryption.SignalRHub.Models;
using Encryption.Symmetric.Factories;
using Encryption.Symmetric.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(o => o.EnableDetailedErrors = true);
builder.Services.AddScoped<ChatHub>();
builder.Services.AddScoped<IRSAFactory, RSAFactoryImplementation>();
builder.Services.AddScoped<IKeyGeneratorFactory, KeyGeneratorFactoryImplementation>();
builder.Services.AddScoped<ISymmetricFactory, SymmetricFactoryImplementation>();
builder.Services.AddScoped<ICryptographicSetupFactory, CryptographicSetupFactoryImplmentation>();
builder.Services.AddSingleton<InfoModel>();
//builder.Services.AddSingleton<CyptographicSetup>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();

}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

//app.UseCors( x => x.AllowAnyOrigin() );

app.MapHub<ChatHub>("/chatHub");

app.Run();
