namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.List;

public class ListBanksQuery : IQuery<Result<IEnumerable<BankDto>>>
{
    public ListBanksQuery(int? skip, int? take)
    {
        Skip = skip;
        Take = take;
    }
    public int? Skip { get; init; }
    public int? Take { get; init; }
}
