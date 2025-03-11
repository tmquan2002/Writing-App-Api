using WritingApp.Application.Dto;

public interface IAuthInteractor
{
    Task<UserDto?> GetInfo(string userId);
    Task<bool> UpdateInfo(string userId, UpdateUserDto userDto);
}