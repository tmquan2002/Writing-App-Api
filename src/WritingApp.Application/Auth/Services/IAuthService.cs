using WritingApp.Application.Auth.Dtos;

namespace WritingApp.Application.Auth.Services;

public interface IAuthService
{
    Task<UserDto?> GetInfo(string userId);
    Task<bool> UpdateInfo(string userId, UpdateUserDto userDto);
}