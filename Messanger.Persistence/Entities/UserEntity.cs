namespace Messenger.Persistence.Entities;

public class UserEntity
{
    public int ID { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? ProfilePicture { get; set; }
    public string Status { get; set; } = null!;
}
