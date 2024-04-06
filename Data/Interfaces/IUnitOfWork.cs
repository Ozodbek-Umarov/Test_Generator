namespace Data.Interfaces;

public interface IUnitOfWork
{
    ITestRepository Test { get; }
    IOptionRepository Option { get; }
}
