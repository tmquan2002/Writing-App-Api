using Microsoft.AspNetCore.Identity;

namespace WritingApp.Domain.Entities;

public class User : IdentityUser
{
    public string? Fullname { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public string? Gender { get; set; }
    public List<Writing>? Writings { get; set; } = [];
}
