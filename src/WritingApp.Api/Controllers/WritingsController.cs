using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WritingApp.Application.Dto;

namespace WritingApp.API.Controllers;

[ApiController]
[Route("api/writings")]
[Authorize]
public class WritingsController(IWritingInteractor writingInteractor) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var writings = await writingInteractor.GetAllAsync();
        return Ok(writings);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetAllCurrent()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized("User not found");

        var writings = await writingInteractor.GetAllCurrentAsync(userId);
        return Ok(writings);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        var writing = await writingInteractor.GetByIdAsync(id);
        if (writing == null) return NotFound();
        return Ok(writing);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WritingCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized("User not found");

        await writingInteractor.CreateAsync(dto, userId);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] WritingUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await writingInteractor.UpdateAsync(id, dto);
        if (!result) return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await writingInteractor.DeleteAsync(id);
        if (!result) return NotFound();

        return Ok();
    }
}
