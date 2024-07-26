using Domain.Common;

namespace Domain.Entities;

public class Chat : Base
{
    public string? ChatName { get; private set; }
    public bool IsGroupChat { get; private set; } = false;

    public List<User> Participants { get; private set; } = [];
    public List<Message> Messages { get; private set; } = [];


    private Chat() { }

    public Chat (int id)
    {
        Id = id;
    }

    public Chat(
        int id,
        bool isGroupChat, 
        string chatName)
    {
        Id = id;
        IsGroupChat = isGroupChat;
        ChatName = chatName;
    }
}
