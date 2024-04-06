using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories;

public class TestRepository(AppDbContext dbContext) : Repository<Test>(dbContext), ITestRepository
{
}
