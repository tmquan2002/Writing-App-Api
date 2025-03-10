using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WritingApp.Application.Auth.Dtos;
using WritingApp.Domain.Entities;
using WritingApp.Domain.Repositories;

namespace WritingApp.Application.Auth.Services;

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public async Task<IdentityResult> Register([FromBody] RegisterDto body)
    {
        var user = new User
        {
            Email = body.Email,
            Fullname = body.Fullname,
            DateOfBirth = body.DateOfBirth,
            Nationality = body.Nationality,
            Gender = body.Gender
        };

        return await authRepository.RegisterUserAsync(user, body.Password);
    }
}
