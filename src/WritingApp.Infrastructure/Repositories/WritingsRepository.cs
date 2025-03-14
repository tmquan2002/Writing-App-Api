﻿using Microsoft.EntityFrameworkCore;
using WritingApp.Application.Interfaces.Repository;
using WritingApp.Domain.Entities;
using WritingApp.Infrastructure.Persistence;

namespace WritingApp.Infrastructure.Repositories;

internal class WritingsRepository(WritingsDbContext dbContext) : IWritingsRepository
{
    public async Task<IEnumerable<Writing>> GetAllAsync()
    {
        return await dbContext.Writings
            .Include(w => w.Author)
            .Where(w => w.Completed)
            .ToListAsync();
    }

    public async Task<IEnumerable<Writing>> GetAllCurrentAsync(string userId)
    {
        return await dbContext.Writings
            .Where(w => w.AuthorId == userId)
            .ToListAsync();
    }

    public async Task<Writing?> GetByIdAsync(int id)
    {
        return await dbContext.Writings
            .Include(w => w.Author)
            .Where(w => w.Id == id && w.Completed)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(Writing writing)
    {
        await dbContext.Writings.AddAsync(writing);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Writing writing)
    {
        dbContext.Writings.Update(writing);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Writing writing)
    {
        dbContext.Writings.Remove(writing);
        await dbContext.SaveChangesAsync();
    }
}
