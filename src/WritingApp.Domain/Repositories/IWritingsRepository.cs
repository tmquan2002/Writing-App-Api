using WritingApp.Domain.Entities;

namespace WritingApp.Domain.Repositories;

public interface IWritingsRepository
{
    Task<IEnumerable<Writing>> GetAllAsync();
    Task<Writing?> GetByIdAsync(int id);
    Task AddAsync(Writing writing);
    Task UpdateAsync(Writing writing);
    Task DeleteAsync(Writing writing);
}
