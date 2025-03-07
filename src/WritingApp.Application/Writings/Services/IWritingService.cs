using WritingApp.Application.Writings.Dtos;

namespace WritingApp.Application.Writings.Services
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
