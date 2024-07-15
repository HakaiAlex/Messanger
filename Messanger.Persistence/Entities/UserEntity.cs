namespace Messenger.Persistence.Entities;

public class UserEntity
{
    public int ID { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? ProfilePicture { get; set; }
    public string Status { get; set; } = "Offline";

    public ICollection<MessageEntity> SentMessages { get; set; } = [];
    public ICollection<MessageEntity> ReceivedMessages { get; set; } = [];
    public ICollection<ChatEntity> Chats { get; set; } = [];
    public ICollection<ContactEntity> Contacts { get; set; } = [];
    public ICollection<GroupEntity> Groups { get; set; } = [];
}
