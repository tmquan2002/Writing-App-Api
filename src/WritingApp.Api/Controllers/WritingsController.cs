using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WritingApp.Application.Writings.Dtos;
using WritingApp.Application.Writings.Services;

namespace WritingApp.API.Controllers;

[ApiController]
[Route("api/writings")]
[Authorize]
public class WritingsController(IWritingService writingService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var writings = await writingService.GetAllAsync();
        return Ok(writings);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        var writing = await writingService.GetByIdAsync(id);
        if (writing == null) return NotFound();
        return Ok(writing);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WritingCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized("User Not Found");
        var id = await writingService.CreateAsync(dto, userId);
        return CreatedAtAction(nameof(GetById), new { id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] WritingUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await writingService.UpdateAsync(id, dto);
        if (!result) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await writingService.DeleteAsync(id);
        if (!result) return NotFound();

        return NoContent();
    }
}
