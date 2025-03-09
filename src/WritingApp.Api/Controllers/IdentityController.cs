using Microsoft.AspNetCore.Mvc;
using WritingApp.Application.Auth.Dtos;
using WritingApp.Application.Auth.Services;

namespace WritingApp.API.Controllers;

[ApiController]
[Route("api/auth")]
public class IdentityController(IAuthService authService) : ControllerBase
{
    [HttpPost("registereeee")]
    public async Task<IActionResult> Register([FromBody] RegisterDto body)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await authService.Register(body);

        if (!result.Succeeded)
        {
            return BadRequest("There's an error trying to register, please try again later");
        }

        return Ok("Registered successfully.");
    }
}
