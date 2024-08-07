using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Message : Base
{
    public int SenderId { get; private set; }
    public int ReceiverId { get; private set; }
    public int ChatId { get; private set; }
    public string Content { get; private set; } = null!;
    public DateTime Timestamp { get; private set; }
    public bool IsDeliver { get; private set; } = false;
    public bool IsRead { get; private set; } = false;

    public User Sender { get; private set; } = null!;
    public User Receiver { get; private set; } = null!;
    public Chat Chat { get; private set; } = null!;

    private Message() { }

    public Message(
        int senderID,
        int receiverID, 
        string content, 
        DateTime timestamp, 
        bool isDeliver,
        bool isRead)
    {
        SenderId = senderID;
        ReceiverId = receiverID;
        Content = content;
        Timestamp = timestamp;
        IsDeliver = isDeliver;
        IsRead = isRead;
    }
}
