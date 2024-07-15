using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Messenger.Persistence;

public class MessengerDbContext(DbContextOptions<MessengerDbContext> options) 
    : DbContext(options)
{
    public DbSet<ChatEntity>? Chats { get; set; }
    public DbSet<ContactEntity>? Contacts { get; set; }
    public DbSet<GroupEntity>? Groups { get; set; }
    public DbSet<MessageEntity>? Messages { get; set; }
    public DbSet<UserEntity>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
