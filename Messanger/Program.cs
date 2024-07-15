using Messenger.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessengerDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MessengerDbContext)));
    });

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
