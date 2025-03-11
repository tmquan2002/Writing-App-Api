using System.ComponentModel.DataAnnotations;

namespace WritingApp.Application.Dto
{
    public class AuthDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class UserDto
    {
        public required string Email { get; set; }
        public string? Fullname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
    }

    public class UpdateUserDto
    {
        public required string Fullname { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
    }

}
