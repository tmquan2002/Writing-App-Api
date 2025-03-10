using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WritingApp.Application.Auth.Dtos;
using WritingApp.Application.Auth.Services;

namespace WritingApp.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrent()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized("User not found");

        var user = await authService.GetInfo(userId);
        if (user == null) return NotFound("User not found");

        return Ok(user);
    }

    [HttpPut("me")]
    [Authorize]
    public async Task<IActionResult> UpdateInfo([FromBody] UpdateUserDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized("User not found");

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await authService.UpdateInfo(userId, dto);
        if (!result) return NotFound();

        return Ok();
    }
}
