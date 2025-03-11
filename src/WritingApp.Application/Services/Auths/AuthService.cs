using WritingApp.Application.Dto.Auths;
using WritingApp.Application.Interfaces.Repository;
using WritingApp.Application.Interfaces.Services;

namespace WritingApp.Application.Services.Auths;

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public async Task<UserDto?> GetInfo(string userId)
    {
        var user = await authRepository.GetInfo(userId);
        return user == null ? null : new UserDto
        {
            Email = user.Email ?? "",
            DateOfBirth = user.DateOfBirth,
            Fullname = user.Fullname ?? "",
            Gender = user.Gender ?? "",
            Nationality = user.Nationality ?? ""
        };
    }

    public async Task<bool> UpdateInfo(string userId, UpdateUserDto userDto)
    {
        var currentUser = await authRepository.GetInfo(userId);
        if (currentUser == null) return false;

        currentUser.Fullname = userDto.Fullname;
        currentUser.DateOfBirth = userDto.DateOfBirth;
        currentUser.Gender = userDto.Gender;
        currentUser.Nationality = userDto.Nationality;

        await authRepository.UpdateInfo(currentUser);
        return true;
    }
}
