namespace Domain.Entities;

public class ChatAdmin
{
    public int UserId { get; private set; }
    public User User { get; private set; } = null!;

    public List<Chat> Chats { get; private set; } = [];

    private ChatAdmin() { }

    public ChatAdmin(User user)
    {
        UserId = user.Id;
        User = user;
    }

    public void CreateChat(int id, string chatName)
    {
        var chat = new Chat(id, true, chatName, UserId, User);
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
