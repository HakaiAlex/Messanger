namespace Messenger.Domain;

public class Group
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public List<int>? Participants { get; set; }
    public List<Message> Messages { get; set; } = null!;
    public int AdminID { get; set; }
}
