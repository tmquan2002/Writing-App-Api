﻿using WritingApp.Application.Dto;

namespace WritingApp.Application.Interfaces.Services;

public interface IAuthService
{
    Task<UserDto?> GetInfo(string userId);
    Task<bool> UpdateInfo(string userId, UpdateUserDto userDto);
}