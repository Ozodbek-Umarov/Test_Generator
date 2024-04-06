using Application.DTOs.TestDtos;

namespace Application.Interfaces;

public interface ITestService
{
    Task CreateAsync(AddTestDto dto);
    Task UpdateAsync(TestDto dto);
    Task DeleteAsync(int id);
    Task<List<TestDto>> GetAllAsync();
    Task<TestDto> GetByIdAsync(int id);
}
