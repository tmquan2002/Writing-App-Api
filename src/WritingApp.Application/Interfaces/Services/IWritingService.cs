using WritingApp.Application.Dto;

namespace WritingApp.Application.Interfaces.Services
{
    public interface IWritingService
    {
        Task<IEnumerable<WritingDto>> GetAllAsync();
        Task<WritingDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(WritingCreateDto writing, string userId);
        Task<bool> UpdateAsync(int id, WritingUpdateDto writing);
        Task<bool> DeleteAsync(int id);
    }
}
