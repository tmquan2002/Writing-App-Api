using Microsoft.AspNetCore.Identity;
using WritingApp.Application.Auth.Dtos;

namespace WritingApp.Application.Auth.Services;

public interface IAuthService
{
    Task<IdentityResult> Register(RegisterDto model);
}