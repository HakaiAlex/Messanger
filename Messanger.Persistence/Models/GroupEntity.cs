namespace Messenger.Persistence.Entities;

public class GroupEntity
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public List<int> ParticipantsID { get; set; } = [];
    public ICollection<MessageEntity> Messages { get; set; } = [];
    public int AdminID { get; set; }
    public UserEntity Admin { get; set; } = null!;
    public ICollection<UserEntity> Participants { get; set; } = [];
}
