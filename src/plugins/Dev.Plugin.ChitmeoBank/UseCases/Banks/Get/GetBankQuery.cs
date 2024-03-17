namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.Get;

public record GetBankQuery : IQuery<Result<BankDto>>
{
    public GetBankQuery(Guid bankId)
    {
        BankId = bankId;
    }
    public Guid BankId { get; init; }
}