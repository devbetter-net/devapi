using Dev.Core.Result;

namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.Create;

public record CreateBankCommand : ICommand<Result<Guid>>
{
    public CreateBankCommand(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }
    public string Name { get; init; }
    public bool IsActive { get; init; }
}