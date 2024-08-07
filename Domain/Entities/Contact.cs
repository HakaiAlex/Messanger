using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Contact
{
    public int UserID { get; private set; }
    public int ContactUserId { get; private set; }
    public string Status { get; private set; } = "Offline";

    public User User { get; private set; } = null!;
    public User ContactUser { get; private set; } = null!;

    private Contact() { }

    public Contact(int userID, int contactUserId, string status = "Offline")
    {
        UserID = userID;
        ContactUserId = contactUserId;
        Status = status;
    }
}
