namespace Messenger.Domain;

public class Message
{
    public int ID { get; set; }
    public int SenderID { get; set; }
    public int ReceiverID { get; set; }
    public string Content { get; set; } = null!;
    public DateTime TimeStamp { get; set; }
    public bool IsRead { get; set; }
}
