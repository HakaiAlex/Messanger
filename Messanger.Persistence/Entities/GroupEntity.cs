using Messenger.Domain;

namespace Messenger.Persistence.Entities;

public class GroupEntity
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public List<int>? Participants { get; set; }
    public List<MessageEntity> Messages { get; set; } = null!;
    public int AdminID { get; set; }
}
