using Domain.Entities;

namespace Application.DTOs.OptionDtos;

public class OptionDto : AddOptionDto
{
    public int Id { get; set; }
    public Test Test { get; set; } = null!;

    public static implicit operator OptionDto(Option option)
    {
        return new OptionDto()
        {
            Id = option.Id,
            TestId = option.TestId
        };
    }
    public static implicit operator Option(OptionDto option)
    {
        return new OptionDto()
        {
            Id = option.Id,
            TestId = option.TestId
        };
    }
}
