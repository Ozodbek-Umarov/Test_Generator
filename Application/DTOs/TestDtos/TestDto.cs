using Application.DTOs.OptionDtos;
using Domain.Entities;

namespace Application.DTOs.TestDtos;

public class TestDto : AddTestDto
{
    public int Id { get; set; }
    public List<OptionDto> Options { get; set; }

    public static implicit operator TestDto(Test test)
    {
        return new TestDto()
        {
            Id = test.Id,
            Question = test.Question,
        };
    }

    public static implicit operator Test(TestDto dto)
    {
        return new Test()
        {
            Id = dto.Id,
            Question = dto.Question,
        };
    }
}
