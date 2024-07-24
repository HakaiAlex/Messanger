using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(MessengerDbContext));

        services.AddDbContext<MessengerDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging();
        });
        services.AddScoped<IMessengerDbContext>(provider => provider.GetRequiredService<MessengerDbContext>());

        services.AddScoped<MessengerDbContextInitializer>();

        return services;
    }

    private static ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => builder.AddConsole());
}
