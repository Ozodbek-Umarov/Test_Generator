using Domain.Entities;

namespace Data.Interfaces;

public interface ITestRepository : IRepository<Test>
{
    Task<Test?> GetByQuestionAsync(string question);
}
