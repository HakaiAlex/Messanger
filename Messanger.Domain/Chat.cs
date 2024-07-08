namespace Messenger.Domain;

public class Chat
{
    public int ID { get; set; }
    public List<int>? Participants { get; set; }
    public List<Message> Messages { get; set; } = null!;
}
