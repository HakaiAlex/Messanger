using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Messenger.Persistence;

public class MessengerDbContext(IConfiguration configuration)
        : DbContext
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<ChatEntity>? Chats { get; set; }
    public DbSet<ContactEntity>? Contacts { get; set; }
    public DbSet<GroupEntity>? Groups { get; set; }
    public DbSet<MessageEntity>? Messages { get; set; }
    public DbSet<UserEntity>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetConnectionString(nameof(MessengerDbContext)))
            .UseLoggerFactory(CreateLoggerFactory())
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => builder.AddConsole());
}
