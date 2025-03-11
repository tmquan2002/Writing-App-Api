using WritingApp.Application.Dto;

public interface IWritingInteractor
{
    Task<IEnumerable<WritingDto>> GetAllAsync();
    Task<IEnumerable<WritingCurrentDto>> GetAllCurrentAsync(string userId);
    Task<WritingDto?> GetByIdAsync(int id);
    Task CreateAsync(WritingCreateDto dto, string userId);
    Task<bool> UpdateAsync(int id, WritingUpdateDto writing);
    Task<bool> DeleteAsync(int id);
}
