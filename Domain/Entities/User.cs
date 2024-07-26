using Domain.Common;

namespace Domain.Entities;

public class User : Base
{
    /*
     * Unable to create a 'DbContext' of type ''. 
     * The exception 'Cannot create a relationship between 'Chat.Participants' and 'User.Chats' 
     * because a relationship already exists between 'User.Chats' and 'Chat.Admin'. 
     * Navigations can only participate in a single relationship. 
     * If you want to override an existing relationship call 'Ignore' on the navigation 'User.Chats' first in 'OnModelCreating'.' 
     * was thrown while attempting to create an instance. 
     * For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
     * 
     */
    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string? ProfilePicture { get; private set; }
    public string Status { get; private set; } = "Offline";

    public List<Message> SentMessages { get; private set; } = [];
    public List<Message> ReceivedMessages { get; private set; } = [];
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

    public void SendMessage(Message message)
    {
        SentMessages.Add(message);
    }

    public void ReceiveMessage(Message message)
    {
        ReceivedMessages.Add(message);
    }

    public List<Message> GetSentMessages()
    {
        return SentMessages;
    }

    public List<Message> GetReceivedMessages()
    {
        return ReceivedMessages;
    }

    public void CreateChat(int id, string chatName)
    {
        var chat = new Chat(id, true, chatName);
        AddChat(chat);
    }

    public void RemoveChat(Chat chat)
    {
        Chats.Remove(chat);
    }

    private void AddChat(Chat chat)
    {
        Chats.Add(chat);
    }
}
