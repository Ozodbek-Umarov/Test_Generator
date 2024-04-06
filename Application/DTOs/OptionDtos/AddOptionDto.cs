using Domain.Entities;

namespace Application.DTOs.OptionDtos;

public class AddOptionDto
{
    public string Variant { get; set; } = string.Empty;
    public int TestId { get; set; }

    public static implicit operator Option(AddOptionDto dto)
    {
        return new Option
        {
            Variant = dto.Variant,
            TestId = dto.TestId,
        };
    }
}
