using WritingApp.Domain.Entities;
using WritingApp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace WritingApp.Infrastructure.Repositories;

internal class AuthRepository(UserManager<User> userManager) : IAuthRepository
{
    public async Task<User?> GetByEmail(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> RegisterUserAsync(User user, string password)
    {
        return await userManager.CreateAsync(user, password);
    }
}
