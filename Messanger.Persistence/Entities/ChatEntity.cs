using Messenger.Domain;

namespace Messenger.Persistence.Entities;

public class ChatEntity
{
    public int ID { get; set; }
    public List<int>? Participants { get; set; }
    public List<MessageEntity> Messages { get; set; } = null!;
}
