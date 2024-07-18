using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IMessengerDbContext
{
    DbSet<Chat> Chats { get; }
    DbSet<Contact> Contacts { get; }
    DbSet<Message> Messages { get; }
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
