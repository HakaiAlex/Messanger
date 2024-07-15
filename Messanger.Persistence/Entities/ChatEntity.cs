namespace Messenger.Persistence.Entities;

public class ChatEntity
{
    public int ID { get; set; }
    public ICollection<UserEntity> Participants { get; set; } = [];
    public ICollection<MessageEntity> Messages { get; set; } = [];
}
