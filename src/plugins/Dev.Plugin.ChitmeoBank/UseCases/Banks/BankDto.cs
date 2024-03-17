namespace Dev.Plugin.ChitmeoBank.UseCases.Banks;
public record BankDto
{
    public BankDto(Guid id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }
    public Guid Id { get; init; }
    public string Name { get; init; }
    public bool IsActive { get; init; }
}
