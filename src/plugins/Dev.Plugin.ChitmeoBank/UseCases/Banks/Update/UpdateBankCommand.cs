namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.Update;

public record class UpdateBankCommand : ICommand<Result<BankDto>>
{
    public UpdateBankCommand(Guid bankId, string name, bool isActive)
    {
        BankId = bankId;
        Name = name;
        IsActive = isActive;
    }
    public Guid BankId { get; init; }
    public string Name { get; init; }
    public bool IsActive { get; init; }
}
