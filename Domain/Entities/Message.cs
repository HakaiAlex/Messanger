namespace Domain.Entities;

public class Message
{
    public Guid ID { get; set; }
    public Guid SenderID { get; set; }
    public Guid ReceiverID { get; set; }
    public string Content { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public bool IsRead { get; set; }
}
