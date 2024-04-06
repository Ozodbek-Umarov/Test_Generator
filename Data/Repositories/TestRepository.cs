using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class TestRepository(AppDbContext dbContext) : Repository<Test>(dbContext), ITestRepository
{
    public async Task<Test?> GetByQuestionAsync(string question)
    {
        return await _dbContext.Tests.FirstOrDefaultAsync(x => x.Question == question);
    }
}
