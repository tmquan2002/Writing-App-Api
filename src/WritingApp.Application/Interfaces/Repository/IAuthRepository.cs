using Microsoft.AspNetCore.Identity;
using WritingApp.Domain.Entities;

namespace WritingApp.Application.Interfaces.Repository;

public interface IAuthRepository
{
    //Task login()
    Task<User?> GetInfo(string userId);
    Task<IdentityResult> UpdateInfo(User user);
}
