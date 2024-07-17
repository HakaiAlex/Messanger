namespace Domain.Entities;

public class Contact
{
    public Guid UserID { get; set; }
    public Guid ContactID { get; set; }
    public string Status { get; set; } = "Offline";
}
