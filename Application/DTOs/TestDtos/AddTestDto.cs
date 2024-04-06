using Domain.Entities;

namespace Application.DTOs.TestDtos;

public class AddTestDto
{
    public string Question { get; set; } = string.Empty;


    public static implicit operator Test(AddTestDto dto)
    {
        return new Test
        {
            Question = dto.Question,
            
        };
    }
}
