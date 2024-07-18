namespace Infrastructure.Data;

public class MessengerDbContextInitializer
{
    public static void Initialize(MessengerDbContext context) => context.Database.EnsureCreated();
}
