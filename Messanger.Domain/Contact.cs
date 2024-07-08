namespace Messenger.Domain;

public class Contact
{
    public int UserID { get; set; }
    public int ContactID { get; set; }
    public string Status { get; set; } = null!;
}
