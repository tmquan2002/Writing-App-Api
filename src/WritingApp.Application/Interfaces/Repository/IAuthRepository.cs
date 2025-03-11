using Microsoft.AspNetCore.Identity;
using WritingApp.Application.ApplicationEntities;
using WritingApp.Domain.Entities;

namespace WritingApp.Application.Interfaces.Repository;

public interface IAuthRepository
{
    //Task login()
    Task<ApplicationUser?> GetInfo(string userId);
    Task<IdentityResult> UpdateInfo(ApplicationUser user);
}
