using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MessengerDbContext : DbContext, IMessengerDbContext
{
    public DbSet<Chat> Chats => Set<Chat>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
