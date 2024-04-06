using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories;

public class OptionRepository(AppDbContext dbContext) : Repository<Option>(dbContext), IOptionRepository
{
}
