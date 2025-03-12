using WritingApp.Domain.DomainInterface;

namespace WritingApp.Domain.Entities;

public class User : IUser // Domain User implement IUser
{
    public string Id { get; private set; }
    public string Email { get; private set; }
    public string? Fullname { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public string? Gender { get; set; }
    public List<Writing> Writings { get; set; }

    public User(string email, string fullname, DateOnly dateOfBirth, string nationality, string gender)
    {
        Id = Guid.NewGuid().ToString();
        Email = email;
        Fullname = fullname;
        DateOfBirth = dateOfBirth;
        Nationality = nationality;
        Gender = gender;
        Writings = new List<Writing>();
    }

    private User() { Id = Guid.NewGuid().ToString(); Writings = new List<Writing>(); }

    string IUser.Id => Id;

}