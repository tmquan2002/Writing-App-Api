using Microsoft.AspNetCore.Identity;
using WritingApp.Application.Interfaces.Repository;
using WritingApp.Domain.Entities;

namespace WritingApp.Infrastructure.Repositories;

internal class AuthRepository(UserManager<User> userManager) : IAuthRepository
{
    public async Task<User?> GetInfo(string userId)
    {
        return await userManager.FindByIdAsync(userId);
    }

    public async Task<IdentityResult> UpdateInfo(User user)
    {
        return await userManager.UpdateAsync(user);
    }
}
