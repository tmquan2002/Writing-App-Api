using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WritingApp.Application.Dto.Auths;
using WritingApp.Application.Interfaces.Services;

namespace WritingApp.API.Controllers;

[ApiController]
[Route("api/auth")]
[Authorize]
public class AuthController(IAuthService authService) : ControllerBase
{
    //[HttpPost("login")]
    //public async Task<IActionResult> Login([FromBody] LoginDto model)
    //{
    //    var user = await _userManager.FindByEmailAsync(model.Email);
    //    if (user == null)
    //    {
    //        return Unauthorized(new { message = "Invalid email or password" });
    //    }

    //    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
    //    if (!result.Succeeded)
    //    {
    //        return Unauthorized(new { message = "Invalid email or password" });
    //    }

    //    var token = _tokenService.GenerateToken(user);

    //    return Ok(new
    //    {
    //        token,
    //        fullname = user.Fullname
    //    });
    //}

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrent()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized("User not found");

        var user = await authService.GetInfo(userId);
        if (user == null) return NotFound("User not found");

        return Ok(user);
    }

    [HttpGet("user/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await authService.GetInfo(id);
        if (user == null) return NotFound("User not found");

        return Ok(user);
    }

    [HttpPut("me")]
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
