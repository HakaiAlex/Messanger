using Domain.Common;

namespace Domain.Entities;

public class Chat : Base
{
    public ICollection<User> Participants { get; private set; } = [];
    public ICollection<Message> Messages { get; private set; } = [];
    public int AdminId { get; private set; }

    private Chat() { }

    public Chat(ICollection<User> participants, ICollection<Message> messages, int adminId)
    {
        Participants = participants;
        Messages = messages;
        AdminId = adminId;
    }
}
