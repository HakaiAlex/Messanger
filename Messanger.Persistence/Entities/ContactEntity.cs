namespace Messenger.Persistence.Entities;

public class ContactEntity
{
    public int UserID { get; set; }
    public int ContactID { get; set; }
    public string Status { get; set; } = null!;
}
