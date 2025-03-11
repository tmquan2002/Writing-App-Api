using WritingApp.Application.Dto.Writings;
using WritingApp.Application.Interfaces.Repository;
using WritingApp.Application.Interfaces.Services;
using WritingApp.Domain.Entities;

namespace WritingApp.Application.Services.Writings;

public class WritingService(IWritingsRepository writingRepository) : IWritingService
{
    public async Task<IEnumerable<WritingDto>> GetAllAsync()
    {
        var writings = await writingRepository.GetAllAsync();
        return writings.Select(w => new WritingDto
        {
            Id = w.Id,
            Title = w.Title,
            Type = w.Type ?? "",
            PublishedDate = w.PublishedDate,
            Description = w.Description ?? "",
            Article = w.Article ?? "",
            Completed = w.Completed,
            Author = w.Author?.Fullname ?? ""
        });
    }

    public async Task<WritingDto?> GetByIdAsync(int id)
    {
        var writing = await writingRepository.GetByIdAsync(id);
        return writing == null ? null : new WritingDto
        {
            Id = writing.Id,
            Title = writing.Title,
            Type = writing.Type ?? "",
            PublishedDate = writing.PublishedDate,
            Description = writing.Description ?? "",
            Article = writing.Article ?? "",
            Completed = writing.Completed,
            Author = writing.Author?.Fullname ?? ""
        };
    }

    public async Task<int> CreateAsync(WritingCreateDto writing, string userId)
    {
        var newWriting = new Writing
        {
            Title = writing.Title,
            Type = writing.Type,
            PublishedDate = writing.PublishedDate,
            Description = writing.Description,
            Article = writing.Article,
            Completed = writing.Completed,
            AuthorId = userId.Equals("") ? Guid.Empty : Guid.Parse(userId)
        };

        await writingRepository.AddAsync(newWriting);
        return newWriting.Id;
    }

    public async Task<bool> UpdateAsync(int id, WritingUpdateDto writing)
    {
        var existingWriting = await writingRepository.GetByIdAsync(id);
        if (existingWriting == null) return false;

        existingWriting.Title = writing.Title;
        existingWriting.Type = writing.Type;
        existingWriting.PublishedDate = writing.PublishedDate;
        existingWriting.Description = writing.Description;
        existingWriting.Completed = writing.Completed;

        await writingRepository.UpdateAsync(existingWriting);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var writing = await writingRepository.GetByIdAsync(id);
        if (writing == null) return false;

        await writingRepository.DeleteAsync(writing);
        return true;
    }
}
