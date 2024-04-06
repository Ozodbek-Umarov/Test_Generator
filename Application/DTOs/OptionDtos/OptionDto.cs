using Domain.Entities;

namespace Application.DTOs.OptionDtos;

public class OptionDto : AddOptionDto
{
    public int Id { get; set; }

    public static implicit operator OptionDto(Option option)
    {
        return new OptionDto()
        {
            Id = option.Id,
            TestId = option.TestId,
            Variant = option.Variant
        };
    }
    public static implicit operator Option(OptionDto option)
    {
        return new OptionDto()
        {
            Id = option.Id,
            TestId = option.TestId,
            Variant = option.Variant
        };
    }
}
