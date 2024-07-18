using Domain.Common;

namespace Domain.Entities;

public class Message : Base
{
    public int SenderID { get; private set; }
    public int ReceiverID { get; private set; }
    public string Content { get; private set; } = null!;
    public DateTime Timestamp { get; private set; }
    public bool IsRead { get; private set; }

    public User Sender { get; private set; } = null!;
    public User Receiver { get; private set; } = null!;

    private Message() { }

    public Message(int senderID, int receiverID, string content, DateTime timestamp, bool isRead, User sender, User receiver)
    {
        SenderID = senderID;
        ReceiverID = receiverID;
        Content = content;
        Timestamp = timestamp;
        IsRead = isRead;
        Sender = sender;
        Receiver = receiver;
    }
}
