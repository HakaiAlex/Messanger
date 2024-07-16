using Messenger.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessengerDbContext>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
try
{
    var context = serviceProvider.GetRequiredService<MessengerDbContext>();
    DbInitializer.Initialize(context);
}
catch (Exception e)
{
    Console.WriteLine($"Внимание произошла ошибка:\n{e}");
}

app.Run();
