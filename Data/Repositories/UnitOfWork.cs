using Data.Interfaces;

namespace Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public ITestRepository Test => new TestRepository(_dbContext);

    public IOptionRepository Option => new OptionRepository(_dbContext);
}
