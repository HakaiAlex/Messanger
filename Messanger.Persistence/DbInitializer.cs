using Microsoft.EntityFrameworkCore;

namespace Messenger.Persistence;

public class DbInitializer
{
    public static void Initialize(DbContext dbContext) 
    {
        dbContext?.Database.EnsureCreated();
    }
}
