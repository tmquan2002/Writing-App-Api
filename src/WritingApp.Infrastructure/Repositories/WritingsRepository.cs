﻿using Microsoft.EntityFrameworkCore;
using WritingApp.Domain.Entities;
using WritingApp.Domain.Repositories;
using WritingApp.Infrastructure.Persistence;

namespace WritingApp.Infrastructure.Repositories;

internal class WritingsRepository(WritingsDbContext dbContext) : IWritingsRepository
{
    public async Task<IEnumerable<Writing>> GetAllAsync()
    {
        return await dbContext.Writings.ToListAsync();
    }

    public async Task<Writing?> GetByIdAsync(int id)
    {
        return await dbContext.Writings.FindAsync(id);
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
