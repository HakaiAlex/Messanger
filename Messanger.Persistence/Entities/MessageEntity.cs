namespace Messenger.Persistence.Entities;

public class MessageEntity
{
    public int ID { get; set; }
    public int SenderID { get; set; }
    public int ReceiverID { get; set; }
    public string Content { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public bool IsRead { get; set; }

    public UserEntity Sender { get; set; } = null!;
    public UserEntity Receiver { get; set; } = null!;
}
