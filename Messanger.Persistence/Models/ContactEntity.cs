namespace Messenger.Persistence.Entities;

public class ContactEntity
{
    public int UserID { get; set; }
    public int ContactID { get; set; }
    public string Status { get; set; } = "Offline";

    public UserEntity User { get; set; } = null!;
    public UserEntity Contact { get; set; } = null!;
}
