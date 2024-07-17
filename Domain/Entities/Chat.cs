namespace Domain.Entities;

public class Chat
{
    public Guid ID { get; set; }
    public List<Guid> Participants { get; set; } = [];
    public List<Message> Messages { get; set; } = [];
}
