namespace Domain.Entities;

public class Option : BaseEntity
{
    public string Variant { get; set; } = string.Empty;

    public int TestId { get; set; }
    public Test Test { get; set; } = null!;
}
