using WritingApp.Application.Dto;
using WritingApp.Application.Interfaces.Services;

namespace WritingApp.Application.Interactor;

public class WritingInteractor(IWritingService writingService) : IWritingInteractor
{
    public async Task<IEnumerable<WritingDto>> GetAllAsync()
    {
        return await writingService.GetAllAsync();
    }

    public async Task<WritingDto?> GetByIdAsync(int id)
    {
        if (id <= 0) return null;
        return await writingService.GetByIdAsync(id);
    }

    public async Task CreateAsync(WritingCreateDto dto, string userId)
    {
        //Can validate here before calling service
        await writingService.CreateAsync(dto, userId);
    }

    public async Task<bool> UpdateAsync(int id, WritingUpdateDto writing)
    {
        return await writingService.UpdateAsync(id, writing);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await writingService.DeleteAsync(id);
    }
}