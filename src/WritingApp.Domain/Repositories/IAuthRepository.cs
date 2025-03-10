﻿using Microsoft.AspNetCore.Identity;
using WritingApp.Domain.Entities;

namespace WritingApp.Domain.Repositories;

public interface IAuthRepository
{
    Task<User?> GetInfo(string userId);
    Task<IdentityResult> UpdateInfo(User user);
}
