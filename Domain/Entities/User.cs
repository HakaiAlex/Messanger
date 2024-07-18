using Domain.Common;

namespace Domain.Entities;

public class User : Base
{
    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string? ProfilePicture { get; private set; }
    public string Status { get; private set; } = "Offline";

    public ICollection<Message> SentMessages { get; private set; } = [];
    public ICollection<Message> ReceivedMessages { get; private set; } = [];
    public ICollection<Contact> Contacts { get; private set; } = [];
    public ICollection<Chat> Chats { get; private set; } = [];

    private User() { }

    public User(string username, string email, string passwordHash, string profilePicture, string status
        , ICollection<Message> sentMessages, ICollection<Message> receivedMessages, ICollection<Contact> contacts
        , ICollection<Chat> chats)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        ProfilePicture = profilePicture;
        Status = status;
        SentMessages = sentMessages;
        ReceivedMessages = receivedMessages;
        Contacts = contacts;
        Chats = chats;
    }
}
