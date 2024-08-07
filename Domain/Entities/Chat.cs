using Domain.Common;

namespace Domain.Entities;

public class Chat : Base
{
    public string? ChatName { get; private set; }
    public bool IsGroupChat { get; private set; } = false;

    private readonly List<User> _users = [];
    private readonly List<Message> _messages = [];
    public IReadOnlyCollection<User> Participants => _users.AsReadOnly();
    public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();


    private Chat() { }

    public Chat(
        string chatName,
        bool isGroupChat = false) 
    {
        ChatName = chatName;
        IsGroupChat = isGroupChat;
    }
}
