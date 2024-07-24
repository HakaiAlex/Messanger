using Domain.Common;

namespace Domain.Entities;

public class User : Base
{
    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string? ProfilePicture { get; private set; }
    public string Status { get; private set; } = "Offline";

    public Dictionary<User, Message> SentMessages { get; private set; } = [];
    public Dictionary<User, Message> ReceivedMessages { get; private set; } = [];
    public List<Contact> Contacts { get; private set; } = [];
    public List<Chat> Chats { get; private set; } = [];

    private User() { }

    public User(string username, string email, string passwordHash, string profilePicture, string status)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        ProfilePicture = profilePicture;
        Status = status;
    }

    public void SendMessage(User user, Message message)
    {
        SentMessages.Add(user, message);
    }

    public void ReceiveMessage(User user, Message message)
    {
        ReceivedMessages.Add(user, message);
    }

    public Dictionary<User, Message> GetSentMessages()
    {
        return SentMessages;
    }

    public Dictionary<User, Message> GetReceivedMessages()
    {
        return SentMessages;
    }
}
