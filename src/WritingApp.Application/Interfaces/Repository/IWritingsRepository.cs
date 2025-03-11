using WritingApp.Domain.Entities;

namespace WritingApp.Application.Interfaces.Repository;

public interface IWritingsRepository
{
    Task<IEnumerable<Writing>> GetAllAsync();
    Task<IEnumerable<Writing>> GetAllCurrentAsync(string userId);
    Task<Writing?> GetByIdAsync(int id);
    Task AddAsync(Writing writing);
    Task UpdateAsync(Writing writing);
    Task DeleteAsync(Writing writing);
}
