namespace Domain.Entities;

public class Test : BaseEntity
{
    public string Question { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<Option> Options { get; set; } = new();
}
