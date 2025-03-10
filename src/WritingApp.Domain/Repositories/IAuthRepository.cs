using Microsoft.AspNetCore.Identity;
using WritingApp.Domain.Entities;

namespace WritingApp.Domain.Repositories;

public interface IAuthRepository
{
    Task<IdentityResult> RegisterUserAsync(User user, string password);
    Task<User?> GetByEmail(string email);
}
