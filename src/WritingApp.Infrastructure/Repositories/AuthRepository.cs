using Microsoft.AspNetCore.Identity;
using WritingApp.Application.ApplicationEntities;
using WritingApp.Application.Interfaces.Repository;
using WritingApp.Domain.Entities;

namespace WritingApp.Infrastructure.Repositories;

internal class AuthRepository(UserManager<ApplicationUser> userManager) : IAuthRepository
{
    public async Task<ApplicationUser?> GetInfo(string userId)
    {
        return await userManager.FindByIdAsync(userId);
    }

    public async Task<IdentityResult> UpdateInfo(ApplicationUser user)
    {
        return await userManager.UpdateAsync(user);
    }
}
