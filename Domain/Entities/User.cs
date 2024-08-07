using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities;

public class User : Base
{
    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string? ProfilePicture { get; private set; }
    public string Status { get; private set; } = "Offline";

    private readonly List<Message> _sentMessages = [];
    private readonly List<Message> _receivedMessages = [];
    private readonly List<Contact> _contacts = [];
    private readonly List<Chat> _chats = [];

    public IReadOnlyCollection<Message> SentMessages => _sentMessages.AsReadOnly();
    public IReadOnlyCollection<Message> ReceivedMessages => _receivedMessages.AsReadOnly();
    public IReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();
    public IReadOnlyCollection<Chat> Chats => _chats.AsReadOnly();

    private User() { }

    public User(string username, string email, string passwordHash, string profilePicture, string status)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        ProfilePicture = profilePicture;
        Status = status;
    }

    public void AddContact(User contactUser)
    {
        ArgumentNullException.ThrowIfNull(contactUser);
        if (_contacts.Any(c => c.ContactUserId == contactUser.Id))
        {
            throw new InvalidOperationException("Contact already exist!");
        }

        var contact = new Contact(Id, contactUser.Id);
        _contacts.Add(contact);
    }

    public void RemoveContact(User contactUser)
    {
        ArgumentNullException.ThrowIfNull(contactUser);
        var contact = _contacts.FirstOrDefault(c => c.ContactUserId == contactUser.Id)
            ?? throw new InvalidOperationException("Contact does not exist.");

        _contacts.Remove(contact);
    }

    //public void AddChat(int id)
    //{
    //    ArgumentNullException.ThrowIfNull(contactUser);
    //    if (_contacts.Any(c => c.ContactUserId == contactUser.Id))
    //    {
    //        throw new InvalidOperationException("Contact already exist!");
    //    }

    //    var contact = new Contact(Id, contactUser.Id);
    //    _contacts.Add(contact);
    //}

    //public void RemoveContact(User contactUser)
    //{
    //    ArgumentNullException.ThrowIfNull(contactUser);
    //    var contact = _contacts.FirstOrDefault(c => c.ContactUserId == contactUser.Id)
    //        ?? throw new InvalidOperationException("Contact does not exist.");

    //    _contacts.Remove(contact);
    //}
}
