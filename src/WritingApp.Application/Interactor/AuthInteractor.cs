using WritingApp.Application.Dto;
using WritingApp.Application.Interfaces.Services;

namespace WritingApp.Application.Interactor;
public class AuthInteractor(IAuthService authService) : IAuthInteractor
{
    public async Task<UserDto?> GetInfo(string userId)
    {
        return await authService.GetInfo(userId);
    }

    public async Task<bool> UpdateInfo(string userId, UpdateUserDto userDto)
    {
        return await authService.UpdateInfo(userId, userDto);
    }
}
